using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers;

[ApiController]
[Route("api/cidades/{cidadeId}/pontosturisticos")]
public class PontoTuristicoController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<PontoTuristicoDTO>> ObterPontosTuristicos(int cidadeId)
    {
        var cidadeEncontrada = CidadesStore.Current.Cidades.FirstOrDefault(c => c.Id == cidadeId);

        if (cidadeEncontrada == null)
        {
            return NotFound();
        }

        return Ok(cidadeEncontrada.PontosTuristicos);
    }

    [HttpGet("{id}")]
    public ActionResult<PontoTuristicoDTO> ObterPontoTuristico(int cidadeId, int id)
    {
        var cidadeEncontrada = CidadesStore.Current.Cidades.FirstOrDefault(c => c.Id == cidadeId);

        if (cidadeEncontrada == null)
        {
            return NotFound();
        }

        var pontoTuristicoEncontrado = cidadeEncontrada.PontosTuristicos.FirstOrDefault(p => p.Id == id);

        if (pontoTuristicoEncontrado == null)
        {
            return NotFound();
        }

        return Ok(pontoTuristicoEncontrado);
    }
}