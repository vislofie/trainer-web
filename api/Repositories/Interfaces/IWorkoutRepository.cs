using api.DTOs.Workout;
using api.Models;

namespace api.Repositories.Interfaces;

public interface IWorkoutRepository
{
    public Task<List<Workout>> GetAllAsync();
    public Task<Workout?> GetByIdAsync(int id);
    public Task<Workout?> UpdateByIdAsync(int id, UpdateWorkoutRequestDto updateDto);
    public Task<Workout> CreateAsync(CreateWorkoutServiceDto createDto);
    public Task DeleteAsync(int id);
    
    public Task<Set> CreateSetAsync(int workoutId, CreateSetDto setDto, bool saveChanges = true);
    public Task<SetItem> CreateSetItemAsync(int setId, CreateSetItemDto setItemDto, bool saveChanges = true);
}