namespace api.DTOs.Workout;

public class UpdateWorkoutRequestDto
{
    public string? WorkoutName { get; set; }

    public SetDto[]? Sets { get; set; }
}