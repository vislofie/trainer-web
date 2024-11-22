namespace api.DTOs.Exercise;

public class CreateExerciseRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public string Video { get; set; }
    public int ExerciseLevelID { get; set; }
    public int[] MuscleGroupIDs { get; set; }
}
