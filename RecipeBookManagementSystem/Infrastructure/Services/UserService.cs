using Application.Abstractions;
using Application.DTOs;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(string name)
        {
            var newUser = new UserDto();
            newUser.Name = name;
            _userRepository.AddUser(newUser);
        }

        public UserDto? GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public IEnumerable<UserDto>? GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
