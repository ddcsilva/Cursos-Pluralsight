using AutoMapper; // Biblioteca para mapeamento entre objetos
using Microsoft.AspNetCore.Http.Features; // Funcionalidades relacionadas ao HTTP

namespace EmployeeManagement.MapperProfiles;

// Classe de perfil do AutoMapper para configurações de mapeamento de estatísticas
public class EstatisticaProfile : Profile
{
    public EstatisticaProfile()
    {
        // Configura o mapeamento da interface IHttpConnectionFeature para o modelo EstatisticasDTO
        // Isso permite a conversão automática de informações sobre a conexão HTTP
        // em um objeto EstatisticasDTO, que pode ser mais facilmente manipulado
        // ou exposto através da API.
        CreateMap<IHttpConnectionFeature, Models.EstatisticasDTO>();
    }
}
