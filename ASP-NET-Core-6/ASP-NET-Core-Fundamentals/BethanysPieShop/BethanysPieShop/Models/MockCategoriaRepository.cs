namespace BethanysPieShop.Models;

public class MockCategoriaRepository : ICategoriaRepository
{
    public IEnumerable<Categoria> ObterCategorias =>
        [
            new Categoria {CategoriaId = 1, CategoriaNome = "Torta de frutas", Descricao = "Tortas de frutas frescas"},
            new Categoria {CategoriaId = 2, CategoriaNome = "Torta de queijo", Descricao = "Tortas de queijo cremoso"},
            new Categoria {CategoriaId = 3, CategoriaNome = "Torta de carne", Descricao = "Tortas de carne suculenta"}
        ];
}