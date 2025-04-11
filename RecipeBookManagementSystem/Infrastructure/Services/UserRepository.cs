using Application.Abstractions;
using Application.DTOs;
using Core.Models;
using Infrastructure.Mappers;

namespace Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new()
        {
            new User
            {
                Id = 1,
                Name = "Andrew"
            },
            new User
            {
                Id = 2,
                Name = "Sergey"
            },
            new User
            {
                Id = 3,
                Name = "Alex"
            }
        };

        public void AddUser(UserDto user)
        {
            var mapper = new Mapper<UserDto, User>();
            User res = mapper.Map(user);
            res.Id = _users.Count + 1;
            _users.Add(res);
        }

        public UserDto? GetUserById(int userId)
        {
            var mapper = new Mapper<User, UserDto>();
            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return null;
            }
            UserDto res = mapper.Map(user);
            return res;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var mapper = new Mapper<User, UserDto>();
            List<UserDto> res = mapper.Map(_users);
            return res;
        }
    }
}
