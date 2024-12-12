using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Infrastructure.Configurations;

public class SetItemConfiguration : IEntityTypeConfiguration<SetItem>
{
    public void Configure(EntityTypeBuilder<SetItem> builder)
    {
        builder.HasKey(si => si.Id);
        builder.Property(si => si.Weight).IsRequired();
        builder.Property(si => si.Repetitions).IsRequired();
        builder.Property(si => si.ItemNumber).IsRequired();
    }
}
