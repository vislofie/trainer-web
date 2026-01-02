using api.DTOs.Workout;
using api.Models;

namespace api.Services.Interfaces;

public interface IWorkoutService
{
    public Task<List<Workout>> GetAllAsync();
    public Task<Workout> GetByIdAsync(int id);
    public Task<Workout> UpdateByIdAsync(int id, UpdateWorkoutRequestDto updatedto);
    public Task<Workout> CreateAsync(CreateWorkoutRequestDto createDto);
    public Task DeleteWorkoutAsync(int id);
}