using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("Exercise")]
public class Exercise
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Picture { get; set; } = string.Empty;
    public string Video { get; set; } = string.Empty;
    public bool IsApproved { get; set; } = false;

    // Foreign key for ExerciseLevel
    public int ExerciseLevelId { get; set; }
    // Navigation property
    public ExerciseLevel ExerciseLevel { get; set; }

    // Many-to-Many with muscle group
    public ICollection<MuscleGroup> MuscleGroups { get; set; } = new HashSet<MuscleGroup>();


    // Many-to-one relationship with Set
    public ICollection<Set> Sets { get; set; } = new HashSet<Set>();
}
