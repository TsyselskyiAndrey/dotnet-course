using Core.Models;

namespace Application.DTOs
{
    public class UserDto
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
