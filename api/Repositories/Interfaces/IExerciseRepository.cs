using System.Security.Claims;
using api.DTOs.Exercise;
using api.DTOs.ExerciseLevel;
using api.Models;

namespace api.Repositories.Interfaces;

public interface IExerciseRepository
{
    public Task<List<Exercise>> GetAllAsync();
    public Task<Exercise?> GetByIdAsync(int id);
    public Task<Exercise?> UpdateByIdAsync(int id, UpdateExerciseRequestDto updateDto);
    public Task<Exercise> CreateAsync(CreateExerciseServiceDto exercise);

    public Task<List<ExerciseLevel>> GetAllExerciseLevelsAsync();
    public Task<ExerciseLevel?> CreateExerciseLevelAsync(CreateExerciseLevelRequestDto createDto);
}
