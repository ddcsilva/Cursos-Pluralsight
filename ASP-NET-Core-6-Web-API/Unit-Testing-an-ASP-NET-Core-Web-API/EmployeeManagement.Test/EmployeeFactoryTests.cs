using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test;

public class EmployeeFactoryTests
{
    [Fact]
    public void CriarFuncionario_ConstrutorInternoFuncionario_SalarioDeveSer2500()
    {
        var funcionarioFactory = new EmployeeFactory();
        var funcionario = (InternalEmployee)funcionarioFactory.CreateEmployee("Danilo", "Silva");

        Assert.Equal(2500, funcionario.Salary);
    }
}
