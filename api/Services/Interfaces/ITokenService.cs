using api.Models;

namespace api.Services.Interfaces;

public interface ITokenService
{
    public Task<string> CreateTokenAsync(AppUser user);
}
