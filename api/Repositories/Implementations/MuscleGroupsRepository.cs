using api.Data;
using api.DTOs.MuscleGroups;
using api.Mappers;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations;

public class MuscleGroupsRepository : IMuscleGroupsRepository
{
    private ApplicationDbContext _context;
    public MuscleGroupsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MuscleGroup> CreateAsync(CreateMuscleGroupRequestDto createDto)
    {
        var muscleGroup = createDto.ToMuscleGroupFromCreateDTO();

        if (_context.MuscleGroup.Contains(muscleGroup))
            return null;

        _context.MuscleGroup.Add(muscleGroup);
        await _context.SaveChangesAsync();

        return muscleGroup;
    }

    public async Task<List<MuscleGroup>> GetAllAsync()
    {
        return await _context.MuscleGroup.ToListAsync();
    }
}
