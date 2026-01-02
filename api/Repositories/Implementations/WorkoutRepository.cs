using api.DTOs.Workout;
using api.Infrastructure;
using api.Mappers;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly ApplicationDbContext _context;
    public WorkoutRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Workout>> GetAllAsync()
    {
        return await _context.Workouts
            .Include(w => w.Sets)
            .ToListAsync();
    }

    public async Task<Workout?> GetByIdAsync(int id)
    {
        return await _context.Workouts
            .Include(w => w.Sets)
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public Task<Workout?> UpdateByIdAsync(int id, UpdateWorkoutRequestDto updateDto)
    {
        throw new NotImplementedException();
    }

    public async Task<Workout> CreateAsync(CreateWorkoutServiceDto createDto)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var workout = createDto.ToWorkout();
                
                foreach (var setDto in createDto.Sets)
                {
                    workout.Sets.Add(await CreateSetAsync(0, setDto, false));
                }
                
                await _context.Workouts.AddAsync(workout);
                await _context.SaveChangesAsync();
                
                await transaction.CommitAsync();
                
                return workout;
            } catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
            if (workout == null)
                throw new Exception("Workout not found!");

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
        } catch
        {
            throw;  
        }
    }

    public async Task<Set> CreateSetAsync(int workoutId, CreateSetDto setDto, bool saveChanges = true)
    {
        var set = setDto.ToSet(workoutId);
        
        foreach (var setItem in setDto.Items)
        {
            set.Items.Add(await CreateSetItemAsync(0, setItem, false));
        }
        
        await _context.Set.AddAsync(set);
        if (saveChanges)
            await _context.SaveChangesAsync();
        
        return set;
    }

    public async Task<SetItem> CreateSetItemAsync(int setId, CreateSetItemDto setItemDto, bool saveChanges = true)
    {
        var setItem = setItemDto.ToSetItem(setId);
        
        await _context.SetItems.AddAsync(setItem);
        if (saveChanges)
            await _context.SaveChangesAsync();
        
        return setItem;
    }
}