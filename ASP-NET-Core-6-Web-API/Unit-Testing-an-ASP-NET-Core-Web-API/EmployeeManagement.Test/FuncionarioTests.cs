using EmployeeManagement.DataAccess.Entities; // Importa as entidades de acesso a dados

namespace EmployeeManagement.Test;

// Classe de testes para a entidade Funcionario
public class FuncionarioTests
{
    [Fact] // Indica que este m�todo � um teste unit�rio
    public void PropriedadeNomeCompleto_InserirPrimeiroESobrenome_NomeCompletoEConcatenacao()
    {
        // Arrange - Cria uma inst�ncia de FuncionarioInterno
        var employee = new FuncionarioInterno("Danilo", "Silva", 0, 2500, false, 1);

        // Act - Modifica o primeiro nome e sobrenome do funcion�rio
        employee.PrimeiroNome = "Rosana";
        employee.Sobrenome = "Silva";

        // Assert - Verifica se o NomeCompleto � a concatena��o do primeiro nome e sobrenome
        Assert.Equal("Rosana Silva", employee.NomeCompleto, ignoreCase: true);
    }

    [Fact] // Indica que este m�todo � um teste unit�rio
    public void PropriedadeNomeCompleto_InserirPrimeiroESobrenome_NomeCompletoComecaComPrimeiroNome()
    {
        // Arrange - Cria uma inst�ncia de FuncionarioInterno
        var funcionario = new FuncionarioInterno("Kevin", "Dockx", 0, 2500, false, 1);

        // Act - Modifica o primeiro nome e sobrenome do funcion�rio
        funcionario.PrimeiroNome = "Lucia";
        funcionario.Sobrenome = "Shelton";

        // Assert - Verifica se o NomeCompleto come�a com o primeiro nome
        Assert.StartsWith(funcionario.PrimeiroNome, funcionario.NomeCompleto);
    }

    [Fact] // Indica que este m�todo � um teste unit�rio
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

    [Fact] // Indica que este m�todo � um teste unit�rio
    public void PropriedadeNomeCompleto_InserirPrimeiroESobrenome_NomeCompletoContemParteDaConcatenacao()
    {
        // Arrange
        var funcionario = new FuncionarioInterno("Kevin", "Dockx", 0, 2500, false, 1);

        // Act
        funcionario.PrimeiroNome = "Lucia";
        funcionario.Sobrenome = "Shelton";

        // Assert - Verifica se o NomeCompleto cont�m uma parte espec�fica da concatena��o
        Assert.Contains("ia Sh", funcionario.NomeCompleto);
    }

    [Fact] // Indica que este m�todo � um teste unit�rio
    public void PropriedadeNomeCompleto_InserirPrimeiroESobrenome_NomeCompletoSoaComoConcatenacao()
    {
        // Arrange
        var funcionario = new FuncionarioInterno("Kevin", "Dockx", 0, 2500, false, 1);

        // Act
        funcionario.PrimeiroNome = "Lucia";
        funcionario.Sobrenome = "Shelton";

        // Assert - Verifica se o NomeCompleto se encaixa em um padr�o de som espec�fico
        Assert.Matches("Lu(c|s|z)ia Shel(t|d)on", funcionario.NomeCompleto);
    }
}