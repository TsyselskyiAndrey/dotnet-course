using Application.Abstractions;
using Core.Models;

namespace Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new()
        {
            new User { Id = 1, Name = "Andrew" },
            new User { Id = 2, Name = "Sergey" },
            new User { Id = 3, Name = "Alex" }
        };

        public Task AddUserAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        public Task<User?> GetUserByIdAsync(int userId)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            return Task.FromResult(user);
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return Task.FromResult<IEnumerable<User>>(_users.ToList());
        }

        public Task<User> UpdateUserAsync(User updatedUser)
        {
            var index = _users.FindIndex(u => u.Id == updatedUser.Id);
            if (index != -1)
            {
                _users[index] = updatedUser;
            }

            return Task.FromResult(updatedUser);
        }
    }
}
