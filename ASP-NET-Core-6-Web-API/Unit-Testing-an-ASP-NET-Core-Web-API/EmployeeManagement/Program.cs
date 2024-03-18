using EmployeeManagement; // Importa o namespace EmployeeManagement para acesso às funções e serviços definidos nele.

// Inicializa um construtor para uma aplicação web com argumentos de linha de comando.
var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container de injeção de dependência da aplicação.

// Adiciona o suporte a controladores MVC à aplicação.
builder.Services.AddControllers();

// Configura o Swagger/OpenAPI para documentação da API. Útil durante o desenvolvimento para testar endpoints da API de forma interativa.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona suporte ao cliente HttpClient, permitindo que a aplicação faça solicitações HTTP para outras APIs.
builder.Services.AddHttpClient("TopLevelManagementAPIClient");

// Adiciona o AutoMapper ao container de serviços, facilitando o mapeamento entre entidades e DTOs (Objetos de Transferência de Dados).
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adiciona outros serviços customizados necessários para a aplicação, como serviços de negócios e acesso a dados.
builder.Services.RegistrarServicosNegocio(); // Método de extensão personalizado para registrar serviços de negócios.
builder.Services.RegistrarServicosAcessoDados(builder.Configuration); // Método de extensão personalizado para registrar serviços de acesso a dados.

// Constrói o objeto de aplicação a partir do construtor.
var app = builder.Build();

// Configura o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment()) // Executa em ambiente de desenvolvimento.
{
    // Usa o Swagger para documentar e testar a API.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplica o middleware de autorização.
app.UseAuthorization();

// Mapeia os controladores para os endpoints da API.
app.MapControllers();

// Inicia a aplicação.
app.Run();