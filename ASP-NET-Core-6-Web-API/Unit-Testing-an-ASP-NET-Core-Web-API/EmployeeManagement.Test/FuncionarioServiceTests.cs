using EmployeeManagement.Business; // Importa as classes de lógica de negócios
using EmployeeManagement.Business.EventArguments; // Argumentos de eventos utilizados no serviço
using EmployeeManagement.Business.Exceptions; // Exceções personalizadas utilizadas no serviço
using EmployeeManagement.DataAccess.Entities; // Entidades de acesso a dados
using EmployeeManagement.Services.Test;
using EmployeeManagement.Test.Fixtures; // Serviços de teste

namespace EmployeeManagement.Test;

// Classe de testes para FuncionarioService
public class FuncionarioServiceTests : IClassFixture<FuncionarioServiceFixture>
{
    private readonly FuncionarioServiceFixture _funcionarioServiceFixture;

    public FuncionarioServiceTests(FuncionarioServiceFixture funcionarioServiceFixture)
    {
        _funcionarioServiceFixture = funcionarioServiceFixture;
    }

    [Fact] // Indica que este método é um teste unitário
    public void CriarFuncionarioInterno_FuncionarioInternoCriado_DeveTerParticipadoDoPrimeiroCursoObrigatorio_ComObjeto()
    {
        // Arrange - Preparação do ambiente de teste
        var cursoObrigatorio = _funcionarioServiceFixture.GerenciamentoFuncionarioDadosTesteRepository.ObterCurso(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

        // Act - Ação de criar um funcionário interno
        var funcionarioInterno = _funcionarioServiceFixture.FuncionarioService.CriarFuncionarioInterno("Brooklyn", "Cannon");

        // Assert - Verificação se o funcionário participou do curso obrigatório
        Assert.Contains(cursoObrigatorio, funcionarioInterno.CursosParticipados);
    }

    [Fact] // Indica que este método é um teste unitário
    public void CriarFuncionarioInterno_FuncionarioInternoCriado_DeveTerParticipadoDoPrimeiroCursoObrigatorio_ComPredicado()
    {
        // Arrange - Preparação do ambiente de teste

        // Act - Ação de criar um funcionário interno
        var funcionarioInterno = _funcionarioServiceFixture.FuncionarioService.CriarFuncionarioInterno("Brooklyn", "Cannon");

        // Assert - Verificação se o funcionário participou do curso obrigatório
        Assert.Contains(funcionarioInterno.CursosParticipados, curso => curso.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
    }

    [Fact] // Indica que este método é um teste unitário
    public void CriarFuncionarioInterno_FuncionarioInternoCriado_DeveTerParticipadoDoSegundoCursoObrigatorio_ComPredicado()
    {
        // Arrange - Preparação do ambiente de teste

        // Act - Ação de criar um funcionário interno
        var funcionarioInterno = _funcionarioServiceFixture.FuncionarioService.CriarFuncionarioInterno("Brooklyn", "Cannon");

        // Assert - Verificação se o funcionário participou do curso obrigatório
        Assert.Contains(funcionarioInterno.CursosParticipados, curso => curso.Id == Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));
    }

    [Fact] // Indica que este método é um teste unitário
    public void CriarFuncionarioInterno_FuncionarioInternoCriado_CursosParticipadosDevemCorresponderAosCursosObrigatorios()
    {
        // Arrange - Preparação do ambiente de teste
        var cursosObrigatorios = _funcionarioServiceFixture.GerenciamentoFuncionarioDadosTesteRepository.ObtemCursos(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"), Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        // Act - Ação de criar um funcionário interno
        var funcionarioInterno = _funcionarioServiceFixture.FuncionarioService.CriarFuncionarioInterno("Brooklyn", "Cannon");

        // Assert - Verificação se os cursos participados pelo funcionário correspondem aos cursos obrigatórios
        Assert.Equal(cursosObrigatorios, funcionarioInterno.CursosParticipados);
    }

    [Fact] // Indica que este método é um teste unitário
    public void CriarFuncionarioInterno_FuncionarioInternoCriado_CursosParticipadosNaoDevemSerNovos()
    {
        // Arrange - Preparação do ambiente de teste

        // Act - Ação de criar um funcionário interno
        var funcionarioInterno = _funcionarioServiceFixture.FuncionarioService.CriarFuncionarioInterno("Brooklyn", "Cannon");

        // Assert - Verificação se os cursos participados pelo funcionário não são novos
        Assert.All(funcionarioInterno.CursosParticipados, course => Assert.False(course.EhNovo));
    }

    [Fact] // Indica que este método é um teste unitário
    public async Task CriarFuncionarioInterno_FuncionarioInternoCriado_CursosParticipadosDevemCorresponderAosCursosObrigatorios_Async()
    {
        // Arrange - Preparação do ambiente de teste
        var cursosObrigatorios = await _funcionarioServiceFixture.GerenciamentoFuncionarioDadosTesteRepository.ObterCursosAsync(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"), Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        // Act - Ação de criar um funcionário interno
        var funcionarioInterno = await _funcionarioServiceFixture.FuncionarioService.CriarFuncionarioInternoAsync("Brooklyn", "Cannon");

        // Assert - Verificação se os cursos participados pelo funcionário correspondem aos cursos obrigatórios
        Assert.Equal(cursosObrigatorios, funcionarioInterno.CursosParticipados);
    }

    [Fact]
    public async Task DarAumento_AumentoAbaixoDoMinimo_AumentoInvalidoFuncionarioExceptionDeveSerLancada()
    {
        // Arrange 
        var internalEmployee = new FuncionarioInterno("Brooklyn", "Cannon", 5, 3000, false, 1);

        // Act & Assert
        await Assert.ThrowsAsync<AumentoInvalidoFuncionarioException>(async () =>
            await _funcionarioServiceFixture.FuncionarioService.AplicarAumentoAsync(internalEmployee, 50)
        );
    }

    //[Fact]
    //public void GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionMustBeThrown_Mistake()
    //{
    //    // Arrange 
    //    var employeeService = new EmployeeService(
    //        new EmployeeManagementTestDataRepository(),
    //        new EmployeeFactory());
    //    var internalEmployee = new InternalEmployee(
    //        "Brooklyn", "Cannon", 5, 3000, false, 1);

    //    // Act & Assert
    //    Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
    //        async () =>
    //        await employeeService.GiveRaiseAsync(internalEmployee, 50)
    //        );
    //}

    [Fact]
    public void NotificarAusencia_FuncionarioEstaAusente_FuncionarioAusenteDeveSerAcionado()
    {
        // Arrange 
        var funcionarioInterno = new FuncionarioInterno("Brooklyn", "Cannon", 5, 3000, false, 1);

        // Act & Assert
        Assert.Raises<FuncionarioAusenteEventArgs>(
           handler => _funcionarioServiceFixture.FuncionarioService.FuncionarioAusente += handler,
           handler => _funcionarioServiceFixture.FuncionarioService.FuncionarioAusente -= handler,
           () => _funcionarioServiceFixture.FuncionarioService.NotificarAusencia(funcionarioInterno));
    }
}
