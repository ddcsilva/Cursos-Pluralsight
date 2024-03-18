namespace EmployeeManagement.Business.Exceptions;

// Classe de exceção personalizada que representa um erro específico:
// um aumento salarial inválido para um funcionário.
public class AumentoInvalidoFuncionarioException : Exception
{
    // Propriedade somente leitura que armazena o valor do aumento considerado inválido.
    public int AumentoInvalido { get; private set; }

    // Construtor que inicializa uma nova instância da classe AumentoInvalidoFuncionarioException com uma mensagem de erro específica e o valor do aumento inválido.
    public AumentoInvalidoFuncionarioException(string mensagem, int aumento): base(mensagem)
    {
        AumentoInvalido = aumento; // Atribui o valor do aumento à propriedade AumentoInvalido.
    }
}
