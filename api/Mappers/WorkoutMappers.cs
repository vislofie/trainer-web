using api.DTOs.Workout;
using api.Models;

namespace api.Mappers;

public static class WorkoutMappers
{
    public static Workout ToWorkout(this CreateWorkoutServiceDto createDto)
    {
        return new Workout
        {
            WorkoutName = createDto.WorkoutName,
            CreatedById = createDto.CreatedById
        };
    }

    public static WorkoutDto ToWorkoutDto(this Workout workout)
    {
        return new WorkoutDto
        {
            Id = workout.Id,
            WorkoutName = workout.WorkoutName,
            CreatedById = workout.CreatedById,
            IsApproved = workout.IsApproved,
            
            Sets = workout.Sets.Select(set => set.ToDto()).ToArray()
        };
    }

    public static CreateWorkoutServiceDto ToCreateWorkoutServiceDto(this CreateWorkoutRequestDto requestDto,
        string creatorId)
    {
        return new CreateWorkoutServiceDto
        {
            WorkoutName = requestDto.WorkoutName,
            CreatedById = creatorId,
            Sets = requestDto.Sets
        };
    }

    public static Set ToSet(this CreateSetDto setDto, int workoutId)
    {
        return new Set
        {
            ExerciseId = setDto.ExerciseId,
            WorkoutId = workoutId
        };
    }

    public static SetDto ToDto(this Set set)
    {
        return new SetDto
        {
            Id = set.Id,
            ExerciseId = set.ExerciseId,
            Items = set.Items.Select(items => items.ToDto()).ToArray()
        };
    }

    public static SetItem ToSetItem(this CreateSetItemDto setItemDto, int setId)
    {
        return new SetItem
        {
            Weight = setItemDto.Weight,
            Repetitions = setItemDto.Repetitions,
            ItemNumber = setItemDto.ItemNumber,
            SetId = setId
        };
    }

    public static SetItemDto ToDto(this SetItem setItem)
    {
        return new SetItemDto
        {
            Id = setItem.Id,
            Weight = setItem.Weight,
            Repetitions = setItem.Repetitions,
            ItemNumber = setItem.ItemNumber
        };
    }
}
    