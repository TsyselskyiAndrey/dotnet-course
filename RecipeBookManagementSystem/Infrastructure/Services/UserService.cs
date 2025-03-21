using Application.Abstractions;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

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
            var newUser = new User();
            newUser.UserId = _userRepository.GetAllUsers().Count() + 1;
            newUser.Name = name;
            _userRepository.AddUser(newUser);
        }

        public User? GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public IEnumerable<User>? GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
