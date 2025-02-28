namespace Core.Models
{
    public class Recipe
    {
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public Recipe()
        {
            Title = string.Empty;
            Ingredients = string.Empty;
            Instructions = string.Empty;
        }
        public Recipe(string title, string ingredients, string instructions)
        {
            Title=title;
            Ingredients=ingredients;
            Instructions=instructions;
        }

        public override string ToString()
        {
            string result = "-----------------------------------------------------------\n";
            result += $"Title: {Title}\nIngredients: {Ingredients}\nInstructions: {Instructions}\n";
            result += "-----------------------------------------------------------\n";
            return result;
        }
    }
}