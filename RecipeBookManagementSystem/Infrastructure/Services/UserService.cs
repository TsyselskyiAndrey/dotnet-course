using Application.Abstractions;
using Core.Models;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUserAsync(string name)
        {
            var users = await _userRepository.GetAllUsersAsync();
            var newUser = new User
            {
                Id = users.Count() + 1,
                Name = name
            };

            await _userRepository.AddUserAsync(newUser);
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}
