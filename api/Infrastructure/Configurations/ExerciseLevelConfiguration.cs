using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Infrastructure.Configurations;

public class ExerciseLevelConfiguration : IEntityTypeConfiguration<ExerciseLevel>
{
    public void Configure(EntityTypeBuilder<ExerciseLevel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
    }
}
