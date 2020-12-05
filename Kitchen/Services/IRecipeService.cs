using Kitchen.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kitchen.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<RecipeDetail> GetRecipeById(string id);
    }
}
