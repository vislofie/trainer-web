using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Infrastructure.Configurations;

public class SetConfiguration : IEntityTypeConfiguration<Set>
{
    public void Configure(EntityTypeBuilder<Set> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.ExerciseId).IsRequired();

        // one-to-many with exercise
        builder.HasOne(s => s.Exercise)
            .WithMany() // Note: No navigation property specified here
            .HasForeignKey(s => s.ExerciseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Items)
            .WithOne(si => si.Set)
            .HasForeignKey(si => si.SetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
