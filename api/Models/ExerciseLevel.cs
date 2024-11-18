namespace api.Models;

public class ExerciseLevel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Exercise navigation property
    public ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
}
