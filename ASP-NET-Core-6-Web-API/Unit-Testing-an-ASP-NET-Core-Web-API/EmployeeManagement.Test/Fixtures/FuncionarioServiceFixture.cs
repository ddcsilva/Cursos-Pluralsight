using EmployeeManagement.Business;
using EmployeeManagement.Services.Test;

namespace EmployeeManagement.Test.Fixtures;

public class FuncionarioServiceFixture : IDisposable
{
    public GerenciamentoFuncionarioDadosTesteRepository GerenciamentoFuncionarioDadosTesteRepository { get; }
    public FuncionarioService FuncionarioService { get; }

    public FuncionarioServiceFixture()
    {
        GerenciamentoFuncionarioDadosTesteRepository = new GerenciamentoFuncionarioDadosTesteRepository();
        FuncionarioService = new FuncionarioService(GerenciamentoFuncionarioDadosTesteRepository, new FuncionarioFactory());
    }

    public void Dispose()
    {
        // Limpe o código de configuração, se necessário
    }
}
