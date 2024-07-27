using FIAP.Domain.Entities.Infra;
using FIAP.Infrastructure.Data.Context.Mappings.System;

using Microsoft.EntityFrameworkCore;

namespace FIAP.Infrastructure.Data.Context;

public partial class BaseDbContext : DbContext
{
    public DbSet<DatabaseUpdates> DatabaseUpdates { get; set; }

    public void CreatingSystem(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DatabaseUpdatesMapping());
    }
}