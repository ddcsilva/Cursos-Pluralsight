using System.ComponentModel.DataAnnotations; // Usado para definir atributos de validação de dados
using System.ComponentModel.DataAnnotations.Schema; // Usado para definir atributos relacionados ao banco de dados

namespace EmployeeManagement.DataAccess.Entities;

// Define um funcionário interno, que herda da classe base Funcionario
public class FuncionarioInterno : Funcionario
{
    [Required] // Indica que o campo é obrigatório
    public int AnosDeServico { get; set; } // Número de anos que o funcionário trabalhou na empresa

    [NotMapped] // Indica que o campo não será mapeado para uma coluna no banco de dados
    public decimal BonusSugerido { get; set; } // Bônus sugerido para o funcionário, calculado com base em critérios específicos

    [Required] // Indica que o campo é obrigatório
    public decimal Salario { get; set; } // Salário do funcionário

    [Required] // Indica que o campo é obrigatório
    public bool AumentoMinimoConcedido { get; set; } // Indica se o aumento mínimo foi concedido ao funcionário

    // Lista de cursos que o funcionário participou
    public List<Curso> CursosParticipados { get; set; } = new List<Curso>();

    [Required] // Indica que o campo é obrigatório
    public int NivelCargo { get; set; } // Nível do cargo do funcionário na empresa

    // Construtor que inicializa um novo funcionário interno com informações específicas
    public FuncionarioInterno(string primeiroNome, string sobrenome, int anosDeServico, decimal salario, bool aumentoMinimoConcedido, int nivelCargo) : base(primeiroNome, sobrenome) // Chama o construtor da classe base Funcionario
    {
        AnosDeServico = anosDeServico;
        Salario = salario;
        AumentoMinimoConcedido = aumentoMinimoConcedido;
        NivelCargo = nivelCargo;
    }
}
