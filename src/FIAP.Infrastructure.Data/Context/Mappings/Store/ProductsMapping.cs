using FIAP.Domain.Entities.Store;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Infrastructure.Data.Context.Mappings.Store;

public class ProductsMapping : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> entity)
    {
        entity.ToTable("products");

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

        entity.Property(x => x.Name)
            .HasColumnName("name");

        entity.Property(x => x.Description)
            .HasColumnName("description");

        entity.Property(x => x.Price)
            .HasColumnName("price");

        entity.Property(x => x.Quantity)
            .HasColumnName("quantity");

        entity.Property(x => x.Category)
            .HasColumnName("category");

        entity.Property(x => x.TimeToPrepareMinutes)
            .HasColumnName("time_to_prepare_minutes");
    }
}