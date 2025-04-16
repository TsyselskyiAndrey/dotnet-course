using Core.Models;

namespace Application.Abstractions
{
    public interface IRecipeService
    {
        Task AddRecipe(string bookTitle, Recipe recipe);
    }
}
