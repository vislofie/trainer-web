using api.DTOs.Workout;
using api.Mappers;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("workouts")]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutService _workoutService;
    public WorkoutController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetWorkouts()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok((await _workoutService.GetAllAsync()).Select(w => w.ToWorkoutDto()));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddWorkout([FromBody] CreateWorkoutRequestDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var workoutModel = await _workoutService.CreateAsync(createDto);
        return Ok(workoutModel.ToWorkoutDto());
    }
}
