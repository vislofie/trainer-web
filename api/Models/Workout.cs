
namespace api.Models;

public class Workout
{
    public int Id { get; set; }
    public string WorkoutName { get; set; } = string.Empty;
    
    public string CreatedById { get; set; }
    public AppUser CreatedBy { get; set; }
    
    public bool IsApproved { get; set; } = false;

    // navigation property for sets
    public ICollection<Set> Sets = new HashSet<Set>();
}
