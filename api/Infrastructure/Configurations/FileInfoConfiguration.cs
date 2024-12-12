using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Infrastructure.Configurations;

public class FileInfoConfiguration : IEntityTypeConfiguration<Models.FileInfo>
{
    public void Configure(EntityTypeBuilder<Models.FileInfo> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Name).IsRequired();
        builder.Property(f => f.Size).IsRequired();
        builder.Property(f => f.Type).IsRequired();
    }
}
