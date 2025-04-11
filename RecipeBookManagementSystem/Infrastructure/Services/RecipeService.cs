using Application.Abstractions;
using Application.DTOs;
using Core.Models;
using Infrastructure.Mappers;

namespace Infrastructure.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IBookService _bookService;
        public RecipeService(IBookService bookService)
        {
            _bookService = bookService;
        }
        public void AddRecipe(string bookTitle, RecipeDto recipe)
        {
            try
            {
                var mapper = new Mapper<RecipeDto, Recipe>();
                Recipe res = mapper.Map(recipe);
                _bookService.ViewAllBooks().Where(b => b.Title == bookTitle).FirstOrDefault()?.Recipes.Add(res);
            }
            catch (Exception)
            {
                Console.WriteLine("No such a book!");
            }
        }
    }
}
