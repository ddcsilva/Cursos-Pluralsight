using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

// WebApplication.CreateBuilder: é um método de extensão que cria um WebApplicationBuilder, responsável por configurar a aplicação web
var builder = WebApplication.CreateBuilder(args);

// AddScoped: é um método de extensão que adiciona um serviço ao contêiner de injeção de dependência com um tempo de vida de escopo
builder.Services.AddScoped<ICategoriaRepository, MockCategoriaRepository>();
builder.Services.AddScoped<ITortaRepository, MockTortaRepository>();

// AddControllerWithViews: é um método de extensão que adiciona suporte para controllers e views
builder.Services.AddControllersWithViews();

// AddDbContext: é um método de extensão que adiciona um contexto de banco de dados ao contêiner de injeção de dependência
builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
{
    // UseSqlServer: é um método de extensão que configura o provedor de banco de dados SQL Server
    options.UseSqlServer(
        builder.Configuration["BethanysPieShopDbContextConnection"]);
});

// Build: é um método que cria uma instância de WebApplication, responsável por gerenciar a aplicação web
var app = builder.Build();

// UseStaticFiles: é um método de extensão que adiciona suporte para arquivos estáticos (Pasta: wwwroot)
app.UseStaticFiles();

// IsDevelopment: é uma propriedade que verifica se a aplicação está em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    // UseDeveloperExceptionPage: é um método de extensão que adiciona suporte para páginas de erro de desenvolvedor
    app.UseDeveloperExceptionPage();
}

// MapDefaultControllerRoute: é um método de extensão que mapeia a rota padrão para controllers
app.MapDefaultControllerRoute();

// Run: é um método que inicia a aplicação web
app.Run();
