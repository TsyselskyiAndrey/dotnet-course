using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IUserService
    {
        void RegisterUser(string name);
        User? GetUserById(int userId);
        IEnumerable<User>? GetAllUsers();
        void PublishBook(int userId, Book book);
        IEnumerable<Book> ViewAllBooks();
        Book? ReadBook(string title);
        void AddRecipe(string bookTitle, Recipe recipe);
    }
}
