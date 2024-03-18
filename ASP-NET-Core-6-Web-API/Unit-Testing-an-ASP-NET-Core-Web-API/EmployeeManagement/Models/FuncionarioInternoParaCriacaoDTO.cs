using System.ComponentModel.DataAnnotations; // Usado para definir atributos de validação de dados

namespace EmployeeManagement.Models;

// Modelo de Transferência de Dados (DTO) para a criação de um Funcionário Interno
public class FuncionarioInternoParaCriacaoDTO
{
    [Required] // Indica que o campo é obrigatório
    [MaxLength(100)] // Limita o comprimento máximo do primeiro nome a 100 caracteres
    public string PrimeiroNome { get; set; } = string.Empty;

    [Required] // Indica que o campo é obrigatório
    [MaxLength(100)] // Limita o comprimento máximo do sobrenome a 100 caracteres
    public string Sobrenome { get; set; } = string.Empty;           
}
