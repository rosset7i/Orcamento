using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Orcamento.Application.Authentication.Services;
using Orcamento.Application.Fornecedores.Services;
using Orcamento.Application.GenericServices;
using Orcamento.Application.Orcamentos.Services;
using Orcamento.Application.Produtos.Services;
using Orcamento.Infra.AppDbContext;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddCors();
    builder.Services.AddDbContext<OrcamentoDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
    });
    builder.Services.AddAuthentication()
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        builder.Configuration.GetSection("JwtSettings:Secret").Value!))
            };
        });
    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
    builder.Services.AddScoped<IJwtTokenGeneratorService, JwtTokenGeneratorService>();
    builder.Services.AddScoped<IDateTimeProviderService, DateTimeProviderService>();
    builder.Services.AddScoped<IOrcamentoService, OrcamentoService>();
    builder.Services.AddScoped<IProdutoService, ProdutoService>();
    builder.Services.AddScoped<IFornecedorService, FornecedorService>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseCors(x =>
    {
        x.AllowAnyHeader();
        x.AllowAnyMethod();
        x.AllowAnyOrigin();
    });
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
