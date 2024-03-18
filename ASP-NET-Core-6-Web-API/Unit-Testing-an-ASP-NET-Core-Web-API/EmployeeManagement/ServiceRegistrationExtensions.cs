using EmployeeManagement.Business; // Contém as classes de lógica de negócios
using EmployeeManagement.DataAccess.DbContexts; // Contextos do banco de dados
using EmployeeManagement.DataAccess.Services; // Serviços de acesso a dados
using Microsoft.EntityFrameworkCore; // Entity Framework Core

namespace EmployeeManagement;

// Classe de extensão para registrar serviços na aplicação
public static class ServiceRegistrationExtensions
{
    // Método de extensão para registrar serviços de negócios
    public static IServiceCollection RegistrarServicosNegocio(this IServiceCollection services)
    {
        // Registra o serviço de funcionários como escopo
        services.AddScoped<IFuncionarioService, FuncionarioService>();

        // Registra o serviço de promoção como escopo
        services.AddScoped<IPromocaoService, PromocaoService>();

        // Registra a fábrica de funcionários como escopo
        services.AddScoped<FuncionarioFactory>();

        // Retorna a coleção de serviços modificada
        return services;
    }

    // Método de extensão para registrar serviços de acesso a dados
    public static IServiceCollection RegistrarServicosAcessoDados(this IServiceCollection services, IConfiguration configuration)
    {
        // Adiciona o DbContext, configurando-o para usar SQLite com a string de conexão definida
        services.AddDbContext<FuncionarioDbContext>(options => options.UseSqlite(configuration.GetConnectionString("EmployeeManagementDB")));

        // Registra o repositório de gerenciamento de funcionários como escopo
        services.AddScoped<IGerenciamentoFuncionarioRepository, GerenciamentoFuncionarioRepository>();

        // Retorna a coleção de serviços modificada
        return services;
    }
}
