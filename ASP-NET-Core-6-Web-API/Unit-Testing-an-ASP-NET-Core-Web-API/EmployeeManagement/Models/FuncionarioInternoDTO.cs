namespace EmployeeManagement.Models;

// Modelo de Transferência de Dados (DTO) para Funcionário Interno
public class FuncionarioInternoDTO
{
    // Identificador único do funcionário
    public Guid Id { get; set; }

    // Primeiro nome do funcionário
    public string PrimeiroNome { get; set; } = string.Empty;

    // Sobrenome do funcionário
    public string Sobrenome { get; set; } = string.Empty;

    // Nome completo do funcionário, combinando primeiro nome e sobrenome
    public string NomeCompleto
    {
        get { return $"{PrimeiroNome} {Sobrenome}"; }
    }

    // Número de anos de serviço na empresa
    public int AnosDeServico { get; set; }

    // Bônus sugerido para o funcionário, baseado em critérios internos
    public decimal BonusSugerido { get; set; }

    // Salário atual do funcionário
    public decimal Salario { get; set; }

    // Indica se foi concedido um aumento mínimo ao funcionário
    public bool AumentoMinimoConcedido { get; set; }

    // Nível de cargo do funcionário dentro da empresa  
    public int NivelCargo { get; set; }
}
