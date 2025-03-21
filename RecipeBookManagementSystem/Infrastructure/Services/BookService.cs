using Application.Abstractions;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IUserRepository _userRepository;

        public BookService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void PublishBook(int userId, Book book)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            user.Books.Add(book);
            Console.WriteLine($"Book '{book.Title}' published by {user.Name}!");
        }

        public IEnumerable<Book> ViewAllBooks()
        {
            List<Book> books = new List<Book>();
            foreach (var user in _userRepository.GetAllUsers())
            {
                books.AddRange(user.Books);
            }
            return books;
        }

        public Book? ReadBook(string title)
        {
            return ViewAllBooks().Where(b => b.Title == title).FirstOrDefault();
        }

        public IEnumerable<Book> FilterBooks(Func<Book, bool> filter)
        {
            return ViewAllBooks().Where(b => filter(b));
        }

        public IEnumerable<Book> GetBooksByTitle(Predicate<string> titleFilter)
        {
            return ViewAllBooks().Where(b => titleFilter(b.Title));
        }

        public IEnumerable<Book> GetBooksByAuthor(Predicate<string> authorFilter)
        {
            return ViewAllBooks().Where(b => authorFilter(b.Author));
        }
    }
}
