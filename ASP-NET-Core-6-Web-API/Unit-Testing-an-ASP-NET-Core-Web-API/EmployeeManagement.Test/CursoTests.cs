using EmployeeManagement.DataAccess.Entities; // Entidades de acesso a dados

namespace EmployeeManagement.Test;

// Classe de testes para a entidade Curso
public class CursoTests
{
    [Fact]
    public void ConstrutorCurso_CriarCurso_EhNovoDeveSerVerdadeiro()
    {
        // Arrange - Preparação do ambiente de teste (neste caso, não há necessidade de preparação prévia)

        // Act - Ação a ser testada
        var curso = new Curso("Fundamentos de C#"); // Cria uma instância de Curso

        // Assert - Verificação dos resultados do teste
        Assert.True(curso.EhNovo); // Verifica se a propriedade EhNovo do curso é verdadeira após a criação
    }
}