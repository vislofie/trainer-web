using api.DTOs.Exercise;
using api.Models;

namespace api.Mappers;

public static class ExerciseMappers
{
    public static Exercise ToExerciseFromCreateDTO(this CreateExerciseRequestDto createExerciseRequestDto)
    {
        return new Exercise
        {
            Title = createExerciseRequestDto.Title,
            Description = createExerciseRequestDto.Description,
            Picture = createExerciseRequestDto.Picture,
            Video = createExerciseRequestDto.Video,
            IsApproved = false
        };
    }
}
