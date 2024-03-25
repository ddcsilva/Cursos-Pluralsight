namespace BethanysPieShop.Models;

public class Torta
{
    public int TortaId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? DescricaoCurta { get; set; }
    public string? DescricaoDetalhada { get; set; }
    public string? InformacoesAlergicas { get; set; }
    public decimal Preco { get; set; }
    public string? ImagemUrl { get; set; }
    public string? ImagemThumbnailUrl { get; set; }
    public bool EhTortaDaSemana { get; set; }
    public bool EmEstoque { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; } = default!;
}
