using api.DTOs.ExerciseLevel;
using api.DTOs.MuscleGroups;

namespace api.DTOs.Exercise;

public class ExerciseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PictureId { get; set; }
    public int VideoId { get; set; }
    public bool IsApproved { get; set; } = false;

    public ExerciseLevelDto ExerciseLevel { get; set; }
    public ICollection<MuscleGroupDto> MuscleGroups { get; set; }
}
