using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.DataAccess.Services
{
    public interface IGerenciamentoFuncionarioRepository
    {
        Task<IEnumerable<FuncionarioInterno>> ObterFuncionariosInternosAsync();

        FuncionarioInterno? ObterFuncionarioInterno(Guid employeeId);

        Task<FuncionarioInterno?> ObterFuncionarioInternoAsync(Guid employeeId);

        Task<Curso?> GetCourseAsync(Guid courseId);

        Curso? ObterCurso(Guid courseId);

        List<Curso> ObtemCursos(params Guid[] courseIds);

        Task<List<Curso>> ObterCursosAsync(params Guid[] courseIds);

        void AdicionarFuncionarioInterno(FuncionarioInterno internalEmployee);

        Task SaveChangesAsync();
    }
}