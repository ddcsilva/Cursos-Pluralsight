namespace BethanysPieShop;

public interface ICategoriaRepository
{
    IEnumerable<Categoria> ObterCategorias { get; }
}
