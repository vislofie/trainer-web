using System.Security.Claims;
using api.DTOs.Workout;
using api.Extensions;
using api.Mappers;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;

namespace api.Services.Implementations;

public class WorkoutService : IWorkoutService
{
    private ClaimsPrincipal User => _contextAccessor.HttpContext.User;
    
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IHttpContextAccessor _contextAccessor;
    public WorkoutService(IWorkoutRepository workoutRepository, IHttpContextAccessor contextAccessor)
    {
        _workoutRepository = workoutRepository;
        _contextAccessor = contextAccessor;
    }
    
    public async Task<List<Workout>> GetAllAsync()
    {
        var workouts = await _workoutRepository.GetAllAsync();

        if (User.IsAdmin())
        {
            return workouts;
        }
        else
        {
            return workouts.Where(w => w.CreatedById == User.GetId() || w.IsApproved).ToList();
        }
    }

    public Task<Workout> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Workout> UpdateByIdAsync(int id, UpdateWorkoutRequestDto updatedto)
    {
        throw new NotImplementedException();
    }

    public async Task<Workout> CreateAsync(CreateWorkoutRequestDto createDto)
    {
        var workoutDto = createDto.ToCreateWorkoutServiceDto(User.GetId());
        var workout = await _workoutRepository.CreateAsync(workoutDto);
        if (workout == null)
        {
            throw new Exception("Failed to create workout!");
        }
        
        return workout;
    }

    public async Task DeleteWorkoutAsync(int id)
    {
        try
        {
            var workout = await _workoutRepository.GetByIdAsync(id);
            if (workout == null)
                throw new Exception("Workout not found!");

            if (workout.IsApproved)
            {
                if (!User.IsAdmin())
                    throw new Exception("You have no permission to delete approved workouts!");

                await _workoutRepository.DeleteAsync(id);
            }
            else
            {
                if (workout.CreatedById != User.GetId())
                    throw new Exception();

                await _workoutRepository.DeleteAsync(id);
            }
        }
        catch
        {
            throw;
        }
    }
}