using api.Infrastructure.Configurations;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure;

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
    public DbSet<Set> Set { get; set; }
    public DbSet<SetItem> SetItems { get; set; }
    public DbSet<Models.FileInfo> FileInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new FileInfoConfiguration());
        builder.ApplyConfiguration(new ExerciseLevelConfiguration());
        builder.ApplyConfiguration(new ExerciseConfiguration());
        builder.ApplyConfiguration(new MuscleGroupConfiguration());
        builder.ApplyConfiguration(new SetConfiguration());
        builder.ApplyConfiguration(new SetItemConfiguration());
        builder.ApplyConfiguration(new WorkoutConfiguration());
        
        SeedRoles(builder);
    }

    private void SeedRoles(ModelBuilder builder)
    {
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
