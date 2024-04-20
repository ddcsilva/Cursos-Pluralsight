using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class TortasController : Controller
{
    private readonly ITortaRepository _tortaRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public TortasController(ITortaRepository tortaRepository, ICategoriaRepository categoriaRepository)
    {
        _tortaRepository = tortaRepository;
        _categoriaRepository = categoriaRepository;
    }

    public IActionResult Listar()
    {
        // ViewBag: é uma propriedade que fornece um mecanismo para passar dados do controlador para a view
        ViewBag.CategoriaAtual = "Tortas de Queijo";

        // ObterTortas: é um método que retorna uma lista de tortas
        var tortas = _tortaRepository.ObterTortas;

        // TortaListaViewModel: é uma ViewModel que fornece uma lista de tortas e a categoria atual
        TortaListaViewModel tortaListaViewModel = new(tortas, ViewBag.CategoriaAtual);

        // View: é um método que retorna uma ViewResult, que representa uma página HTML
        return View(tortaListaViewModel);
    }
}
