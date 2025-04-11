using Application.DTOs;

namespace Application.Abstractions
{
    public interface IUserService
    {
        void RegisterUser(string name);

        UserDto? GetUserById(int userId);

        IEnumerable<UserDto>? GetAllUsers();
    }
}
