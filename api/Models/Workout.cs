
namespace api.Models;

public class Workout
{
    public int Id { get; set; }
    public string WorkoutName { get; set; } = string.Empty;

    // navigation property for sets
    public ICollection<Set> Sets = new HashSet<Set>();
}
