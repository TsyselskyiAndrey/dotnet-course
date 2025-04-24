using Application.DTOs;

namespace Application.Abstractions
{
    public interface IRecipeService
    {
        void AddRecipe(string bookTitle, RecipeDto recipe);
    }
}
