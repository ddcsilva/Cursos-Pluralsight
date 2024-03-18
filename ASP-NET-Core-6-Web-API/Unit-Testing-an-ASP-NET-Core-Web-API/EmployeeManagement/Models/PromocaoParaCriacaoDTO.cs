namespace EmployeeManagement.Models;

// Modelo de Transferência de Dados (DTO) para a criação de promoções de funcionários
public class PromocaoParaCriacaoDTO
{
    // Identificador único do funcionário a ser promovido
    public Guid FuncionarioId { get; set; }
}
