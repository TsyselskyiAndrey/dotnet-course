namespace Core.Models
{
    public class Recipe
    {
        public string Title { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public List<Instruction> Instructions { get; set; } = new List<Instruction>();
    }
}