using FIAP.Domain.Entities.Store;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Infrastructure.Data.Context.Mappings.Store;

public class ComboItemsMapping : IEntityTypeConfiguration<ComboItems>
{
    public void Configure(EntityTypeBuilder<ComboItems> entity)
    {
        entity.ToTable("combo_items");

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

        entity.Property(x => x.ProductId)
            .HasColumnName("product_id");

        entity.Property(x => x.ComboId)
            .HasColumnName("combo_id");

        entity.Property(x => x.Quantity)
            .HasColumnName("quantity");

        entity.HasOne(d => d.Product)
            .WithMany(x => x.ComboItems)
            .HasForeignKey(d => d.ProductId);

        entity.HasOne(d => d.Combo)
            .WithMany(x => x.Items)
            .HasForeignKey(d => d.ComboId);
    }
}