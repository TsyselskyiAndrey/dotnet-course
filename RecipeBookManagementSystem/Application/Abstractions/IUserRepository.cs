using Application.DTOs;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        void AddUser(UserDto user);

        UserDto? GetUserById(int userId);

        IEnumerable<UserDto> GetAllUsers();
    }
}
