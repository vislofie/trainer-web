using api.DTOs;
using api.DTOs.User;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/auth")]
[ApiController]
public class AccountController : ControllerBase
{
    private enum UserRole
    {
        User,
        Admin
    }

    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signInManager;
    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
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
                Token = _tokenService.CreateToken(user)
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

    private async Task<AuthDto?> CreateUserAsync(UserRole role, string email, string username, string password)
    {
        var appUser = new AppUser
        {
            Email = email,
            UserName = username
        };

        var createdUser = await _userManager.CreateAsync(appUser, password);

        if (createdUser.Succeeded)
        {
            var roleResult = await _userManager.AddToRoleAsync(appUser, role == UserRole.Admin ? "Admin" : "User");
            if (roleResult.Succeeded)
            {
                return new AuthDto
                {
                    Token = _tokenService.CreateToken(appUser)
                };
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}
