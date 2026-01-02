using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Infrastructure.Configurations;

public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.HasKey(wo => wo.Id);
        builder.Property(wo => wo.WorkoutName).IsRequired();
        
        // many-to-one with sets
        builder.HasMany(wo => wo.Sets)
               .WithOne(s => s.Workout)
               .HasForeignKey(s => s.WorkoutId)
               .OnDelete(DeleteBehavior.Cascade);
        
        // one-to-many with createdBy
        builder.HasOne(w => w.CreatedBy)
            .WithMany(u => u.Workouts)
            .HasForeignKey(w => w.CreatedById)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
