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
            MuscleGroups = exercise.MuscleGroups.Select(mg => mg.ToMuscleGroupDTO()).ToArray(),
            CreatedBy = exercise.CreatedById
        };
    }

    public static CreateExerciseServiceDto ToExerciseServiceDTO(this CreateExerciseRequestDto dto, string Id)
    {
        return new CreateExerciseServiceDto
        {
            Title = dto.Title,
            Description = dto.Description,
            CreatedById = Id,
            ExerciseLevelID = dto.ExerciseLevelID,
            MuscleGroupIDs = dto.MuscleGroupIDs,
            Picture = dto.Picture,
            Video = dto.Video
        };
    }

    public static Exercise ToExercise(this CreateExerciseServiceDto dto)
    {
        return new Exercise
        {
            Title = dto.Title,
            Description = dto.Description,
            IsApproved = false,
            CreatedById = dto.CreatedById
        };
    }
}
