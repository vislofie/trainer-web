namespace api.Models;

public class Set
{
    public int Id { get; set; }

    // foreign key for exercise
    public int ExerciseId { get; set; }
    // Navigation property
    public Exercise Exercise { get; set; }

    // foreign key for workout
    public int WorkoutId { get; set; }
    // navigation property
    public Workout Workout { get; set; }

    public ICollection<SetItem> Items { get; set; } = new HashSet<SetItem>();
}
