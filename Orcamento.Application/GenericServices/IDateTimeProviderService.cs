namespace Orcamento.Application.GenericServices;

public interface IDateTimeProviderService
{
    DateTime UtcNow { get; set; }
}