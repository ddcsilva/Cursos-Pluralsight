using EmployeeManagement.DataAccess.DbContexts; // Contexto do banco de dados
using EmployeeManagement.DataAccess.Entities; // Entidades de acesso a dados
using Microsoft.EntityFrameworkCore; // Entity Framework Core

namespace EmployeeManagement.DataAccess.Services;

// Classe de repositório para gerenciar funcionários, implementando a interface de gerenciamento
public class GerenciamentoFuncionarioRepository : IGerenciamentoFuncionarioRepository
{
    private readonly FuncionarioDbContext _context; // Contexto do banco de dados

    // Construtor com injeção de dependência do contexto do banco de dados
    public GerenciamentoFuncionarioRepository(FuncionarioDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context)); // Verifica se o contexto é nulo
    }

    // Método assíncrono para obter todos os funcionários internos, incluindo seus cursos participados
    public async Task<IEnumerable<FuncionarioInterno>> ObterFuncionariosInternosAsync()
    {
        return await _context.InternalEmployees
            .Include(e => e.CursosParticipados) // Inclui a relação de cursos participados
            .ToListAsync(); // Converte o resultado para uma lista
    }

    // Método assíncrono para obter um funcionário interno específico pelo ID, incluindo seus cursos participados
    public async Task<FuncionarioInterno?> ObterFuncionarioInternoAsync(Guid funcionarioId)
    {
        return await _context.InternalEmployees
            .Include(e => e.CursosParticipados)
            .FirstOrDefaultAsync(e => e.Id == funcionarioId);
    }

    public FuncionarioInterno? ObterFuncionarioInterno(Guid employeeId)
    {
        return _context.InternalEmployees
            .Include(e => e.CursosParticipados)
            .FirstOrDefault(e => e.Id == employeeId);
    }

    public async Task<Curso?> GetCourseAsync(Guid courseId)
    {
        return await _context.Courses.FirstOrDefaultAsync(e => e.Id == courseId);
    }

    public Curso? ObterCurso(Guid courseId)
    {
        return _context.Courses.FirstOrDefault(e => e.Id == courseId);
    }

    public List<Curso> ObtemCursos(params Guid[] courseIds)
    {
        List<Curso> coursesToReturn = new();
        foreach (var courseId in courseIds)
        {
            var course = ObterCurso(courseId);
            if (course != null)
            {
                coursesToReturn.Add(course);
            }
        }
        return coursesToReturn;
    }

    public async Task<List<Curso>> ObterCursosAsync(params Guid[] courseIds)
    {
        List<Curso> coursesToReturn = new();
        foreach (var courseId in courseIds)
        {
            var course = await GetCourseAsync(courseId);
            if (course != null)
            {
                coursesToReturn.Add(course);
            }
        }
        return coursesToReturn;
    }

    public void AdicionarFuncionarioInterno(FuncionarioInterno internalEmployee)
    {
        _context.InternalEmployees.Add(internalEmployee);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
