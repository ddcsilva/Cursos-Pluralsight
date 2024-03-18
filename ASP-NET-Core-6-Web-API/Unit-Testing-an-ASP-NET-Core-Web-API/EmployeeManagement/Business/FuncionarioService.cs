using EmployeeManagement.Business.EventArguments; // Argumentos de eventos usados no domínio de negócios
using EmployeeManagement.Business.Exceptions; // Exceções personalizadas usadas no domínio de negócios
using EmployeeManagement.DataAccess.Entities; // Entidades usadas para acesso a dados
using EmployeeManagement.DataAccess.Services; // Serviços para operações de acesso a dados

namespace EmployeeManagement.Business;

// Classe de serviço para operações relacionadas a funcionários.
public class FuncionarioService : IFuncionarioService
{
    // IDs dos cursos obrigatórios: "Introdução à Empresa" e "Respeitando Seus Colegas"
    private Guid[] _cursosObrigatoriosIds = {
        Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
        Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e") 
    };

    private readonly IGerenciamentoFuncionarioRepository _repository; // Repositório para gerenciamento de funcionários
    private readonly FuncionarioFactory _funcionarioFactory;

    public event EventHandler<FuncionarioAusenteEventArgs>? FuncionarioAusente;

    public FuncionarioService(IGerenciamentoFuncionarioRepository repository,
        FuncionarioFactory funcionarioFactory)
    {
        _repository = repository;
        _funcionarioFactory = funcionarioFactory;
    }

    // Método assíncrono para registrar a participação de um funcionário em um curso
    public async Task RegistrarParticipacaoCursoAsync(FuncionarioInterno funcionario, Curso cursoParticipado)
    {
        var jaParticipou = funcionario.CursosParticipados.Any(c => c.Id == cursoParticipado.Id);

        if (jaParticipou)
        {
            return;
        }

        // Adiciona o curso à lista de cursos participados pelo funcionário
        funcionario.CursosParticipados.Add(cursoParticipado);

        // Salva as alterações no repositório
        await _repository.SaveChangesAsync();

        // Recalcula o bônus sugerido após a participação no curso
        funcionario.BonusSugerido = funcionario.AnosDeServico * funcionario.CursosParticipados.Count * 100;
    }

    // Método assíncrono para aplicar o aumento mínimo ao salário de um funcionário
    public async Task AplicarAumentoMinimoAsync(FuncionarioInterno funcionario)
    {
        funcionario.Salario += 100; // Aumenta o salário em 100
        funcionario.AumentoMinimoConcedido = true; // Marca que o aumento mínimo foi concedido

        // Salva as alterações no repositório
        await _repository.SaveChangesAsync();
    }

    // Método assíncrono para aplicar um aumento ao salário de um funcionário
    public async Task AplicarAumentoAsync(FuncionarioInterno funcionario, int aumento)
    {
        // O aumento deve ser pelo menos 100
        if (aumento < 100)
        {
            throw new AumentoInvalidoFuncionarioException("Aumento inválido: o aumento deve ser maior ou igual a 100.", aumento);
        }

        // Se o aumento mínimo já foi concedido anteriormente, o aumento deve ser maior que o mínimo
        if (funcionario.AumentoMinimoConcedido && aumento == 100)
        {
            throw new AumentoInvalidoFuncionarioException("Aumento inválido: o aumento mínimo não pode ser concedido duas vezes.", aumento);
        }

        if (aumento == 100)
        {
            await AplicarAumentoMinimoAsync(funcionario); // Aplica o aumento mínimo
        }
        else
        {
            funcionario.Salario += aumento; // Aplica o aumento especificado
            funcionario.AumentoMinimoConcedido = false; // Marca que o aumento mínimo não foi concedido
            await _repository.SaveChangesAsync(); // Salva as alterações no repositório
        }
    }

    // Método assíncrono para buscar um funcionário interno pelo ID
    public async Task<FuncionarioInterno?> BuscarFuncionarioInternoAsync(Guid funcionarioId)
    {
        var funcionario = await _repository.ObterFuncionarioInternoAsync(funcionarioId);

        if (funcionario != null)
        {
            // Calcula campos derivados, como o bônus sugerido
            funcionario.BonusSugerido = CalcularBonusSugerido(funcionario);
        }
        return funcionario;
    }

