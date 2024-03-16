namespace CityInfo.API.Models;

public class CidadeDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }

    public int NumeroDePontosTuristicos => PontosTuristicos.Count;

    public ICollection<PontoTuristicoDTO> PontosTuristicos { get; set; } = new List<PontoTuristicoDTO>();
}
