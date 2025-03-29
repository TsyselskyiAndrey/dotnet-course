using Core.Models.Common;

namespace Core.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; } 

        public string Description { get; set; }

        public string Author { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}