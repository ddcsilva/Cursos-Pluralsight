namespace BethanysPieShop.Models.Interfaces;

public interface ICarrinho
{
    void AdicionarAoCarrinho(Torta torta);
    int RemoverDoCarrinho(Torta torta);
    List<CarrinhoItem> ObterItensCarrinho();
    void LimparCarrinho();
    decimal ObterTotalCarrinho();
    List<CarrinhoItem> CarrinhoItens { get; set; }
}
