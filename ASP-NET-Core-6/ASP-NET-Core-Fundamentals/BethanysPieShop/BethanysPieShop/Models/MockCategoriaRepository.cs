namespace BethanysPieShop.Models;

public class MockCategoriaRepository : ICategoriaRepository
{
    public IEnumerable<Categoria> ObterCategorias =>
        [
            new Categoria {CategoriaId = 1, CategoriaNome = "Torta de Frutas", Descricao = "Tortas de frutas frescas"},
            new Categoria {CategoriaId = 2, CategoriaNome = "Torta de Queijo", Descricao = "Tortas de queijo cremoso"},
            new Categoria {CategoriaId = 3, CategoriaNome = "Torta de Carne", Descricao = "Tortas de carne suculenta"}
        ];
}