﻿namespace Orcamento.Application.Authentication.Dtos;

public record LoginRequestInput(
    string Email,
    string Password);