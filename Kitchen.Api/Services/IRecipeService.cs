using Kitchen.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kitchen.Api.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<RecipeDetail> GetRecipeDetail(string id);
    }
}
