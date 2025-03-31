using Core.Models;

namespace Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>
    {
        public BookRepository(string filePath) : base(filePath)
        {
        }
    }
}
