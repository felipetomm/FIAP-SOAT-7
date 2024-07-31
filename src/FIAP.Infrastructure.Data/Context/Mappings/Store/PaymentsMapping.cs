using FIAP.Domain.Entities.Store;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Infrastructure.Data.Context.Mappings.Store;

public class PaymentsMapping : IEntityTypeConfiguration<Payments>
{
    public void Configure(EntityTypeBuilder<Payments> entity)
    {
        entity.ToTable("payments");

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

        entity.Property(x => x.Amount)
            .HasColumnName("amount");

        entity.Property(x => x.ExternalTransactionId)
            .HasColumnName("external_transaction_id");

        entity.Property(x => x.Gateway)
            .HasColumnName("gateway");

        entity.Property(x => x.Status)
            .HasColumnName("status");
    }
}