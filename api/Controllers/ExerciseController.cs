using api.DTOs.Exercise;
using api.DTOs.ExerciseLevel;
using api.Mappers;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("exercises")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;
    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetExercises()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok((await _exerciseService.GetAllAsync()).Select(ex => ex.ToExerciseDto()));
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetExerciseById(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var exercise = await _exerciseService.GetByIdAsync(id);
        if (exercise == null)
            return BadRequest("No exercise with this id!");

        return Ok(exercise.ToExerciseDto());
    }

    [HttpPut("{id:int}")]
    [Authorize]
    [RequestSizeLimit(100_000_000)]
    public async Task<IActionResult> UpdateExerciseById(int id, [FromForm] UpdateExerciseRequestDto updateDto)
    {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _exerciseService.UpdateByIdAsync(id, updateDto);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> DeleteExerciseById(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        await _exerciseService.DeleteExerciseAsync(id);
        return Ok();
    }

    [HttpPost]
    [Authorize]
    [RequestSizeLimit(100_000_000)]
    public async Task<IActionResult> AddExercise([FromForm] CreateExerciseRequestDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var exerciseModel = await _exerciseService.CreateAsync(createDto);
        return Ok(exerciseModel.ToExerciseDto());
    }

    [HttpGet("levels")]
    [Authorize]
    public async Task<IActionResult> GetExerciseLevels()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var exerciseLevels = await _exerciseService.GetExerciseLevelsAsync();
        return Ok(exerciseLevels.Select(el => el.ToExerciseLevelDto()));
    }

    [HttpPost("levels")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddExerciseLevel([FromBody] CreateExerciseLevelRequestDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var exerciseLevel = await _exerciseService.CreateExerciseLevelAsync(createDto);
        if (exerciseLevel == null)
            return BadRequest("There is already an exercise level with this name!");
        
        return Ok(exerciseLevel.ToExerciseLevelDto());
    }
}
