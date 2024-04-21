using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels;

public class HomeViewModel
{
    public IEnumerable<Torta> TortasDaSemana { get; }

    public HomeViewModel(IEnumerable<Torta> tortasDaSemana)
    {
        TortasDaSemana = tortasDaSemana;
    }
}
