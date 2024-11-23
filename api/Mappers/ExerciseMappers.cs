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

    public static ExerciseDto ToExerciseDto(this Exercise exercise) 
    {
        return new ExerciseDto
        {
            Id = exercise.Id,
            Title = exercise.Title,
            Description = exercise.Description,
            Picture = exercise.Picture,
            Video = exercise.Video,
            IsApproved = exercise.IsApproved,
            ExerciseLevel = exercise.ExerciseLevel.ToExerciseLevelDto(),
            MuscleGroups = exercise.MuscleGroups.Select(mg => mg.ToMuscleGroupDTO()).ToArray()
        };
    }
}
