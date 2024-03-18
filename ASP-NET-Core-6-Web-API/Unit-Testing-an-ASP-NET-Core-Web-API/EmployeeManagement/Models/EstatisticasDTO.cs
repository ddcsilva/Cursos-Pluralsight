namespace EmployeeManagement.Models;

// Modelo de transferência de dados para estatísticas da conexão HTTP
public class EstatisticasDTO
{
    // Endereço IP local da conexão
    public string EnderecoIpLocal { get; set; } = string.Empty;

    // Porta local da conexão
    public int PortaLocal { get; set; }

    // Endereço IP remoto da conexão
    public string EnderecoIpRemoto { get; set; } = string.Empty;

    // Porta remota da conexão
    public int PortaRemota { get; set; }
}
