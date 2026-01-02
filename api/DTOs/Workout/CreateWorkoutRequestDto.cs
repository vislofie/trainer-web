namespace api.DTOs.Workout;

public class CreateWorkoutRequestDto
{
    public string WorkoutName { get; set; }

    public CreateSetDto[] Sets { get; set; }
}