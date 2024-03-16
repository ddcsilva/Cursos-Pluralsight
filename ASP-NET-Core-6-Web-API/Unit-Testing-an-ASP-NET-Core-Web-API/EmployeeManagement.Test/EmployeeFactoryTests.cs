using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test;

public class EmployeeFactoryTests
{
    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
    {
        var employeeFactory = new EmployeeFactory();
        var employee = (InternalEmployee)employeeFactory.CreateEmployee("Danilo", "Silva");

        Assert.Equal(2500, employee.Salary);
    }

    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
    {
        // Arrange
        var employeeFactory = new EmployeeFactory();

        // Act
        var employee = (InternalEmployee)employeeFactory.CreateEmployee("Danilo", "Silva");

        // Assert
        Assert.True(employee.Salary >= 2500 && employee.Salary <= 3500, "O salário não está na faixa aceitável.");
    }

    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_Alternative()
    {
        // Arrange
        var employeeFactory = new EmployeeFactory();

        // Act
        var employee = (InternalEmployee)employeeFactory.CreateEmployee("Danilo", "Silva");

        // Assert
        Assert.True(employee.Salary >= 2500);
        Assert.True(employee.Salary <= 3500);
    }

    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWithInRange()
    {
        // Arrange
        var employeeFactory = new EmployeeFactory();

        // Act
        var employee = (InternalEmployee)employeeFactory.CreateEmployee("Danilo", "Silva");

        // Assert
        Assert.InRange(employee.Salary, 2500, 3500);
    }

    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500_PrecisionExample()
    {
        // Arrange
        var employeeFactory = new EmployeeFactory();

        // Act
        var employee = (InternalEmployee)employeeFactory.CreateEmployee("Danilo", "Silva");
        employee.Salary = 2500.123m;

        // Assert
        Assert.Equal(2500, employee.Salary, 0);
    }
}
