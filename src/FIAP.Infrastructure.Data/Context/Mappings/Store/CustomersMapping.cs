using FIAP.Domain.Entities.Store;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Infrastructure.Data.Context.Mappings.Store;

public class CustomersMapping : IEntityTypeConfiguration<Customers>
{
    public void Configure(EntityTypeBuilder<Customers> entity)
    {
        entity.ToTable("customers");

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

        entity.Property(x => x.Cpf)
            .HasColumnName("cpf");

        entity.Property(x => x.Name)
            .HasColumnName("name");

        entity.Property(x => x.Email)
            .HasColumnName("email");

        entity.Property(x => x.Phone)
            .HasColumnName("phone");
    }
}