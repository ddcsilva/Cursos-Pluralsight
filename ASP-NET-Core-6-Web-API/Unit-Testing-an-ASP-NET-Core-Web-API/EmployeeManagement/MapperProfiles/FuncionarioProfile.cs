using AutoMapper; // Biblioteca para mapeamento entre objetos
using EmployeeManagement.DataAccess.Entities; // Entidades de acesso a dados

namespace EmployeeManagement.MapperProfiles;

// Classe de perfil do AutoMapper para configurações de mapeamento de funcionários
public class FuncionarioProfile : Profile
{
    public FuncionarioProfile()
    {
        // Configura o mapeamento da entidade FuncionarioInterno para o modelo FuncionarioInternoDTO
        // Isso permite a conversão automática de uma entidade FuncionarioInterno em um FuncionarioInternoDTO
        // quando usamos o AutoMapper para transformar dados entre camadas da aplicação.
        CreateMap<FuncionarioInterno, Models.FuncionarioInternoDTO>(); 
    }
}
