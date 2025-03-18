using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User? GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
    }
}
