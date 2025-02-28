namespace Core.Models
{
    public class Book
    {
        private List<Recipe> _recipes = new();

        public Book()
        {
            Title = string.Empty;
            Description = string.Empty;
            Author = string.Empty;
        }
        public Book(string title, string description, string author)
        {
            Title = title;
            Description = description;
            Author = author;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public void AddRecipe(Recipe recipe) => _recipes.Add(recipe);
        public IEnumerable<Recipe> GetRecipes() => _recipes;

        public override string ToString()
        {
            string result = $"Title: {Title}\nDescription: {Description}\nAuthor: {Author}\nRecipes: \n";
            foreach (var item in _recipes)
            {
                result += item.ToString() + "\n";
            }
            return result;
        }
    }
}