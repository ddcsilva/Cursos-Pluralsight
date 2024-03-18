using EmployeeManagement.DataAccess.Entities; // Entidades do acesso a dados
using Microsoft.EntityFrameworkCore; // Funcionalidades do Entity Framework Core

namespace EmployeeManagement.DataAccess.DbContexts;

// Contexto do Entity Framework Core para o banco de dados de gerenciamento de funcionários
public class FuncionarioDbContext : DbContext
{
    // Define conjuntos de dados para funcionários internos e externos, e cursos, dentro do banco de dados
    public DbSet<FuncionarioInterno> InternalEmployees { get; set; } = null!;
    public DbSet<FuncionarioExterno> ExternalEmployees { get; set; } = null!;
    public DbSet<Curso> Courses { get; set; } = null!;

    // Construtor que configura o contexto com as opções fornecidas
    public FuncionarioDbContext(DbContextOptions<FuncionarioDbContext> options) : base(options) { }

    // Configuração do modelo ao criar o modelo de banco de dados
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Cursos obrigatórios e opcionais predefinidos
        var cursoObrigatorio1 = new Curso("Introdução à Empresa")
        {
            Id = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
            EhNovo = false
        };

        var cursoObrigatorio2 = new Curso("Respeitando Seus Colegas")
        {
            Id = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
            EhNovo = false
        };

        var cursoOpcional1 = new Curso("Atendimento ao Cliente 101")
        {
            Id = Guid.Parse("844e14ce-c055-49e9-9610-855669c9859b"),
            EhNovo = false
        };

        // Adiciona cursos predefinidos ao modelo
        modelBuilder.Entity<Curso>()
              .HasData(cursoObrigatorio1,
                  cursoObrigatorio2,
                  cursoOpcional1,
                  new Curso("Atendimento ao Cliente - Avançado")
                  {
                      Id = Guid.Parse("d6e0e4b7-9365-4332-9b29-bb7bf09664a6"),
                      EhNovo = false
                  },
                  new Curso("Gestão de Desastres 101")
                  {
                      Id = Guid.Parse("cbf6db3b-c4ee-46aa-9457-5fa8aefef33a"),
                      EhNovo = false
                  }
              );

        // Adiciona exemplos de funcionários internos ao modelo
        modelBuilder.Entity<FuncionarioInterno>()
            .HasData(
                new FuncionarioInterno("Megan", "Jones", 2, 3000, false, 2)
                {
                    Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb")
                },
                new FuncionarioInterno("Jaimy", "Johnson", 3, 3400, true, 1)
                {
                    Id = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f")
                });

        // Configura a relação muitos-para-muitos entre funcionários internos e cursos
        modelBuilder
            .Entity<FuncionarioInterno>()
            .HasMany(p => p.CursosParticipados)
            .WithMany(p => p.FuncionariosQueParticiparam)
            .UsingEntity(j => j.ToTable("FuncionarioInternoCurso").HasData(new[]
                {
                    new { CursosParticipadosId = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                        FuncionariosQueParticiparamId = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb") },
                    new { CursosParticipadosId = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
                        FuncionariosQueParticiparamId = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb") },
                    new { CursosParticipadosId = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                        FuncionariosQueParticiparamId = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") },
                    new { CursosParticipadosId = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
                        FuncionariosQueParticiparamId = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") },
                    new { CursosParticipadosId = Guid.Parse("844e14ce-c055-49e9-9610-855669c9859b"),
                        FuncionariosQueParticiparamId = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") }
                }
            ));

        // Adiciona um exemplo de funcionário externo ao modelo
        modelBuilder.Entity<FuncionarioExterno>().HasData(
            new FuncionarioExterno("Amanda", "Smith", "Tecnologia para Todos, Inc")
            {
                Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb")
            });
    }
}
