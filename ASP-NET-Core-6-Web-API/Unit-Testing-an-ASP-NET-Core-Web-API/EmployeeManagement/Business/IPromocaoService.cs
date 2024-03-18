using EmployeeManagement.DataAccess.Entities; // Entidades usadas para acesso a dados

namespace EmployeeManagement.Business;

// Interface para o serviço de promoção de funcionários
public interface IPromocaoService
{
    // Método assíncrono para promover um funcionário interno
    // Retorna verdadeiro se a promoção for bem-sucedida, falso caso contrário
    Task<bool> PromoverFuncionarioInternoAsync(FuncionarioInterno employee);
}