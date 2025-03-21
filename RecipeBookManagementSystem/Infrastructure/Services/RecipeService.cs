using Application.Abstractions;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IBookService _bookService;
        public RecipeService(IBookService bookService)
        {
            _bookService = bookService;
        }
        public void AddRecipe(string bookTitle, Recipe recipe)
        {
            try
            {
                _bookService.ViewAllBooks().Where(b => b.Title == bookTitle).FirstOrDefault()?.Recipes.Add(recipe);
            }
            catch (Exception)
            {
                Console.WriteLine("No such a book!");
            }
        }
    }
}
