using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.MuscleGroups;
using api.Mappers;
using api.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("muscle-groups")]
public class MuscleGroupController : ControllerBase
{
    private IMuscleGroupsRepository _muscleGroupsRepository;
    public MuscleGroupController(IMuscleGroupsRepository muscleGroupsRepository)
    {
        _muscleGroupsRepository = muscleGroupsRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetMuscleGroups()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var muscleGroups = await _muscleGroupsRepository.GetAllAsync();

        return Ok(muscleGroups.Select(mg => mg.ToMuscleGroupDTO()));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddMuscleGroup([FromBody] CreateMuscleGroupRequestDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var muscleGroup = await _muscleGroupsRepository.CreateAsync(createDto);
        if (muscleGroup == null)
            return BadRequest("Muscle group already exists!");

        return Ok(muscleGroup.ToMuscleGroupDTO());
    }

}
