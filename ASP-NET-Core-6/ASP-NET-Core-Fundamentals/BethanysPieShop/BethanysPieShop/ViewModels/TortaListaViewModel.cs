using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels;

/*
    ViewModel tem a responsabilidade de fornecer dados para a view.
    Neste caso, a ViewModel TortaListaViewModel fornece uma lista de tortas e a categoria atual.
*/

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
