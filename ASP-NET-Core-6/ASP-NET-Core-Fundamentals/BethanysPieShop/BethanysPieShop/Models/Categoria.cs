namespace BethanysPieShop;

public class Categoria
{
    public int CategoriaId { get; set; }
    public string CategoriaNome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public List<Torta>? Tortas { get; set; }
}
