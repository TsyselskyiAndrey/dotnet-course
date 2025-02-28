using Application.Abstractions;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var newUser = new User(_userRepository.GetAllUsers().Count() + 1, name);
            _userRepository.AddUser(newUser);
        }

        public User? GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public void PublishBook(int userId, Book book)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            user.PublishBook(book);
            Console.WriteLine($"Book '{book.Title}' published by {user.Name}!");
        }

        public IEnumerable<Book> ViewAllBooks()
        {
            List<Book> books = new List<Book>();
            foreach (var user in _userRepository.GetAllUsers())
            {
                books.AddRange(user.GetPublishedBooks());
            }
            return books;
        }

        public Book? ReadBook(string title)
        {
            return ViewAllBooks().Where(b => b.Title == title).FirstOrDefault();
        }

        public IEnumerable<User>? GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void AddRecipe(string bookTitle, Recipe recipe)
        {
            try
            {
                ViewAllBooks().Where(b => b.Title == bookTitle).FirstOrDefault().AddRecipe(recipe);
            }
            catch (Exception)
            {
                Console.WriteLine("No such a book!");
            }
        }
    }
}
