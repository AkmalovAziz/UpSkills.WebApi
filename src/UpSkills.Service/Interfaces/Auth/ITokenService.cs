using UpSkills.Domain.Entities.Users;

namespace UpSkills.Service.Interfaces.Auth;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);
}