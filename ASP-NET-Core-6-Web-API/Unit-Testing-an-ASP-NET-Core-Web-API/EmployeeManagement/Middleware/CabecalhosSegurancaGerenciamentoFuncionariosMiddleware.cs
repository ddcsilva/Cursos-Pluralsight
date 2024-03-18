namespace EmployeeManagement.Middleware;

// Middleware para adicionar cabeçalhos de segurança às respostas HTTP no aplicativo de gerenciamento de funcionários
public class CabecalhosSegurancaGerenciamentoFuncionariosMiddleware
{
    private readonly RequestDelegate _next; // Delegado para a próxima etapa no pipeline de middleware

    // Construtor que recebe o próximo delegado no pipeline de middleware
    public CabecalhosSegurancaGerenciamentoFuncionariosMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // Método invocado pelo pipeline de middleware para tratar a requisição
    public async Task InvokeAsync(HttpContext context)
    {
        IHeaderDictionary headers = context.Response.Headers; // Dicionário de cabeçalhos da resposta

        // Adiciona o cabeçalho de Política de Segurança de Conteúdo (CSP) para restringir recursos a origens específicas
        headers["Content-Security-Policy"] = "default-src 'self';frame-ancestors 'none';";

        // Adiciona o cabeçalho X-Content-Type-Options para evitar que o navegador interprete erroneamente os tipos MIME
        headers["X-Content-Type-Options"] = "nosniff";

        await _next(context); // Chama o próximo middleware no pipeline
    }
}

