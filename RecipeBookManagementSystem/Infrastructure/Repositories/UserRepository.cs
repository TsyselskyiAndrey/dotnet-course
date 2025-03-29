using Application.Abstractions.Persistence;
using Core.Models;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(string filePath) : base(filePath)
        {
        }
    }
}
