using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test;

public class CourseTests
{
    [Fact]
    public void CourseConstructor_ConstructCourse_IsNewMustBeTrue()
    {
        // Arrange

        // Act
        var course = new Course("C# Fundamentals");

        // Assert
        Assert.True(course.IsNew);
    }
}