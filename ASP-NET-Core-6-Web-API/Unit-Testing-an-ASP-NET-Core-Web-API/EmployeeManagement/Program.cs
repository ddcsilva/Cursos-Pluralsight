using EmployeeManagement; // Importa o namespace EmployeeManagement para acesso �s fun��es e servi�os definidos nele.

// Inicializa um construtor para uma aplica��o web com argumentos de linha de comando.
var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao container de inje��o de depend�ncia da aplica��o.

// Adiciona o suporte a controladores MVC � aplica��o.
builder.Services.AddControllers();

// Configura o Swagger/OpenAPI para documenta��o da API. �til durante o desenvolvimento para testar endpoints da API de forma interativa.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona suporte ao cliente HttpClient, permitindo que a aplica��o fa�a solicita��es HTTP para outras APIs.
builder.Services.AddHttpClient("TopLevelManagementAPIClient");

// Adiciona o AutoMapper ao container de servi�os, facilitando o mapeamento entre entidades e DTOs (Objetos de Transfer�ncia de Dados).
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adiciona outros servi�os customizados necess�rios para a aplica��o, como servi�os de neg�cios e acesso a dados.
builder.Services.RegistrarServicosNegocio(); // M�todo de extens�o personalizado para registrar servi�os de neg�cios.
builder.Services.RegistrarServicosAcessoDados(builder.Configuration); // M�todo de extens�o personalizado para registrar servi�os de acesso a dados.

// Constr�i o objeto de aplica��o a partir do construtor.
var app = builder.Build();

// Configura o pipeline de requisi��es HTTP.
if (app.Environment.IsDevelopment()) // Executa em ambiente de desenvolvimento.
{
    // Usa o Swagger para documentar e testar a API.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplica o middleware de autoriza��o.
app.UseAuthorization();

// Mapeia os controladores para os endpoints da API.
app.MapControllers();

// Inicia a aplica��o.
app.Run();