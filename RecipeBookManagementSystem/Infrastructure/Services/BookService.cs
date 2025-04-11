using Application.Abstractions;
using Application.DTOs;
using Core.Models;
using Infrastructure.Mappers;

namespace Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IUserRepository _userRepository;

        public BookService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void PublishBook(int userId, BookDto book)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }
            var mapper = new Mapper<BookDto, Book>();
            Book res = (Book)mapper.Map(book);
            user.Books.Add(res);
            Console.WriteLine($"Book '{book.Title}' published by {user.Name}!");
        }

        public IEnumerable<BookDto> ViewAllBooks()
        {
            List<Book> books = new List<Book>();
            foreach (var user in _userRepository.GetAllUsers())
            {
                books.AddRange(user.Books);
            }
            var mapper = new Mapper<Book, BookDto>();
            List<BookDto> res = (List<BookDto>)mapper.Map(books);
            return res;
        }

        public BookDto? ReadBook(string title)
        {
            return ViewAllBooks().Where(b => b.Title == title).FirstOrDefault();
        }

        public IEnumerable<BookDto> FilterBooks(Func<BookDto, bool> filter)
        {
            return ViewAllBooks().Where(b =>
            {
                return filter(b);
            });
        }

        public IEnumerable<BookDto> GetBooksByTitle(Predicate<string> titleFilter)
        {
            return ViewAllBooks().Where(b => titleFilter(b.Title));
        }

        public IEnumerable<BookDto> GetBooksByAuthor(Predicate<string> authorFilter)
        {
            return ViewAllBooks().Where(b => authorFilter(b.Author));
        }
    }
}
