using EmployeeManagement.DataAccess.Entities; // Uso de entidades do acesso a dados do gerenciamento de funcionários

namespace EmployeeManagement.Business;

/// <summary>
/// Fábrica para criação de funcionários
/// </summary>
public class FuncionarioFactory
{
    /// <summary>
    /// Cria um funcionário
    /// </summary>
    /// <param name="primeiroNome">Primeiro nome do funcionário</param>
    /// <param name="sobrenome">Sobrenome do funcionário</param>
    /// <param name="empresa">Nome da empresa do funcionário, se aplicável</param>
    /// <param name="ehExterno">Indica se o funcionário é externo</param>
    /// <returns>Um novo objeto Funcionario</returns>
    public virtual Funcionario CriarFuncionario(string primeiroNome, string sobrenome, string? empresa = null, bool ehExterno = false)
    {
        if (string.IsNullOrEmpty(primeiroNome))
        {
            throw new ArgumentException($"'{nameof(primeiroNome)}' não pode ser nulo ou vazio.", nameof(primeiroNome));
        }

        if (string.IsNullOrEmpty(sobrenome))
        {
            throw new ArgumentException($"'{nameof(sobrenome)}' não pode ser nulo ou vazio.", nameof(sobrenome));
        }

        if (empresa == null && ehExterno)
        {
            throw new ArgumentException($"'{nameof(empresa)}' não pode ser nulo ou vazio quando o funcionário é externo.", nameof(empresa));
        }

        if (ehExterno)
        {
            // Sabemos que a empresa não será nula aqui devido à verificação acima, então
            // podemos usar o operador de desanulação para informar ao compilador sobre isso
            return new FuncionarioExterno(primeiroNome, sobrenome, empresa = null!);
        }

        // cria um novo funcionário com valores padrão
        return new FuncionarioInterno(primeiroNome, sobrenome, 0, 2500, false, 1);
    }
}
