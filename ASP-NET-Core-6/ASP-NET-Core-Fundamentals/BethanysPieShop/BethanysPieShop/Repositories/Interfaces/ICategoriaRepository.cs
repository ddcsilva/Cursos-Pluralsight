using BethanysPieShop.Models;

namespace BethanysPieShop.Repositories.Interfaces;

public interface ICategoriaRepository
{
    IEnumerable<Categoria> ObterCategorias { get; }
}
