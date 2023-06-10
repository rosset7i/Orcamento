﻿using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Orcamento.Application.Authentication.Dtos;
using Orcamento.Application.Authentication.Enums;
using Orcamento.Domain.Entities;
using Orcamento.Infra.AppDbContext;

namespace Orcamento.Application.Authentication.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly OrcamentoDbContext _context;
    
    private readonly IJwtTokenGeneratorService _tokenGeneratorService;

    public AuthenticationService(OrcamentoDbContext context, IJwtTokenGeneratorService tokenGeneratorService)
    {
        _context = context;
        _tokenGeneratorService = tokenGeneratorService;
    }

    public async Task<AuthenticationResult> Register(RegisterRequestDto registerRequestDto)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == registerRequestDto.Email);

        if (user is not null)
        {
            return AuthenticationResult.EmailAlreadyUsed;
        }

        using var hmac = new HMACSHA512();

        var newUser = new User(
            new Guid(),
            registerRequestDto.FirstName,
            registerRequestDto.LastName,
            registerRequestDto.Email,
            hmac.ComputeHash(Encoding.UTF8.GetBytes(registerRequestDto.Password)),
            hmac.Key);

        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
        
        return AuthenticationResult.RegisteredSuccessfully;
    }
    
    public async Task<AuthenticationResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == loginRequestDto.Email);

        if (user is null)
        {
            return null;
        }

        using var hmac = new HMACSHA512(user.PasswordSalt);
        
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginRequestDto.Password));

        for (var i = 0; i < computedHash.Length; i++)
        {
            if (user.PasswordHash[i] != computedHash[i])
            {
                return null;
            }
        }

        var token = _tokenGeneratorService.GenerateToken(user);

        var authResponse = new AuthenticationResponseDto(
            user.Email,
            token);
        
        return authResponse;
    }
}