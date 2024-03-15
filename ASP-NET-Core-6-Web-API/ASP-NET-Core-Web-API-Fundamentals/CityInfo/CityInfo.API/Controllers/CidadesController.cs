using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers;

[ApiController]
[Route("api/cidades")]
public class CidadesController : ControllerBase
{
    [HttpGet]
    public JsonResult ObterCidades()
    {
        return new JsonResult(new List<object>
        {
            new { Id = 1, Nome = "New York City" },
            new { Id = 2, Nome = "Antwerp" }
        });
    }
}
