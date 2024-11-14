using api.Models;

namespace api.Services.Interfaces;

public interface ITokenService
{
    public string CreateToken(AppUser user);
}
