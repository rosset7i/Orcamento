using Orcamento.Application.Authentication.Services;
using Orcamento.Application.Fornecedores.Services;
using Orcamento.Application.GenericServices;
using Orcamento.Application.Orcamentos.Services;
using Orcamento.Application.Produtos.Services;

namespace Orcamento.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtTokenGeneratorService, JwtTokenGeneratorService>();
        services.AddScoped<IDateTimeProviderService, DateTimeProviderService>();
        services.AddScoped<IOrcamentoService, OrcamentoService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IFornecedorService, FornecedorService>();
        
        return services;
    }   
}