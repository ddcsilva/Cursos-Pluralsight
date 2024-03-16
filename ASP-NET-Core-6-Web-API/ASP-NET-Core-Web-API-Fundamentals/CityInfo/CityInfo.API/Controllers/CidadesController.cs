using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers;

[ApiController]
[Route("api/cidades")]
public class CidadesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CidadeDTO>> ObterCidades()
    {
        return Ok(CidadesStore.Current.Cidades);
    }

    [HttpGet("{id}")]
    public ActionResult<CidadeDTO> ObterCidade(int id)
    {
        var cidadeEncontrada = CidadesStore.Current.Cidades.FirstOrDefault(c => c.Id == id);

        if (cidadeEncontrada == null)
        {
            return NotFound();
        }

        return Ok(cidadeEncontrada);
    }
}
