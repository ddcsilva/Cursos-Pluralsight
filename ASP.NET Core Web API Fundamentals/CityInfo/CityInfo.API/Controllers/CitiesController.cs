using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers;

[ApiController]
public class CitiesController : ControllerBase
{
    public JsonResult GetCities()
    {
        return new JsonResult(new List<object>
        {
            new { Id = 1, Name = "New York City" },
            new { Id = 2, Name = "Antwerp" }
        });
    }
}
