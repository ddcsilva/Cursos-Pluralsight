using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
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
        TortaListaViewModel tortaListaViewModel = new(_tortaRepository.ObterTortas, "Tortas de Queijo");
        return View(tortaListaViewModel);
    }

    public IActionResult Detalhes(int id)
    {
        var torta = _tortaRepository.ObterTortaPorId(id);

        if (torta == null)
        {
            return NotFound();
        }

        return View(torta);
    }
}
