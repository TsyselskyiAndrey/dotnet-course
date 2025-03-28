using Application.Abstractions.Persistence;
using Core.Models;

namespace Infrastructure.Repositories
{
    public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(string filePath) : base(filePath)
        {
        }
    }
}
