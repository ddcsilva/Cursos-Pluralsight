using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers;

[ApiController]
[Route("api/cidades")]
public class CidadesController : ControllerBase
{
    [HttpGet]
    public JsonResult ObterCidades()
    {
        return new JsonResult(CidadesStore.Current.Cidades);
    }

    [HttpGet("{id}")]
    public JsonResult ObterCidade(int id)
    {
        return new JsonResult(CidadesStore.Current.Cidades.FirstOrDefault(c => c.Id == id));
    }
}
