using api.DTOs.Exercise;
using api.DTOs.ExerciseLevel;
using api.Mappers;
using api.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/exercises")]
public class ExerciseController : ControllerBase
{
    private IExerciseRepository _exerciseRepository;
    public ExerciseController(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetExercises()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok((await _exerciseRepository.GetAllAsync()).Select(ex => ex.ToExerciseDto()));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddExercise([FromForm] CreateExerciseRequestDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var exerciseModel = await _exerciseRepository.CreateAsync(createDto);
        return Ok(exerciseModel.ToExerciseDto());
    }

    [HttpGet("levels")]
    [Authorize]
    public async Task<IActionResult> GetExerciseLevels()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var exerciseLevels = await _exerciseRepository.GetAllExerciseLevelsAsync();
        return Ok(exerciseLevels.Select(el => el.ToExerciseLevelDto()));
    }

    [HttpPost("levels")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddExerciseLevel([FromBody] CreateExerciseLevelRequestDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var exerciseLevel = await _exerciseRepository.CreateExerciseLevelAsync(createDto);
        if (exerciseLevel == null)
            return BadRequest("There is already an exercise level with this name!");
        
        return Ok(exerciseLevel.ToExerciseLevelDto());
    }
}
