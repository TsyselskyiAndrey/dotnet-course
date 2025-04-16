using Application.Abstractions;
using Core.Models;

namespace Infrastructure.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IBookService _bookService;

        public RecipeService(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task AddRecipe(string bookTitle, Recipe recipe)
        {
            try
            {
                (await _bookService.ViewAllBooksAsync()).Where(b => b.Title == bookTitle).FirstOrDefault()?.Recipes.Add(recipe);
            }
            catch (Exception)
            {
                Console.WriteLine("No such a book!");
            }
        }
    }
}
