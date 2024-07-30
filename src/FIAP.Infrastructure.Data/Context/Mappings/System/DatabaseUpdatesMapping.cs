using FIAP.Domain.Entities.Infra;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Infrastructure.Data.Context.Mappings.System;

public class DatabaseUpdatesMapping : IEntityTypeConfiguration<DatabaseUpdates>
{
    public void Configure(EntityTypeBuilder<DatabaseUpdates> entity)
    {
        entity.ToTable("database_updates");

        entity.HasKey(x => x.Id);

        entity.Property(x => x.Id)
            .HasColumnName("id");

        entity.Property(x => x.Created)
            .HasColumnName("created");

        entity.Property(x => x.FileName)
            .HasColumnName("file_name");

        entity.Property(x => x.Content)
            .HasColumnName("content");
    }
}