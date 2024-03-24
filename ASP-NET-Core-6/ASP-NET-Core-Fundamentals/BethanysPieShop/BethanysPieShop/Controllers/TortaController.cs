using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class TortaController : Controller
{
    private readonly ITortaRepository _tortaRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public TortaController(ITortaRepository tortaRepository, ICategoriaRepository categoriaRepository)
    {
        _tortaRepository = tortaRepository;
        _categoriaRepository = categoriaRepository;
    }

    public ViewResult Listar()
    {
        ViewBag.CategoriaAtual = "Torta de Queijo";
        return View(_tortaRepository.ObterTortas);
    }
}
