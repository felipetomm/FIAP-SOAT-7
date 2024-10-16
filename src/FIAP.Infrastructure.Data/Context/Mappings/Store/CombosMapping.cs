using FIAP.Domain.Entities.Store;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Infrastructure.Data.Context.Mappings.Store;

public class CombosMapping : IEntityTypeConfiguration<Combos>
{
    public void Configure(EntityTypeBuilder<Combos> entity)
    {
        entity.ToTable("combos");

        entity.HasKey(x => x.Id);

        entity.Property(x => x.Id)
            .HasColumnName("id");

        entity.Property(x => x.Created)
            .HasColumnName("created");

        entity.Property(x => x.Modified)
            .HasColumnName("modified");

        entity.Property(x => x.Deleted)
            .HasColumnName("deleted")
            .HasDefaultValueSql("0");

        entity.Property(x => x.Hash)
            .HasColumnName("hash");

        entity.Property(x => x.OrderId)
            .HasColumnName("order_id");

        entity.HasOne(d => d.Order)
            .WithMany(x => x.Combos)
            .HasForeignKey(d => d.OrderId);
    }
}