using Application.Abstractions;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new()
        {
            new User(1, "Andrew"),
            new User(2, "Sergey"),
            new User(3, "Alex")
        };

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User? GetUserById(int userId)
        {
            return _users.FirstOrDefault(u => u.UserId == userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }
    }
}
