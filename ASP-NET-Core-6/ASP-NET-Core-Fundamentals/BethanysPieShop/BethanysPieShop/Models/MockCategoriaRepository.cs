namespace BethanysPieShop.Models;

public class MockCategoriaRepository : ICategoriaRepository
{
    public IEnumerable<Categoria> ObterCategorias =>
        [
            new Categoria{CategoriaId=1, CategoriaNome="Tortas de Frutas", Descricao="Todas as tortas frutadas"},
            new Categoria{CategoriaId=2, CategoriaNome="Tortas de Queijo", Descricao="Queijo o tempo todo"},
            new Categoria{CategoriaId=3, CategoriaNome="Tortas Sazonais", Descricao="Entre no clima para uma torta sazonal"}
        ];
}