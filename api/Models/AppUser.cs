using Microsoft.AspNetCore.Identity;

namespace api.Models;

public class AppUser : IdentityUser
{
    // Exercise navigation property
    public ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
}
