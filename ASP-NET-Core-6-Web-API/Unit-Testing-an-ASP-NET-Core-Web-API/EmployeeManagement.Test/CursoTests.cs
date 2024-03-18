using EmployeeManagement.DataAccess.Entities; // Entidades de acesso a dados

namespace EmployeeManagement.Test;

// Classe de testes para a entidade Curso
public class CursoTests
{
    [Fact]
    public void ConstrutorCurso_CriarCurso_EhNovoDeveSerVerdadeiro()
    {
        // Arrange - Prepara��o do ambiente de teste (neste caso, n�o h� necessidade de prepara��o pr�via)

        // Act - A��o a ser testada
        var curso = new Curso("Fundamentos de C#"); // Cria uma inst�ncia de Curso

        // Assert - Verifica��o dos resultados do teste
        Assert.True(curso.EhNovo); // Verifica se a propriedade EhNovo do curso � verdadeira ap�s a cria��o
    }
}