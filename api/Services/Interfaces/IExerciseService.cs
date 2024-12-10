using api.DTOs.Exercise;
using api.DTOs.ExerciseLevel;
using api.Models;

namespace api.Services.Interfaces;

public interface IExerciseService
{
    public Task<List<Exercise>> GetAllAsync();
    public Task<Exercise> GetByIdAsync(int id);
    public Task<Exercise> UpdateByIdAsync(int id, UpdateExerciseRequestDto updateDto);
    public Task<Exercise> CreateAsync(CreateExerciseRequestDto createDto);

    public Task<List<ExerciseLevel>> GetExerciseLevelsAsync();
    public Task<ExerciseLevel?> CreateExerciseLevelAsync(CreateExerciseLevelRequestDto createDto);
}
