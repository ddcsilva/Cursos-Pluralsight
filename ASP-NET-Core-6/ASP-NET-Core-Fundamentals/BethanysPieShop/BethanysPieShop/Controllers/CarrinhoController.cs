using BethanysPieShop.Models.Interfaces;
using BethanysPieShop.Repositories.Interfaces;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class CarrinhoController : Controller
{
    private readonly ITortaRepository _tortaRepository;
    private readonly ICarrinho _carrinho;

    public CarrinhoController(ITortaRepository tortaRepository, ICarrinho carrinho)
    {
        _tortaRepository = tortaRepository;
        _carrinho = carrinho;
    }

    public ViewResult Index()
    {
        var itens = _carrinho.ObterItensCarrinho();
        _carrinho.CarrinhoItens = itens;

        var carrinhoViewModel = new CarrinhoViewModel(_carrinho, _carrinho.ObterTotalCarrinho());

        return View(carrinhoViewModel);
    }

    public RedirectToActionResult AdicionarAoCarrinho(int tortaId)
    {
        var tortaSelecionada = _tortaRepository.ObterTortas.FirstOrDefault(t => t.TortaId == tortaId);

        if (tortaSelecionada != null)
        {
            _carrinho.AdicionarAoCarrinho(tortaSelecionada);
        }

        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoverDoCarrinho(int tortaId)
    {
        var tortaSelecionada = _tortaRepository.ObterTortas.FirstOrDefault(t => t.TortaId == tortaId);

        if (tortaSelecionada != null)
        {
            _carrinho.RemoverDoCarrinho(tortaSelecionada);
        }

        return RedirectToAction("Index");
    }
}