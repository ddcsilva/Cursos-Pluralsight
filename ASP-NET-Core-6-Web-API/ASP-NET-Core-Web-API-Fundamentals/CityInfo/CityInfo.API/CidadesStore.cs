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
                Descricao = "Aquela com a grande estátua de liberdade.",
                PontosTuristicos = new List<PontoTuristicoDTO>()
                {
                    new PontoTuristicoDTO()
                    {
                        Id = 1,
                        Nome = "Estátua da Liberdade",
                        Descricao = "Um grande estátua."
                    },
                    new PontoTuristicoDTO()
                    {
                        Id = 2,
                        Nome = "Empire State Building",
                        Descricao = "Um grande edifício."
                    }
                }
            },
            new CidadeDTO()
            {
                Id = 2,
                Nome = "Antuérpia",
                Descricao = "Aquele com a catedral que nunca foi terminada.",
                PontosTuristicos = new List<PontoTuristicoDTO>()
                {
                    new PontoTuristicoDTO()
                    {
                        Id = 3,
                        Nome = "Catedral de Nossa Senhora",
                        Descricao = "Uma grande catedral."
                    },
                    new PontoTuristicoDTO()
                    {
                        Id = 4,
                        Nome = "Zoo de Antuérpia",
                        Descricao = "Um grande zoológico."
                    }
                }
            },
            new CidadeDTO()
            {
                Id = 3,
                Nome = "Paris",
                Descricao = "Aquele com aquela grande torre.",
                PontosTuristicos = new List<PontoTuristicoDTO>()
                {
                    new PontoTuristicoDTO()
                    {
                        Id = 5,
                        Nome = "Torre Eiffel",
                        Descricao = "Uma grande torre."
                    },
                    new PontoTuristicoDTO()
                    {
                        Id = 6,
                        Nome = "O Louvre",
                        Descricao = "Um grande museu."
                    }
                }
            }
        };
    }
}