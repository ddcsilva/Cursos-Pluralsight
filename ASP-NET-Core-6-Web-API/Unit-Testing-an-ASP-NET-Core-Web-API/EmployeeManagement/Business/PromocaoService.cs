using EmployeeManagement.DataAccess.Entities; // Entidades usadas no acesso a dados
using EmployeeManagement.DataAccess.Services; // Serviços para operações de acesso a dados
using System.Net.Http.Headers; // Utilitários para manipulação de cabeçalhos HTTP
using System.Text.Json; // Funcionalidades para serialização/deserialização JSON

namespace EmployeeManagement.Business;

// Classe de serviço para promover funcionários internos baseado na elegibilidade
public class PromocaoService : IPromocaoService
{
    private readonly HttpClient _httpClient; // Cliente HTTP para realizar chamadas a APIs externas
    private readonly IGerenciamentoFuncionarioRepository _repositorioGerenciamentoFuncionario; // Repositório para gerenciamento de dados de funcionários

    public PromocaoService(HttpClient httpClient, IGerenciamentoFuncionarioRepository _gerenciamentoFuncionarioRepository)
    {
        _httpClient = httpClient;
        _repositorioGerenciamentoFuncionario = _gerenciamentoFuncionarioRepository;
    }

    /// <summary>
    /// Promove um funcionário interno se ele for elegível para promoção.
    /// </summary>
    /// <param name="funcionario">O funcionário a ser promovido.</param>
    /// <returns>True se o funcionário for promovido, caso contrário, false.</returns>
    public async Task<bool> PromoverFuncionarioInternoAsync(FuncionarioInterno funcionario)
    {
        if (await VerificarSeFuncionarioInternoEhElegivelParaPromocao(funcionario.Id))
        {
            funcionario.NivelCargo++;
            await _repositorioGerenciamentoFuncionario.SaveChangesAsync();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Calls into external API (containing a data source only
    /// the top level managers can manage) to check whether
    /// an internal employee is eligible for promotion
    /// </summary> 
    private async Task<bool> VerificarSeFuncionarioInternoEhElegivelParaPromocao(
        Guid employeeId)
    {
        // call into API
        var apiRoot = "http://localhost:5057";

        var request = new HttpRequestMessage(HttpMethod.Get,
            $"{apiRoot}/api/promotioneligibilities/{employeeId}");
        request.Headers.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        // deserialize content
        var content = await response.Content.ReadAsStringAsync();
        var promotionEligibility = JsonSerializer.Deserialize<ElegibilidadePromocao>(content,
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        // return value
        return promotionEligibility == null ?
            false : promotionEligibility.ElegivelParaPromocao;
    }
}