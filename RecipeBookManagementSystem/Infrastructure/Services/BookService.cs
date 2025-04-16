using Application.Abstractions;
using Core.Models;

namespace Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IUserRepository _userRepository;

        public BookService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task PublishBookAsync(int userId, Book book)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            user.Books.Add(book);
            await _userRepository.UpdateUserAsync(user);
            Console.WriteLine($"Book '{book.Title}' published by {user.Name}!");
        }

        public async Task<IEnumerable<Book>> ViewAllBooksAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var books = users.SelectMany(u => u.Books);
            return books;
        }

        public async Task<Book?> ReadBookAsync(string title)
        {
            var books = await ViewAllBooksAsync();
            return books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<Book>> FilterBooksAsync(Func<Book, bool> filter)
        {
            var books = await ViewAllBooksAsync();
            return books.Where(filter);
        }

        public async Task<IEnumerable<Book>> GetBooksByTitleAsync(Predicate<string> titleFilter)
        {
            var books = await ViewAllBooksAsync();
            return books.Where(b => titleFilter(b.Title));
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(Predicate<string> authorFilter)
        {
            var books = await ViewAllBooksAsync();
            return books.Where(b => authorFilter(b.Author));
        }
    }
}
