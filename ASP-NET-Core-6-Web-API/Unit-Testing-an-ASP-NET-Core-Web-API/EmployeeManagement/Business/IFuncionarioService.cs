using EmployeeManagement.Business.EventArguments; // Argumentos de eventos usados no domínio de negócios
using EmployeeManagement.DataAccess.Entities; // Entidades usadas para acesso a dados

namespace EmployeeManagement.Business;

// Interface para o serviço de gerenciamento de funcionários
public interface IFuncionarioService
{
    // Evento disparado quando um funcionário está ausente
    event EventHandler<FuncionarioAusenteEventArgs>? FuncionarioAusente;
    
    // Adiciona um funcionário interno de forma assíncrona
    Task AdicionarFuncionarioInternoAsync(FuncionarioInterno funcionarioInterno);

    // Registra a participação de um funcionário em um curso de forma assíncrona
    Task RegistrarParticipacaoCursoAsync(FuncionarioInterno funcionario, Curso cursoParticipado);
    
    // Cria um funcionário externo e retorna a instância criada
    FuncionarioExterno CriarFuncionarioExterno(string primeiroNome, string sobrenome, string empresa);

    // Cria um funcionário interno de forma síncrona e retorna a instância criada
    FuncionarioInterno CriarFuncionarioInterno(string primeiroNome, string sobrenome);

    // Cria um funcionário interno de forma assíncrona e retorna a instância criada
    Task<FuncionarioInterno> CriarFuncionarioInternoAsync(string primeiroNome, string sobrenome);

    // Busca um funcionário interno pelo ID de forma síncrona
    FuncionarioInterno? BuscarFuncionarioInterno(Guid funcionarioId);

    // Busca um funcionário interno pelo ID de forma assíncrona
    Task<FuncionarioInterno?> BuscarFuncionarioInternoAsync(Guid funcionarioId);

    // Busca todos os funcionários internos de forma assíncrona
    Task<IEnumerable<FuncionarioInterno>> BuscarFuncionariosInternosAsync();

    // Aplica um aumento mínimo ao salário de um funcionário de forma assíncrona
    Task AplicarAumentoMinimoAsync(FuncionarioInterno funcionario);

    // Aplica um aumento específico ao salário de um funcionário de forma assíncrona
    Task AplicarAumentoAsync(FuncionarioInterno funcionario, int aumento);

    // Notifica a ausência de um funcionário
    void NotificarAusencia(Funcionario funcionario);
}