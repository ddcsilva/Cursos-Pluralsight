using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class HomeController : Controller
{
    private readonly ITortaRepository _tortaRepository;

    public HomeController(ITortaRepository tortaRepository)
    {
        _tortaRepository = tortaRepository;
    }

    public IActionResult Index()
    {
        var tortasDaSemana = _tortaRepository.ObterTortasDaSemana;
        var homeViewModel = new HomeViewModel(tortasDaSemana);
        return View(homeViewModel);
    }
}
