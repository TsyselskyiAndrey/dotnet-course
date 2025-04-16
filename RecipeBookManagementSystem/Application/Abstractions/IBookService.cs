using Core.Models;

namespace Application.Abstractions
{
    public interface IBookService
    {
        Task PublishBookAsync(int userId, Book book);

        Task<IEnumerable<Book>> ViewAllBooksAsync();

        Task<Book?> ReadBookAsync(string title);

        Task<IEnumerable<Book>> FilterBooksAsync(Func<Book, bool> filter);

        Task<IEnumerable<Book>> GetBooksByTitleAsync(Predicate<string> titleFilter);

        Task<IEnumerable<Book>> GetBooksByAuthorAsync(Predicate<string> authorFilter);

    }
}
