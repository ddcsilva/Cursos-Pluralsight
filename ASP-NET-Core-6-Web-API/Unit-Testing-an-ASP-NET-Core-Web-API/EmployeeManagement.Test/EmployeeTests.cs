using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test;

public class EmployeeTests
{
    [Fact]
    public void EmployeeFullNamePropertyGetter_InputFirstAndLastName_FullNameIsConcatenation()
    {
        // Arrange
        var employee = new InternalEmployee("Danilo", "Silva", 0, 2500, false, 1);

        // Act
        employee.FirstName = "Rosana";
        employee.LastName = "Silva";

        // Assert
        Assert.Equal("Rosana Silva", employee.FullName, ignoreCase: true);
    }

    [Fact]
    public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameStartsWithFirstName()
    {
        // Arrange
        var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

        // Act
        employee.FirstName = "Lucia";
        employee.LastName = "Shelton";

        // Assert
        Assert.StartsWith(employee.FirstName, employee.FullName);
    }

    [Fact]
    public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameEndsWithFirstName()
    {
        // Arrange
        var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

        // Act
        employee.FirstName = "Lucia";
        employee.LastName = "Shelton";

        // Assert
        Assert.EndsWith(employee.LastName, employee.FullName);
    }

    [Fact]
    public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameContainsPartOfConcatenation()
    {
        // Arrange
        var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

        // Act
        employee.FirstName = "Lucia";
        employee.LastName = "Shelton";

        // Assert
        Assert.Contains("ia Sh", employee.FullName);
    }

    [Fact]
    public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameSoundsLikeConcatenation()
    {
        // Arrange
        var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

        // Act
        employee.FirstName = "Lucia";
        employee.LastName = "Shelton";

        // Assert
        Assert.Matches("Lu(c|s|z)ia Shel(t|d)on", employee.FullName);
    }
}