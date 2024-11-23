namespace api.DTOs.Exercise;

public class CreateExerciseRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile Picture { get; set; }
    public IFormFile Video { get; set; }
    public int ExerciseLevelID { get; set; }
    public int[] MuscleGroupIDs { get; set; }
}
