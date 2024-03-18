using Microsoft.AspNetCore.Mvc; // Importa os namespaces necess�rios para controladores e a��es MVC

namespace TopLevelManagement.Controllers;

[ApiController]
[Route("api/verificacoespromocao")]
public class VerificacoesPromocaoController : ControllerBase
{
    [HttpGet("{funcionarioId}")]
    public IActionResult FuncionarioElegivelParaPromocao(Guid funcionarioId)
    {
        // Para fins de demonstra��o, assume que Megan (com o ID espec�fico) � eleg�vel para promo��o, enquanto outros funcion�rios n�o s�o
        if (funcionarioId == Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"))
        {
            // Retorna um objeto JSON indicando que o funcion�rio � eleg�vel para promo��o
            return Ok(new { EligibleForPromotion = true });
        }

        // Para qualquer outro ID, retorna um objeto JSON indicando que o funcion�rio n�o � eleg�vel para promo��o
        return Ok(new { EligibleForPromotion = false });
    }
}