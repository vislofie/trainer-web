namespace api.Models;

public class MuscleGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
}
