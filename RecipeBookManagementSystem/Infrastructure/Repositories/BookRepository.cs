using Application.Abstractions.Persistence;
using Core.Models;

namespace Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(string filePath) : base(filePath)
        {
        }
    }
}
