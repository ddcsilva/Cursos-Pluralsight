namespace BethanysPieShop;

public class MockTortaRepository : ITortaRepository
{
    public IEnumerable<Torta> ObterTortas =>
        [
            new Torta
            {
                TortaId = 1,
                Nome = "Torta de maçã",
                Preco = 12.95M,
                DescricaoCurta = "Nossa torta de maçã caseira é feita com maçãs frescas da estação.",
                DescricaoDetalhada = "Nossa torta de maçã caseira é feita com maçãs frescas da estação. Vem com uma crosta de torta de manteiga e pode ser encomendada com cobertura de streusel, caramelo ou ambos."
            },
            new Torta
            {
                TortaId = 2,
                Nome = "Torta de abóbora",
                Preco = 15.95M,
                DescricaoCurta = "Uma torta de abóbora clássica com crosta de torta de manteiga.",
                DescricaoDetalhada = "Uma torta de abóbora clássica com crosta de torta de manteiga. Vem com cobertura de chantilly."
            },
            new Torta
            {
                TortaId = 3,
                Nome = "Torta de cereja",
                Preco = 15.95M,
                DescricaoCurta = "Torta de cereja fresca feita com cerejas da estação.",
                DescricaoDetalhada = "Torta de cereja fresca feita com cerejas da estação. Vem com uma crosta de torta de manteiga e pode ser encomendada com cobertura de streusel, caramelo ou ambos."
            }
        ];

    public IEnumerable<Torta> ObterTortasDaSemana
    {
        get
        {
            return ObterTortas.Where(t => t.TortaDaSemana);
        }
    }

    public Torta? ObterTortaPorId(int tortaId)
    {
        return ObterTortas.FirstOrDefault(t => t.TortaId == tortaId);
    }

    public IEnumerable<Torta> ProcurarTortas(string pesquisaQuery)
    {
        throw new NotImplementedException();
    }
}
