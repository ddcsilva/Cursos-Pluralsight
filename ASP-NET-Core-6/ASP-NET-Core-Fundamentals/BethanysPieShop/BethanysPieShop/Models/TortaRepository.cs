
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models;

public class TortaRepository : ITortaRepository
{
    private readonly BethanysPieShopDbContext _context;

    public TortaRepository(BethanysPieShopDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Torta> ObterTortas => _context.Tortas.Include(c => c.Categoria);

    public IEnumerable<Torta> ObterTortasDaSemana => _context.Tortas.Include(c => c.Categoria).Where(t => t.EhTortaDaSemana);

    public Torta? ObterTortaPorId(int tortaId)
    {
        return _context.Tortas.FirstOrDefault(t => t.TortaId == tortaId);
    }
}
