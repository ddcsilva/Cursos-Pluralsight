namespace BethanysPieShop.Models;

public class MockTortaRepository : ITortaRepository
{
    private readonly ICategoriaRepository _categoriaRepository;

    public MockTortaRepository(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public IEnumerable<Torta> ObterTortas =>
        [
            new Torta
            {
                TortaId = 1,
                Nome = "Torta de morango",
                Preco = 15.95M,
                DescricaoCurta = "Torta de morango fresco",
                DescricaoDetalhada = "Torta de morango fresco com creme de baunilha",
                Categoria = _categoriaRepository.ObterCategorias.ToList()[0],
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypie.jpg",
                ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg",
                EmEstoque = true,
                TortaDaSemana = false
            },
            new Torta
            {
                TortaId = 2,
                Nome = "Torta de queijo",
                Preco = 18.95M,
                DescricaoCurta = "Torta de queijo cremoso",
                DescricaoDetalhada = "Torta de queijo cremoso feita com queijo suíço",
                Categoria = _categoriaRepository.ObterCategorias.ToList()[1],
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg",
                ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg",
                EmEstoque = true,
                TortaDaSemana = false
            },
            new Torta
            {
                TortaId = 3,
                Nome = "Torta de ruibarbo",
                Preco = 15.95M,
                DescricaoCurta = "Torta de ruibarbo com morango",
                DescricaoDetalhada = "Torta de ruibarbo com morango e baunilha",
                Categoria = _categoriaRepository.ObterCategorias.ToList()[0],
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpie.jpg",
                ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpiesmall.jpg",
                EmEstoque = true,
                TortaDaSemana = false
            },
            new Torta
            {
                TortaId = 4,
                Nome = "Torta de maçã",
                Preco = 18.95M,
                DescricaoCurta = "Torta de maçã clássica",
                DescricaoDetalhada = "Torta de maçã clássica com crosta de manteiga",
                Categoria = _categoriaRepository.ObterCategorias.ToList()[2],
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg",
                ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg",
                EmEstoque = true,
                TortaDaSemana = false
            },
            new Torta
            {
                TortaId = 5,
                Nome = "Torta de mirtilo",
                Preco = 18.95M,
                DescricaoCurta = "Torta de mirtilo fresco",
                DescricaoDetalhada = "Torta de mirtilo fresco, perfeito em qualquer época do ano",
                Categoria = _categoriaRepository.ObterCategorias.ToList()[0],
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrypie.jpg",
                ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrypiesmall.jpg",
                EmEstoque = true,
                TortaDaSemana = false
            },
            new Torta
            {
                TortaId = 6,
                Nome = "Torta de queijo",
                Preco = 18.95M,
                DescricaoCurta = "Torta de queijo cremoso",
                DescricaoDetalhada = "Torta de queijo cremoso feita com queijo suíço",
                Categoria = _categoriaRepository.ObterCategorias.ToList()[1],
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg",
                ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg",
                EmEstoque = true,
                TortaDaSemana = false
            },
            new Torta
            {
                TortaId = 7,
                Nome = "Torta de ruibarbo",
                Preco = 15.95M,
                DescricaoCurta = "Torta de ruibarbo com morango",
                DescricaoDetalhada = "Torta de ruibarbo com morango e baunilha",
                Categoria = _categoriaRepository.ObterCategorias.ToList()[0],
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpie.jpg",
                ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpiesmall.jpg",
                EmEstoque = true,
                TortaDaSemana = false
            },
            new Torta
            {
                TortaId = 8,
                Nome = "Torta de maçã",
                Preco = 18.95M,
                DescricaoCurta = "Torta de maçã clássica",
                DescricaoDetalhada = "Torta de maçã clássica com crosta de manteiga",
                Categoria = _categoriaRepository.ObterCategorias.ToList()[2],
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg",
                ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg",
                EmEstoque = true,
                TortaDaSemana = false
            },
            new Torta
            {
                TortaId = 9,
                Nome = "Torta de mirtilo",
                Preco = 18.95M,
                DescricaoCurta = "Torta de mirtilo fresco",
                DescricaoDetalhada = "Torta de mirtilo fresco, perfeito em qualquer época do ano",
                Categoria = _categoriaRepository.ObterCategorias.ToList()[0],
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrypie.jpg",
                ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrypiesmall.jpg",
                EmEstoque = true,
                TortaDaSemana = false
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
