using System.ComponentModel.DataAnnotations; // Usado para definir atributos de validação de dados
using System.ComponentModel.DataAnnotations.Schema; // Usado para definir atributos relacionados ao banco de dados

namespace EmployeeManagement.DataAccess.Entities;

/// <summary>
/// Classe base para todos os funcionários.
/// </summary>
public abstract class Funcionario
{
    [Key] // Marca o campo como chave primária.
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configura o ID para ser gerado pelo banco de dados automaticamente.
    public Guid Id { get; set; } // Identificador único do funcionário.

    [Required] // Define o campo como obrigatório.
    [MaxLength(100)] // Limita o comprimento máximo do nome a 100 caracteres.
    public string PrimeiroNome { get; set; }

    [Required] // Define o campo como obrigatório.
    [MaxLength(100)] // Limita o comprimento máximo do sobrenome a 100 caracteres.
    public string Sobrenome { get; set; }

    [NotMapped] // Indica que o campo não deve ser mapeado para a base de dados.
    public string NomeCompleto
    {
        get { return $"{PrimeiroNome} {Sobrenome}"; } // Retorna o nome completo do funcionário.
    }

    // Construtor que inicializa um novo funcionário com primeiro nome e sobrenome.
    public Funcionario(string primeiroNome, string sobrenome)
    {
        PrimeiroNome = primeiroNome;
        Sobrenome = sobrenome;
    }
}
