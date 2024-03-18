using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Services;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Test
{
    public class GerenciamentoFuncionarioDadosTesteRepository : IGerenciamentoFuncionarioRepository
    {
        private List<FuncionarioInterno> _internalEmployees;
        private List<FuncionarioExterno> _externalEmployees;
        private List<Curso> _courses;

        public GerenciamentoFuncionarioDadosTesteRepository()
        {
            // mimic expensive creation process
            Thread.Sleep(3000);

            // initialize with dummy data 
            var obligatoryCourse1 = new Curso("Company Introduction")
            {
                Id = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"), 
                EhNovo = false
            };

            var obligatoryCourse2 = new Curso("Respecting Your Colleagues")
            {
                Id = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
                EhNovo = false
            };

            var optionalCourse1 = new Curso("Dealing with Customers 101")
            {
                Id = Guid.Parse("844e14ce-c055-49e9-9610-855669c9859b"),
                EhNovo = false
            };

            _courses = new()
            {
                obligatoryCourse1,
                obligatoryCourse2,
                optionalCourse1,
                new Curso("Dealing with Customers - Advanced")
                {
                    Id = Guid.Parse("d6e0e4b7-9365-4332-9b29-bb7bf09664a6"),
                    EhNovo = false
                },
                new Curso("Disaster Management 101")
                {
                    Id = Guid.Parse("cbf6db3b-c4ee-46aa-9457-5fa8aefef33a"),
                    EhNovo = false
                }
            };

            _internalEmployees = new()
            {
                new FuncionarioInterno("Megan", "Jones", 2, 3000, false, 2)
                {
                    Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"),
                    CursosParticipados = new List<Curso> {
                            obligatoryCourse1, obligatoryCourse2 }
                },
                new FuncionarioInterno("Jaimy", "Johnson", 3, 3400, true, 1)
                {
                    Id = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f"),
                    CursosParticipados = new List<Curso> {
                            obligatoryCourse1, obligatoryCourse2, optionalCourse1 }
                }
            };

            _externalEmployees = new()
            {
                new FuncionarioExterno("Amanda", "Smith", "IT for Everyone, Inc")
                {
                    Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb")
                }
            };
        }

        public void AdicionarFuncionarioInterno(FuncionarioInterno internalEmployee)
        {
            // empty on purpose
        }

        public Curso? ObterCurso(Guid courseId)
        {
            return _courses.FirstOrDefault(c => c.Id == courseId);
        }

        public Task<Curso?> GetCourseAsync(Guid courseId)
        {
            return Task.FromResult(ObterCurso(courseId));
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

        public Task<List<Curso>> ObterCursosAsync(params Guid[] courseIds)
        {
            return Task.FromResult(ObtemCursos(courseIds));
        }

        public FuncionarioInterno? ObterFuncionarioInterno(Guid employeeId)
        {
            return _internalEmployees.FirstOrDefault(e => e.Id == employeeId);
        }

        public Task<FuncionarioInterno?> ObterFuncionarioInternoAsync(Guid employeeId)
        {
            return Task.FromResult(ObterFuncionarioInterno(employeeId));
        }

        public Task<IEnumerable<FuncionarioInterno>> ObterFuncionariosInternosAsync()
        {
            return Task.FromResult(_internalEmployees.AsEnumerable());
        }

        public Task SaveChangesAsync()
        {
            // nothing to do here
            return Task.CompletedTask;
        }
    }
}