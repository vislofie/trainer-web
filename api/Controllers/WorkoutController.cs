using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/workouts")]
public class WorkoutController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetWorkouts()
    {
        return Ok();
    }
}
