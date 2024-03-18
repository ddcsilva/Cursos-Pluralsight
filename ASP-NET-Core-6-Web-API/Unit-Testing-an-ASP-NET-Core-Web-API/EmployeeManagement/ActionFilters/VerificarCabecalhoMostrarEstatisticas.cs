using Microsoft.AspNetCore.Mvc; // Fornece classes e atributos necessários para criar controladores e ações no ASP.NET Core MVC.
using Microsoft.AspNetCore.Mvc.Filters; // Contém classes e interfaces para a criação de filtros de ações. Filtros de ações são usados para executar lógica antes ou depois de controladores e ações serem executados.

namespace EmployeeManagement.ActionFilters;

// Define um filtro de ação personalizado para verificar o cabeçalho de estatísticas
public class VerificarCabecalhoMostrarEstatisticas : ActionFilterAttribute
{
    // Método executado antes da ação do controlador
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Se o cabeçalho MostrarEstatisticas estiver ausente ou definido como false, um BadRequest deve ser retornado.
        if (!context.HttpContext.Request.Headers.ContainsKey("MostrarEstatisticas"))
        {
            context.Result = new BadRequestResult(); // Retorna erro de requisição inválida
        }

        // Obtém o valor do cabeçalho MostrarEstatisticas
        if (!bool.TryParse(context.HttpContext.Request.Headers["MostrarEstatisticas"].ToString(), out bool showStatisticsValue))
        {
            context.Result = new BadRequestResult(); // Retorna erro se não for possível converter
        }

        // Verifica o valor do cabeçalho
        if (!showStatisticsValue)
        {
            context.Result = new BadRequestResult(); // Retorna erro se o valor for falso
        }
    } 
}
