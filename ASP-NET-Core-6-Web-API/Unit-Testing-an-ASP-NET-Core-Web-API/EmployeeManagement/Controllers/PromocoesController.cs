using EmployeeManagement.Business; // Lógica de negócios do sistema de gerenciamento de funcionários
using EmployeeManagement.Models; // Modelos de dados usados na aplicação
using Microsoft.AspNetCore.Mvc; // Funcionalidades de controle MVC para ASP.NET Core

namespace EmployeeManagement.Controllers;

[Route("api/promocoes")]
[ApiController]
public class PromocoesController : ControllerBase
{
    private readonly IFuncionarioService _funcionarioService; // Serviço para operações de funcionários
    private readonly IPromocaoService _promocaoService; // Serviço para operações de promoção de funcionários

    // Construtor que recebe os serviços de funcionários e promoções via injeção de dependência
    public PromocoesController(IFuncionarioService funcionarioService, IPromocaoService promocaoService)
    {
        _funcionarioService = funcionarioService;
        _promocaoService = promocaoService;
    }

    // Método POST para criar uma promoção para um funcionário
    [HttpPost]
    public async Task<IActionResult> CriarPromocao(PromocaoParaCriacaoDTO promocaoParaCriacaoDTO)
    {
        // Busca o funcionário interno a ser promovido de forma assíncrona
        var funcionarioInternoParaPromover = await _funcionarioService.BuscarFuncionarioInternoAsync(promocaoParaCriacaoDTO.FuncionarioId);

        // Verifica se o funcionário existe
        if (funcionarioInternoParaPromover == null)
        {
            return BadRequest(); // Retorna erro se o funcionário não for encontrado
        }

        // Tenta promover o funcionário
        if (await _promocaoService.PromoverFuncionarioInternoAsync(funcionarioInternoParaPromover))
        {
            // Retorna sucesso com os detalhes da promoção se a promoção for bem-sucedida
            return Ok(new PromocaoResponseDTO() { FuncionarioId = funcionarioInternoParaPromover.Id, NivelCargo = funcionarioInternoParaPromover.NivelCargo });
        }
        else
        {
            // Retorna erro se o funcionário não for elegível para promoção
            return BadRequest("Funcionário não elegível para promoção.");
        }              
    }
}
