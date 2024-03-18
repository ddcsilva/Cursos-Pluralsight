using AutoMapper; // Usado para mapear entre tipos de objetos de forma eficiente
using EmployeeManagement.Business; // Lógica de negócios específica do gerenciamento de funcionários
using EmployeeManagement.Models; // Modelos de dados usados na aplicação
using Microsoft.AspNetCore.Mvc; // Funcionalidades de controle MVC para ASP.NET Core

namespace EmployeeManagement.Controllers;

[Route("api/funcionariosinternos")]
[ApiController]
public class FuncionariosInternosController : ControllerBase
{
    private readonly IFuncionarioService _funcionarioService; // Serviço para operações de funcionários
    private readonly IMapper _mapper; // Instância do AutoMapper para mapeamento de objetos

    // Construtor que recebe o serviço de funcionários e o mapeador via injeção de dependência
    public FuncionariosInternosController(IFuncionarioService funcionarioService, IMapper mapper)
    {
        _funcionarioService = funcionarioService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FuncionarioInternoDTO>>> ObterFuncionariosInternos()
    {
        // Busca os funcionários internos de forma assíncrona
        var funcionariosInternos = await _funcionarioService.BuscarFuncionariosInternosAsync();

        // Mapeia manualmente os funcionários para DTOs
        var funcionarioInternoDtos = funcionariosInternos.Select(e => new FuncionarioInternoDTO()
        {
            Id = e.Id,
            PrimeiroNome = e.PrimeiroNome,
            Sobrenome = e.Sobrenome,
            Salario = e.Salario,
            BonusSugerido = e.BonusSugerido,
            AnosDeServico = e.AnosDeServico
        });

        // Retorna a lista de DTOs como resposta HTTP 200 OK
        return Ok(funcionarioInternoDtos);
    }

    // Método GET para buscar um funcionário interno específico pelo ID
    [HttpGet("{funcionarioId}", Name = "ObterFuncionarioInterno")]
    public async Task<ActionResult<FuncionarioInternoDTO>> ObterFuncionarioInterno(Guid? funcionarioId)
    {
        if (!funcionarioId.HasValue)
        {
            return NotFound(); // Retorna HTTP 404 se o ID não for fornecido
        }

        var funcionarioInterno = await _funcionarioService.BuscarFuncionarioInternoAsync(funcionarioId.Value);
        if (funcionarioInterno == null)
        {
            return NotFound(); // Retorna HTTP 404 se o funcionário não for encontrado
        }

        return Ok(_mapper.Map<FuncionarioInternoDTO>(funcionarioInterno)); // Retorna o funcionário mapeado como DTO
    }

    // Método POST para criar um novo funcionário interno
    [HttpPost]
    public async Task<ActionResult<FuncionarioInternoDTO>> CriarFuncionarioInterno(FuncionarioInternoParaCriacaoDTO funcionarioInternoParaCriacaoDTO)
    {
        // Cria uma entidade de funcionário interno com os valores fornecidos via requisição POST
        var funcionarioInterno = await _funcionarioService.CriarFuncionarioInternoAsync(funcionarioInternoParaCriacaoDTO.PrimeiroNome, funcionarioInternoParaCriacaoDTO.Sobrenome);

        // Persiste o funcionário no banco de dados
        await _funcionarioService.AdicionarFuncionarioInternoAsync(funcionarioInterno);

        // Retorna o funcionário criado mapeado para um DTO
        return CreatedAtAction("ObterFuncionarioInterno", _mapper.Map<FuncionarioInternoDTO>(funcionarioInterno), new { employeeId = funcionarioInterno.Id });
    }
}
