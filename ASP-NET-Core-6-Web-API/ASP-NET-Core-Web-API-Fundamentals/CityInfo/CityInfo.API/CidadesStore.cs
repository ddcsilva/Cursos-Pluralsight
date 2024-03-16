using CityInfo.API.Models;

namespace CityInfo.API;

public class CidadesStore
{
    public List<CidadeDTO> Cidades { get; set; }
    public static CidadesStore Current { get; } = new CidadesStore();

    public CidadesStore()
    {
        Cidades = new List<CidadeDTO>()
        {
            new CidadeDTO()
            {
                Id = 1,
                Nome = "Nova Iorque",
                Descrição = "Aquela com a grande estátua de liberdade."
            },
            new CidadeDTO()
            {
                Id = 2,
                Nome = "Antuérpia",
                Descrição = "Aquele com a catedral que nunca foi terminada."
            },
            new CidadeDTO()
            {
                Id = 3,
                Nome = "Paris",
                Descrição = "Aquele com aquela grande torre."
            }
        };
    }
}