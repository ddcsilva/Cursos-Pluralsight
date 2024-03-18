using EmployeeManagement.Business; // Contém as classes de lógica de negócios
using EmployeeManagement.DataAccess.Entities; // Entidades de acesso a dados

namespace EmployeeManagement.Test;

// Classe de testes para FuncionarioFactory
public class FuncionarioFactoryTests
{
    [Fact] // Indica que este método é um teste unitário
    public void CriarFuncionario_ConstruirFuncionarioInterno_SalarioDeveSer2500()
    {
        // Arrange - Cria uma instância de FuncionarioFactory
        var funcionarioFactory = new FuncionarioFactory();

        // Act - Chama o método CriarFuncionario da fábrica de funcionários
        var funcionario = (FuncionarioInterno)funcionarioFactory.CriarFuncionario("Danilo", "Silva");

        // Assert - Verifica se o salário do funcionário é 2500
        Assert.Equal(2500, funcionario.Salario);
    }

    [Fact] // Indica que este método é um teste unitário
    public void CriarFuncionario_ConstruirFuncionarioInterno_SalarioDeveEstarEntre2500E3500()
    {
        // Arrange - Cria uma instância de FuncionarioFactory
        var fabricaFuncionario = new FuncionarioFactory();

        // Act - Chama o método CriarFuncionario da fábrica de funcionários
        var funcionario = (FuncionarioInterno)fabricaFuncionario.CriarFuncionario("Danilo", "Silva");

        // Assert - Verifica se o salário do funcionário está entre 2500 e 3500
        Assert.True(funcionario.Salario >= 2500 && funcionario.Salario <= 3500, "O salário não está na faixa aceitável.");
    }

    [Fact] // Indica que este método é um teste unitário
    public void CriarFuncionario_ConstruirFuncionarioInterno_SalarioDeveEstarEntre2500E3500_Alternativa()
    {
        // Arrange - Cria uma instância de FuncionarioFactory
        var fabricaFuncionario = new FuncionarioFactory();

        // Act - Chama o método CriarFuncionario da fábrica de funcionários
        var funcionario = (FuncionarioInterno)fabricaFuncionario.CriarFuncionario("Danilo", "Silva");

        // Assert - Verifica se o salário do funcionário está entre 2500 e 3500
        Assert.True(funcionario.Salario >= 2500);
        Assert.True(funcionario.Salario <= 3500);
    }

    [Fact] // Indica que este método é um teste unitário
    public void CriarFuncionario_ConstruirFuncionarioInterno_SalarioDeveEstarEntre2500E3500_AlternativaComInRange()
    {
        // Arrange - Cria uma instância de FuncionarioFactory
        var fabricaFuncionario = new FuncionarioFactory();

        // Act - Chama o método CriarFuncionario da fábrica de funcionários
        var funcionario = (FuncionarioInterno)fabricaFuncionario.CriarFuncionario("Danilo", "Silva");

        // Assert - Verifica se o salário do funcionário está entre 2500 e 3500
        Assert.InRange(funcionario.Salario, 2500, 3500);
    }

    [Fact] // Indica que este método é um teste unitário
    public void CriarFuncionario_ConstruirFuncionarioInterno_SalarioDeveSer2500_ExemploPrecisao()
    {
        // Arrange - Cria uma instância de FuncionarioFactory
        var fabricaFuncionario = new FuncionarioFactory();

        // Act - Chama o método CriarFuncionario da fábrica de funcionários e define o salário como 2500.123
        var funcionario = (FuncionarioInterno)fabricaFuncionario.CriarFuncionario("Danilo", "Silva");
        funcionario.Salario = 2500.123m;

        // Assert - Verifica se o salário do funcionário é 2500
        Assert.Equal(2500, funcionario.Salario, 0);
    }

    [Fact]
    public void CreateEmployee_IsExternalIsTrue_ReturnTypeMustBeExternalEmployee()
    {
        // Arrange
        var factory = new FuncionarioFactory();

        // Act
        var employee = factory.CriarFuncionario("Kevin", "Dockx", "Marvin", true);

        // Assert
        Assert.IsType<FuncionarioExterno>(employee);
        //Assert.IsAssignableFrom<Employee>(employee);
    }
}
