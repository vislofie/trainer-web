namespace api.DTOs.Workout;

public class CreateWorkoutServiceDto
{
    public string WorkoutName { get; set; }

    public CreateSetDto[] Sets { get; set; }
    
    public string CreatedById { get; set; }
}