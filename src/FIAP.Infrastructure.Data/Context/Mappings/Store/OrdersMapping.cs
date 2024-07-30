using FIAP.Domain.Entities.Store;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Infrastructure.Data.Context.Mappings.Store;

public class OrdersMapping : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> entity)
    {
        entity.ToTable("orders");

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

        entity.Property(x => x.CustomerId)
            .HasColumnName("customer_id");

        entity.Property(x => x.Status)
            .HasColumnName("status");

        entity.Property(x => x.TimeEstimate)
            .HasColumnName("time_estimate");

        entity.Property(x => x.OrderValue)
            .HasColumnName("order_value");
    }
}