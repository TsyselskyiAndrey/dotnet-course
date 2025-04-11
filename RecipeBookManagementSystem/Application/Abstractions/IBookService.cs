using Application.DTOs;

namespace Application.Abstractions
{
    public interface IBookService
    {
        void PublishBook(int userId, BookDto book);

        IEnumerable<BookDto> ViewAllBooks();

        BookDto? ReadBook(string title);

        IEnumerable<BookDto> FilterBooks(Func<BookDto, bool> filter);

        IEnumerable<BookDto> GetBooksByTitle(Predicate<string> titleFilter);

        IEnumerable<BookDto> GetBooksByAuthor(Predicate<string> authorFilter);
    }
}
