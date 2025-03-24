using api.DTOs;
using api.DTOs.User;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("auth")]
[ApiController]
public class AuthorizationController : ControllerBase
{
    private enum UserRole
    {
        User,
        Admin
    }

    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signInManager;
    public AuthorizationController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AppUser user = await _userManager.Users.FirstOrDefaultAsync(usr => usr.Email.ToLower() == loginDto.Email.ToLower());

            if (user == null)
                return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized();

            return Ok (new AuthDto
            {
                Token = await _tokenService.CreateTokenAsync(user)
            });
        } 
        catch (Exception e) 
        {
            return StatusCode(500, e);
        }
        
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            

           AuthDto? dto = await CreateUserAsync(UserRole.User, registerDto.Email, registerDto.Username, registerDto.Password);

           if (dto == null)
           {
                return BadRequest("Mda");
           }
           
           return Ok(dto);
        } 
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }

    [HttpPost("registerAdmin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AuthDto? dto = await CreateUserAsync(UserRole.Admin, registerDto.Email, registerDto.Username, registerDto.Password);  

            if (dto == null)
            {
                return BadRequest();
            }
            
            return Ok(dto);
        } 
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }

    private async Task<AuthDto> CreateUserAsync(UserRole role, string email, string username, string password)
    {
        var roleName = role == UserRole.Admin ? "Admin" : "User";

        var appUser = new AppUser
        {
            Email = email,
            UserName = username
        };

        try
        {
            var createdUser = await _userManager.CreateAsync(appUser, password);
            
            if (!createdUser.Succeeded)
            {
                throw new Exception("Failed to create user: " + string.Join(", ", createdUser.Errors.Select(e => e.Description)));
            }

            var roleResult = await _userManager.AddToRoleAsync(appUser, roleName);
            
            if (!roleResult.Succeeded)
            {
                // If adding to role fails, delete the user
                await _userManager.DeleteAsync(appUser);
                throw new Exception("Failed to add user to role: " + string.Join(", ", roleResult.Errors.Select(e => e.Description)));
            }

            return new AuthDto
            {
                Token = await _tokenService.CreateTokenAsync(appUser)
            };
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"Error creating user: {ex.Message}");
            throw;
        }
    }
}
