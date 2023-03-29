using Orcamento.Infra.AppDbContext;

namespace Orcamento.Application.Orcamento.Services;

public class OrcamentoService
{
    private readonly OrcamentoDbContext _context;

    public OrcamentoService(OrcamentoDbContext context)
    {
        _context = context;
    }
    
}