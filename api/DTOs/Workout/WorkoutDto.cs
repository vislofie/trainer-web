namespace api.DTOs.Workout;

public class WorkoutDto
{
    public int Id { get; set; }
    public string WorkoutName { get; set; }
    public string CreatedById { get; set; }
    public bool IsApproved { get; set; }
    
    public SetDto[] Sets { get; set; }
}