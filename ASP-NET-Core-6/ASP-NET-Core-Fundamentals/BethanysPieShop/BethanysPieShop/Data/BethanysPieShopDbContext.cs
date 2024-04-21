using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Data;

public class BethanysPieShopDbContext : DbContext
{
    public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options) : base(options) { }

    public DbSet<Torta> Tortas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<CarrinhoItem> CarrinhoItens { get; set; }
}
