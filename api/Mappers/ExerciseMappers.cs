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
            IsApproved = false
        };
    }

    public static ExerciseDto ToExerciseDto(this Exercise exercise) 
    {
        return new ExerciseDto
        {
            Id = exercise.Id,
            Title = exercise.Title,
            Description = exercise.Description,
            PictureId = exercise.PictureId,
            VideoId = exercise.VideoId,
            IsApproved = exercise.IsApproved,
            ExerciseLevel = exercise.ExerciseLevel.ToExerciseLevelDto(),
            MuscleGroups = exercise.MuscleGroups.Select(mg => mg.ToMuscleGroupDTO()).ToArray()
        };
    }
}
