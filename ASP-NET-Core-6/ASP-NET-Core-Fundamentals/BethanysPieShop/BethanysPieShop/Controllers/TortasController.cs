using BethanysPieShop.Models;
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
        var tortas = _tortaRepository.ObterTortas;
        return View(tortas);
    }
}
