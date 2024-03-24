using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels;

public class TortaListaViewModel
{
    public TortaListaViewModel(IEnumerable<Torta> tortas, string? categoriaAtual)
    {
        Tortas = tortas;
        CategoriaAtual = categoriaAtual;
    }

    public IEnumerable<Torta> Tortas { get; set; }
    public string? CategoriaAtual { get; set; }
}
