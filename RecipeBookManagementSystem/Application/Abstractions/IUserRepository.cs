using Core.Models;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);

        Task<User?> GetUserByIdAsync(int userId);

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> UpdateUserAsync(User user);
    }
}
