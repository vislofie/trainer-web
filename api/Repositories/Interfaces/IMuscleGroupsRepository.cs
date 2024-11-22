using api.DTOs.MuscleGroups;
using api.Models;

namespace api.Repositories.Interfaces;

public interface IMuscleGroupsRepository
{
    public Task<List<MuscleGroup>> GetAllAsync();
    public Task<MuscleGroup> CreateAsync(CreateMuscleGroupRequestDto createDto);
}
