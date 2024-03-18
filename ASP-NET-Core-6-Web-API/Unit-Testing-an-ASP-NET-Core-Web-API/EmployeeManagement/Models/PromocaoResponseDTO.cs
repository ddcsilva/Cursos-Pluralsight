namespace EmployeeManagement.Models;

// Modelo de Transferência de Dados (DTO) para a resposta de operações de promoção de funcionários
public class PromocaoResponseDTO
{
    // Identificador único do funcionário que foi promovido
    public Guid FuncionarioId { get; set; }

    // Novo nível de cargo do funcionário após a promoção
    public int NivelCargo { get; set; }
}