    // Método assíncrono para buscar todos os funcionários internos
    public async Task<IEnumerable<FuncionarioInterno>> BuscarFuncionariosInternosAsync()
    {
        var funcionarios = await _repository.ObterFuncionariosInternosAsync();

        foreach (var funcionario in funcionarios)
        {
            // Calcula campos derivados para cada funcionário
            funcionario.BonusSugerido = CalcularBonusSugerido(funcionario);
        }

        return funcionarios;
    }

    // Método síncrono para buscar um funcionário interno pelo ID
    public FuncionarioInterno? BuscarFuncionarioInterno(Guid funcionarioId)
    {
        var funcionario = _repository.ObterFuncionarioInterno(funcionarioId);

        if (funcionario != null)
        {
            // Calcula campos derivados, como o bônus sugerido
            funcionario.BonusSugerido = CalcularBonusSugerido(funcionario);
        }
        return funcionario;
    }

    // Método para criar um funcionário interno de forma síncrona
    public FuncionarioInterno CriarFuncionarioInterno(string primeiroNome, string sobrenome)
    {
        // Usa a fábrica para criar o objeto
        var funcionario = (FuncionarioInterno)_funcionarioFactory.CriarFuncionario(primeiroNome, sobrenome);

        // Aplica a lógica de negócios

        // Adiciona cursos obrigatórios frequentados por todos os novos funcionários durante o processo de contratação

        // Obtém esses cursos
        var cursosObrigatorios = _repository.ObtemCursos(_cursosObrigatoriosIds);

        // Adiciona-os para este funcionário
        foreach (var cursoObrigatorio in cursosObrigatorios)
        {
            funcionario.CursosParticipados.Add(cursoObrigatorio);
        }

        // Calcula o bônus sugerido
        funcionario.BonusSugerido = CalcularBonusSugerido(funcionario);
        return funcionario;
    }

    // Método assíncrono para criar um funcionário interno
    public async Task<FuncionarioInterno> CriarFuncionarioInternoAsync(string primeiroNome, string sobrenome)
    {
        // Usa a fábrica para criar o objeto
        var funcionario = (FuncionarioInterno)_funcionarioFactory.CriarFuncionario(primeiroNome, sobrenome);

        // Aplica a lógica de negócios

        // Adiciona cursos obrigatórios frequentados por todos os novos funcionários durante o processo de contratação

        // Obtém esses cursos
        var cursosObrigatorios = await _repository.ObterCursosAsync(_cursosObrigatoriosIds);

        // Adiciona-os para este funcionário
        foreach (var cursoObrigatorio in cursosObrigatorios)
        {
            funcionario.CursosParticipados.Add(cursoObrigatorio);
        }

        // Calcula o bônus sugerido
        funcionario.BonusSugerido = CalcularBonusSugerido(funcionario);
        return funcionario;
    }

    // Método para criar um funcionário externo
    public FuncionarioExterno CriarFuncionarioExterno(string primeiroNome, string sobrenome, string empresa)
    {
        // Cria um novo funcionário externo com valores padrão
        var funcionario = (FuncionarioExterno)_funcionarioFactory.CriarFuncionario(primeiroNome, sobrenome, empresa, true);

        // Não há cursos obrigatórios para funcionários externos, retorna-o
        return funcionario;
    }

    // Método assíncrono para adicionar um funcionário interno
    public async Task AdicionarFuncionarioInternoAsync(FuncionarioInterno funcionarioInterno)
    {
        _repository.AdicionarFuncionarioInterno(funcionarioInterno);
        await _repository.SaveChangesAsync();
    }

    // Método para notificar sobre a ausência de um funcionário
    public void NotificarAusencia(Funcionario funcionario)
    {
        // Funcionário está ausente. Outras partes do aplicativo podem responder a isso. Dispara o evento FuncionarioAusente
        OnFuncionarioAusente(new FuncionarioAusenteEventArgs(funcionario.Id));
    }

    // Método protegido virtual para disparar o evento de ausência do funcionário
    protected virtual void OnFuncionarioAusente(FuncionarioAusenteEventArgs eventArgs)
    {
        FuncionarioAusente?.Invoke(this, eventArgs);
    }

    // Método privado para calcular o bônus sugerido
    private int CalcularBonusSugerido(FuncionarioInterno funcionarioInterno)
    {
        // O bônus sugerido é baseado no número de anos de serviço e na quantidade de cursos frequentados
        if (funcionarioInterno.AnosDeServico == 0)
        {
            return funcionarioInterno.CursosParticipados.Count * 100;
        }
        else
        {
            return funcionarioInterno.AnosDeServico * funcionarioInterno.CursosParticipados.Count * 100;
        }
    }
}
