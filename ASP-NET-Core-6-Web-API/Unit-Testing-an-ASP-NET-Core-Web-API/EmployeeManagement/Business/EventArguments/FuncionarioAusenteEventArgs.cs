namespace EmployeeManagement.Business.EventArguments;

// Classe de argumentos de evento para representar a situação em que um funcionário está ausente.
public class FuncionarioAusenteEventArgs : EventArgs
{
    // Propriedade somente leitura que armazena o ID do funcionário ausente.
    public Guid FuncionarioId { get; private set; }

    // Construtor que inicializa uma nova instância da classe FuncionarioAusenteEventArgs com o ID do funcionário especificado.
    // Parâmetro funcionarioId: O ID do funcionário que está ausente.
    public FuncionarioAusenteEventArgs(Guid funcionarioId)
    {
        FuncionarioId = funcionarioId;
    }
}
