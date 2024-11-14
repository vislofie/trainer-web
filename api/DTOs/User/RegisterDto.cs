using System.ComponentModel.DataAnnotations;

namespace api.DTOs.User;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
}
