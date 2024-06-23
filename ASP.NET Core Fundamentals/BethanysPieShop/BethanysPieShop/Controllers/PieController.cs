using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository) : Controller
{
    private readonly IPieRepository _pieRepository = pieRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public IActionResult List()
    {
        ViewBag.CurrentCategory = "Cheese cakes";
        return View(_pieRepository.AllPies);
    }
}
