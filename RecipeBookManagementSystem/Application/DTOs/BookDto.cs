using Core.Models;

namespace Application.DTOs
{
    public class BookDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
