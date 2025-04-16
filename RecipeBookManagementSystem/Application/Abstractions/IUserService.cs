using Core.Models;

namespace Application.Abstractions
{
    public interface IUserService
    {
        Task RegisterUserAsync(string name);

        Task<User?> GetUserByIdAsync(int userId);

        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
