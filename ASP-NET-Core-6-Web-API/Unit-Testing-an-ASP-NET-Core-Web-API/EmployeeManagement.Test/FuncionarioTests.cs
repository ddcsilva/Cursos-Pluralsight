using EmployeeManagement.DataAccess.Entities; // Importa as entidades de acesso a dados

namespace EmployeeManagement.Test;

// Classe de testes para a entidade Funcionario
public class FuncionarioTests
{
    [Fact] // Indica que este método é um teste unitário
    public void PropriedadeNomeCompleto_InserirPrimeiroESobrenome_NomeCompletoEConcatenacao()
    {
        // Arrange - Cria uma instância de FuncionarioInterno
        var employee = new FuncionarioInterno("Danilo", "Silva", 0, 2500, false, 1);

        // Act - Modifica o primeiro nome e sobrenome do funcionário
        employee.PrimeiroNome = "Rosana";
        employee.Sobrenome = "Silva";

        // Assert - Verifica se o NomeCompleto é a concatenação do primeiro nome e sobrenome
        Assert.Equal("Rosana Silva", employee.NomeCompleto, ignoreCase: true);
    }

    [Fact] // Indica que este método é um teste unitário
    public void PropriedadeNomeCompleto_InserirPrimeiroESobrenome_NomeCompletoComecaComPrimeiroNome()
    {
        // Arrange - Cria uma instância de FuncionarioInterno
        var funcionario = new FuncionarioInterno("Kevin", "Dockx", 0, 2500, false, 1);

        // Act - Modifica o primeiro nome e sobrenome do funcionário
        funcionario.PrimeiroNome = "Lucia";
        funcionario.Sobrenome = "Shelton";

        // Assert - Verifica se o NomeCompleto começa com o primeiro nome
        Assert.StartsWith(funcionario.PrimeiroNome, funcionario.NomeCompleto);
    }

    [Fact] // Indica que este método é um teste unitário
    public void PropriedadeNomeCompleto_InserirPrimeiroESobrenome_NomeCompletoTerminaComSobrenome()
    {
        // Arrange
        var funcionario = new FuncionarioInterno("Kevin", "Dockx", 0, 2500, false, 1);

        // Act
        funcionario.PrimeiroNome = "Lucia";
        funcionario.Sobrenome = "Shelton";

        // Assert - Verifica se o NomeCompleto termina com o sobrenome
        Assert.EndsWith(funcionario.Sobrenome, funcionario.NomeCompleto);
    }

    [Fact] // Indica que este método é um teste unitário
    public void PropriedadeNomeCompleto_InserirPrimeiroESobrenome_NomeCompletoContemParteDaConcatenacao()
    {
        // Arrange
        var funcionario = new FuncionarioInterno("Kevin", "Dockx", 0, 2500, false, 1);

        // Act
        funcionario.PrimeiroNome = "Lucia";
        funcionario.Sobrenome = "Shelton";

        // Assert - Verifica se o NomeCompleto contém uma parte específica da concatenação
        Assert.Contains("ia Sh", funcionario.NomeCompleto);
    }

    [Fact] // Indica que este método é um teste unitário
    public void PropriedadeNomeCompleto_InserirPrimeiroESobrenome_NomeCompletoSoaComoConcatenacao()
    {
        // Arrange
        var funcionario = new FuncionarioInterno("Kevin", "Dockx", 0, 2500, false, 1);

        // Act
        funcionario.PrimeiroNome = "Lucia";
        funcionario.Sobrenome = "Shelton";

        // Assert - Verifica se o NomeCompleto se encaixa em um padrão de som específico
        Assert.Matches("Lu(c|s|z)ia Shel(t|d)on", funcionario.NomeCompleto);
    }
}