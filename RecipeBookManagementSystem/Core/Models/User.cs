using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User
    {
        private List<Book> _books { get; set; } = new();

        public User(int userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public void PublishBook(Book book) => _books.Add(book);
        public IEnumerable<Book> GetPublishedBooks() => _books;

        public override string ToString()
        {
            return $"ID: {UserId},\nName: {Name}";
        }
    }
}
