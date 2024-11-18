using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions dbContextOptions)
    : base (dbContextOptions)
    {
        
    }

    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseLevel> ExerciseLevels { get; set; }
    public DbSet<MuscleGroup> MuscleGroup { get; set; }
    public DbSet<Workout> Workouts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ExerciseLevel>(el => 
        {
            el.HasKey(x => x.Id);
            el.Property(x => x.Name).IsRequired();
        });

        builder.Entity<Exercise>(ex => {
            ex.HasKey(x => x.Id);
            ex.Property(x => x.Title).IsRequired();
            ex.Property(x => x.Description).IsRequired();
            ex.Property(x => x.Video).IsRequired();
            ex.Property(x => x.Picture).IsRequired();

            // one-to-many with exercise levels
            ex.HasOne(x => x.ExerciseLevel)
              .WithMany(x => x.Exercises)
              .HasForeignKey(x => x.ExerciseLevelId)
              .OnDelete(DeleteBehavior.Restrict);

            // many-to-many with muscle group
            ex.HasMany(e => e.MuscleGroups)
              .WithMany(mg => mg.Exercises);

            // many-to-one with set
            ex.HasMany(e => e.Sets)
              .WithOne(s => s.Exercise)
              .HasForeignKey(s => s.ExerciseId)
              .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<MuscleGroup>(mg => 
        {
            mg.HasKey(x => x.Id);
            mg.Property(x => x.Name).IsRequired();
        });

        builder.Entity<Set>(set => 
        {
            set.HasKey(s => s.Id);
            set.Property(s => s.ExerciseId).IsRequired();

            set.HasMany(s => s.Items)
               .WithOne(si => si.Set)
               .HasForeignKey(si => si.SetId)
               .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<SetItem>(setItem =>
        {
            setItem.HasKey(si => si.Id);
            setItem.Property(si => si.Weight).IsRequired();
            setItem.Property(si => si.Repetitions).IsRequired();
            setItem.Property(si => si.ItemNumber).IsRequired();
        });

        builder.Entity<Workout>(workout => {
            workout.HasKey(wo => wo.Id);
            workout.Property(wo => wo.WorkoutName).IsRequired();
            workout.HasMany(wo => wo.Sets)
                   .WithOne(s => s.Workout)
                   .HasForeignKey(s => s.WorkoutId)
                   .OnDelete(DeleteBehavior.Cascade);
        });
        

        List<IdentityRole> roles = new List<IdentityRole>()
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}
