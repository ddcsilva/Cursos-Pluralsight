using BethanysPieShop.Models.Interfaces;

namespace BethanysPieShop.ViewModels;

public class CarrinhoViewModel
{
    public CarrinhoViewModel(ICarrinho carrinho, decimal totalCarrinho)
    {
        Carrinho = carrinho;
        TotalCarrinho = totalCarrinho;
    }

    public ICarrinho Carrinho { get; }
    public decimal TotalCarrinho { get; }
}