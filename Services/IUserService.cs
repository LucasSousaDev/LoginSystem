using LoginSystem.Models;

namespace LoginSystem.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateUser(string username, string password);
        Task<User> CreateUser(User user, string password);
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
