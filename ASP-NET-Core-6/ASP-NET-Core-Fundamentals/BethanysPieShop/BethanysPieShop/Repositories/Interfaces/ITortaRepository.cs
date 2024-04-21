using BethanysPieShop.Models;

namespace BethanysPieShop.Repositories.Interfaces;

public interface ITortaRepository
{
    IEnumerable<Torta> ObterTortas { get; }
    IEnumerable<Torta> ObterTortasDaSemana { get; }
    Torta? ObterTortaPorId(int tortaId);
}
