namespace api.DTOs.Workout;

public class SetDto
{
    public int Id { get; set; }
    public int ExerciseId { get; set; }

    public SetItemDto[] Items { get; set; }
}