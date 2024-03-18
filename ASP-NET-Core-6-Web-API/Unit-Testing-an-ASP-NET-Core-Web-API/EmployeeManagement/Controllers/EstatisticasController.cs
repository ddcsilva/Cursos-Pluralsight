using AutoMapper; // Usado para mapear entre tipos de objetos de forma eficiente
using EmployeeManagement.Models; // Modelos de dados usados na aplicação
using Microsoft.AspNetCore.Http.Features; // Funcionalidades HTTP específicas para o ASP.NET Core
using Microsoft.AspNetCore.Mvc; // Funcionalidades de controle MVC para ASP.NET Core

namespace EmployeeManagement.Controllers;

[Route("api/estatisticas")]
[ApiController]
public class EstatisticasController : ControllerBase
{
    private readonly IMapper _mapper; // Instância do AutoMapper para mapeamento de objetos

    // Construtor que recebe um mapeador via injeção de dependência
    public EstatisticasController(IMapper mapper)
    {
        _mapper = mapper;
    }

    // Método GET para obter estatísticas
    [HttpGet] 
    public ActionResult<EstatisticasDTO> ObterEstatisticas()
    {
        // Obtém a funcionalidade de conexão HTTP do contexto atual
        var recursoConexaoHttp = HttpContext.Features.Get<IHttpConnectionFeature>();

        // Mapeia o recurso de conexão HTTP para um DTO de estatísticas e retorna
        return Ok(_mapper.Map<EstatisticasDTO>(recursoConexaoHttp));
    }
}
