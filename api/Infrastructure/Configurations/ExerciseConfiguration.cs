using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Infrastructure.Configurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Description).IsRequired();

        // one-to-many with exercise levels
        builder.HasOne(x => x.ExerciseLevel)
            .WithMany(x => x.Exercises)
            .HasForeignKey(x => x.ExerciseLevelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CreatedBy)
            .WithMany(u => u.Exercises)
            .HasForeignKey(x => x.CreatedById)
            .OnDelete(DeleteBehavior.Cascade);

        // many-to-many with muscle group
        builder.HasMany(e => e.MuscleGroups)
            .WithMany(mg => mg.Exercises);

        builder.HasOne(e => e.Picture)
            .WithMany()
            .HasForeignKey(e => e.PictureId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Video)
            .WithMany()
            .HasForeignKey(e => e.VideoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
