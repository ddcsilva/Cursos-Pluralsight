using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models;

public class BethanysPieShopDbContext : DbContext
{
    public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options) : base(options) { }

    public DbSet<Torta> Tortas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}
