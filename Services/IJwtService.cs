using LoginSystem.Models;

namespace LoginSystem.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
} 