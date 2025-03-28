using Application.Abstractions.Persistence;
using Core.Models;

namespace Infrastructure.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(string filePath) : base(filePath)
        {
        }
    }
}
