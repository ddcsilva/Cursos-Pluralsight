namespace CityInfo.API.Models;

public class CitiesDataStore
{
    public static CitiesDataStore Current { get; } = new CitiesDataStore();
    public List<CityDTO> Cities { get; set; }

    public CitiesDataStore()
    {
        Cities =
        [
            new CityDTO
            {
                Id = 1,
                Name = "New York City",
                Description = "The one with that big park."
            },
            new CityDTO
            {
                Id = 2,
                Name = "Antwerp",
                Description = "The one with the cathedral that was never really finished."
            },
            new CityDTO
            {
                Id = 3,
                Name = "Paris",
                Description = "The one with that big tower."
            }
        ];
    }
}
