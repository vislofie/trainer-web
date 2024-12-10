using System.Security.Claims;

namespace api.Extensions;

public static class UserExtensions
{
    public static bool IsAdmin(this ClaimsPrincipal user)
    {
        return user.IsInRole("ADMIN");
    }

    public static string GetId(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
