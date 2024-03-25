using BethanysPieShop.Models;

namespace BethanysPieShop;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly BethanysPieShopDbContext _context;

    public CategoriaRepository(BethanysPieShopDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Categoria> ObterCategorias => _context.Categorias.OrderBy(c => c.CategoriaNome);
}
