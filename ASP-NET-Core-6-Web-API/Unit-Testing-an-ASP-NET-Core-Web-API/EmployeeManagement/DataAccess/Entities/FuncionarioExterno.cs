namespace EmployeeManagement.DataAccess.Entities;

// Define um funcionário externo, que herda da classe base Funcionario
public class FuncionarioExterno : Funcionario
{
    // Empresa associada ao funcionário externo
    public string Empresa { get; set; }

    // Construtor que inicializa um novo funcionário externo com primeiro nome, sobrenome e empresa
    public FuncionarioExterno(string primeiroNome, string sobrenome, string empresa) : base(primeiroNome, sobrenome) // Chama o construtor da classe base
    {
        Empresa = empresa; // Define a empresa do funcionário externo
    }
}
