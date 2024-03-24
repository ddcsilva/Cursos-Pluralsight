namespace BethanysPieShop.Models;

public interface ICategoriaRepository
{
    IEnumerable<Categoria> ObterCategorias { get; }
}
