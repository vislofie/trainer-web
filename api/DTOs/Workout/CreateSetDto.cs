namespace api.DTOs.Workout;

public class CreateSetDto
{
    public int ExerciseId { get; set; }

    public CreateSetItemDto[] Items { get; set; }
}