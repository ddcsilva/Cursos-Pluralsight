using BethanysPieShop.Data;
using BethanysPieShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models;

public class Carrinho : ICarrinho
{
    private readonly BethanysPieShopDbContext _context;

    private Carrinho(BethanysPieShopDbContext context)
    {
        _context = context;
    }

    public string? CarrinhoId { get; set; }

    public List<CarrinhoItem> CarrinhoItens { get; set; } = default!;

    public static Carrinho ObterCarrinho(IServiceProvider services)
    {
        // Obtém o serviço do tipo IHttpContextAccessor do provedor de serviços.
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

        // Obtém o serviço do tipo BethanysPieShopDbContext do provedor de serviços.
        // Se o serviço não estiver registrado, uma exceção será lançada.
        BethanysPieShopDbContext context = services.GetService<BethanysPieShopDbContext>() ?? throw new Exception("Erro ao obter o contexto do banco de dados");

        // Se o carrinho não existir na sessão, crie um e salve o ID na sessão.
        string carrinhoId = session?.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

        // Salva o ID do carrinho na sessão.
        session?.SetString("CarrinhoId", carrinhoId);

        // Retorna o carrinho com o contexto do banco de dados.
        return new Carrinho(context) { CarrinhoId = carrinhoId };
    }

    public void AdicionarAoCarrinho(Torta torta)
    {
        // Obtém o item do carrinho para a torta especificada.
        var carrinhoItem = _context.CarrinhoItens.SingleOrDefault(
            c => c.Torta.TortaId == torta.TortaId && c.CarrinhoId == CarrinhoId
        );

        // Se o item do carrinho não existir, crie um novo item no carrinho.
        // Caso contrário, incremente a quantidade.
        if (carrinhoItem == null)
        {
            // Cria um novo item no carrinho se ele não existir.
            carrinhoItem = new CarrinhoItem
            {
                CarrinhoId = CarrinhoId,
                Torta = torta,
                Quantidade = 1
            };

            // Adiciona o novo item ao contexto do banco de dados.
            _context.CarrinhoItens.Add(carrinhoItem);
        }
        else
        {
            // Incrementa a quantidade se o item do carrinho já existir.
            carrinhoItem.Quantidade++;
        }

        // Salva as alterações no banco de dados.
        _context.SaveChanges();
    }

    public int RemoverDoCarrinho(Torta torta)
    {
        // Obtém o item do carrinho para a torta especificada.
        var carrinhoItem = _context.CarrinhoItens.SingleOrDefault(
            c => c.Torta.TortaId == torta.TortaId && c.CarrinhoId == CarrinhoId
        );

        // A quantidade local é usada para armazenar a quantidade do item do carrinho.
        var quantidadeLocal = 0;

        // Se o item do carrinho existir, decrementa a quantidade.
        // Caso contrário, remove o item do carrinho.
        if (carrinhoItem != null)
        {
            // Decrementa a quantidade se o item do carrinho existir.
            if (carrinhoItem.Quantidade > 1)
            {
                carrinhoItem.Quantidade--;
                quantidadeLocal = carrinhoItem.Quantidade;
            }
            else
            {
                // Remove o item do carrinho se a quantidade for menor que 1.
                _context.CarrinhoItens.Remove(carrinhoItem);
            }
        }

        // Salva as alterações no banco de dados.
        _context.SaveChanges();

        // Retorna a quantidade do item do carrinho.
        return quantidadeLocal;
    }

    public List<CarrinhoItem> ObterItensCarrinho()
    {
        // Retorna os itens do carrinho se eles não forem nulos.
        return CarrinhoItens ??= _context.CarrinhoItens.Where(c => c.CarrinhoId == CarrinhoId).Include(s => s.Torta).ToList();
    }

    public void LimparCarrinho()
    {
        // Obtém todos os itens do carrinho para o carrinho atual.
        var carrinhoItens = _context.CarrinhoItens.Where(c => c.CarrinhoId == CarrinhoId);

        // Remove todos os itens do carrinho.
        _context.CarrinhoItens.RemoveRange(carrinhoItens);

        // Salva as alterações no banco de dados.
        _context.SaveChanges();
    }

    public decimal ObterTotalCarrinho()
    {
        // Calcula o total do carrinho multiplicando o preço da torta pela quantidade.
        var total = _context.CarrinhoItens.Where(c => c.CarrinhoId == CarrinhoId)
            .Select(c => c.Torta.Preco * c.Quantidade).Sum();

        // Retorna o total do carrinho.
        return total;
    }
}
