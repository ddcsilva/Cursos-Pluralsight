namespace BethanysPieShop.Models;

public class CarrinhoItem
{
    public int CarrinhoItemId { get; set; }
    public Torta Torta { get; set; } = default!;
    public int Quantidade { get; set; }
    public string? CarrinhoId { get; set; }
}
