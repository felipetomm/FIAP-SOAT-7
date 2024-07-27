using Microsoft.EntityFrameworkCore;

namespace FIAP.Infrastructure.Data.Context;

public partial class BaseDbContext : DbContext
{
    //public DbSet<Orders> Orders { get; set; }

    public void CreatingStore(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new OrdersMapping());
    }
}