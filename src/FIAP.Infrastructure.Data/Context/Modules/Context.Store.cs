using FIAP.Domain.Entities.Store;
using FIAP.Infrastructure.Data.Context.Mappings.Store;

using Microsoft.EntityFrameworkCore;

namespace FIAP.Infrastructure.Data.Context;

public partial class BaseDbContext : DbContext
{
    public DbSet<ComboItems> ComboItems { get; set; }
    public DbSet<Combos> Combos { get; set; }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Products> Products { get; set; }

    public void CreatingStore(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ComboItemsMapping());
        modelBuilder.ApplyConfiguration(new CombosMapping());
        modelBuilder.ApplyConfiguration(new CustomersMapping());
        modelBuilder.ApplyConfiguration(new OrdersMapping());
        modelBuilder.ApplyConfiguration(new ProductsMapping());
    }
}