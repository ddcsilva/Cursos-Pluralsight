namespace BethanysPieShop.Models;

/*
    O operador ? é usado para declarar um tipo como nullable, ou seja, ele pode ser nulo.
    O operador ! é usado para declarar um tipo como não-nullable, ou seja, ele não pode ser nulo.
    O default! é usado para declarar um valor padrão para um tipo não-nullable.
    A propriedade Nome está sendo inicializada com uma string vazia.
    A propriedade Categoria é uma propriedade de navegação, que é usada para navegar de uma entidade para outra.
*/

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
