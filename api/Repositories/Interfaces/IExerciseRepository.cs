using api.DTOs.Exercise;
using api.DTOs.ExerciseLevel;
using api.Models;

namespace api.Repositories.Interfaces;

public interface IExerciseRepository
{
    public Task<List<Exercise>> GetAllAsync();
    public Task<Exercise> CreateAsync(CreateExerciseRequestDto dto);

    public Task<List<ExerciseLevel>> GetAllExerciseLevelsAsync();
    public Task<ExerciseLevel?> CreateExerciseLevelAsync(CreateExerciseLevelRequestDto createDto);
}
