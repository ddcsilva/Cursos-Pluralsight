using Microsoft.AspNetCore.Mvc; // Importa os namespaces necessários para controladores e ações MVC

namespace TopLevelManagement.Controllers;

[ApiController]
[Route("api/verificacoespromocao")]
public class VerificacoesPromocaoController : ControllerBase
{
    [HttpGet("{funcionarioId}")]
    public IActionResult FuncionarioElegivelParaPromocao(Guid funcionarioId)
    {
        // Para fins de demonstração, assume que Megan (com o ID específico) é elegível para promoção, enquanto outros funcionários não são
        if (funcionarioId == Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"))
        {
            // Retorna um objeto JSON indicando que o funcionário é elegível para promoção
            return Ok(new { EligibleForPromotion = true });
        }

        // Para qualquer outro ID, retorna um objeto JSON indicando que o funcionário não é elegível para promoção
        return Ok(new { EligibleForPromotion = false });
    }
}