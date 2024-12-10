using System.Security.Claims;
using api.DTOs.Exercise;
using api.DTOs.ExerciseLevel;
using api.Extensions;
using api.Mappers;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services.Implementations;

public class ExerciseService : IExerciseService
{
    private ClaimsPrincipal User => _contextAccessor.HttpContext.User;

    private readonly IExerciseRepository _exerciseRepository;
    private readonly IHttpContextAccessor _contextAccessor;
    public ExerciseService(IExerciseRepository exerciseRepository, IHttpContextAccessor contextAccessor)
    {
        _exerciseRepository = exerciseRepository;
        _contextAccessor = contextAccessor;
    }

    public async Task<List<Exercise>> GetAllAsync()
    {
        var exercises = await _exerciseRepository.GetAllAsync();

        if (User.IsAdmin())
        {
            return exercises;
        }
        else
        {
            return exercises.Where(ex => ex.CreatedById == User.GetId() || ex.IsApproved).ToList();
        }
    }

    public async Task<Exercise> GetByIdAsync(int id)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(id);

        if (User.IsAdmin())
        {
            return exercise;
        }
        else
        {
            if (exercise.CreatedById == User.GetId() || exercise.IsApproved)
            {
                return exercise;
            }

            throw new Exception("Exercise not found!");
        }
    }

    public async Task<Exercise> UpdateByIdAsync(int id, UpdateExerciseRequestDto updateDto)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(id);
        if (exercise.CreatedById != User.GetId() && !User.IsAdmin())
        {
            throw new UnauthorizedAccessException();
        }

        if (User.IsAdmin() && (exercise.IsApproved || exercise.CreatedById == User.GetId()))
        {
            exercise = await _exerciseRepository.UpdateByIdAsync(id, updateDto);

            return exercise;
        }

        throw new Exception();
    }

    public async Task<Exercise> CreateAsync(CreateExerciseRequestDto createDto)
    {
        var exerciseDto = createDto.ToExerciseServiceDTO(User.GetId());
        var exercise = await _exerciseRepository.CreateAsync(exerciseDto);
        if (exercise == null)
        {
            throw new Exception("Failed to create exercise!");
        }

        return exercise;
    }

    public async Task<ExerciseLevel?> CreateExerciseLevelAsync(CreateExerciseLevelRequestDto createDto)
    {
        var exerciseLevel = await _exerciseRepository.CreateExerciseLevelAsync(createDto);
        if (exerciseLevel == null)
        {
            throw new Exception("Failed to create exercise level!");
        }

        return exerciseLevel;
    }

    public async Task<List<ExerciseLevel>> GetExerciseLevelsAsync()
    {
        var exerciseLevels = await _exerciseRepository.GetAllExerciseLevelsAsync();
        if (exerciseLevels == null)
        {
            throw new Exception("Failed to get exercise levels!");
        }

        return exerciseLevels;
    }
}
