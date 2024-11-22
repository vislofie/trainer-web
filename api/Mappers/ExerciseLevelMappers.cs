using api.DTOs.ExerciseLevel;
using api.Models;

namespace api.Mappers;

public static class ExerciseLevelMappers
{
    public static ExerciseLevel ToExerciseLevel(this CreateExerciseLevelRequestDto createDto)
    {
        return new ExerciseLevel
        {
            Name = createDto.Name
        };
    }

    public static ExerciseLevelDto ToExerciseLevelDto(this ExerciseLevel exerciseLevel)
    {
        return new ExerciseLevelDto
        {
            Id = exerciseLevel.Id,
            Name = exerciseLevel.Name
        };
    }
}
