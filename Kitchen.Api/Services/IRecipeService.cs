using Kitchen.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kitchen.Api.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<RecipeDetail> GetRecipeDetail(string id);
        Task AddReview(Review review);
        Task<IEnumerable<Review>> GetReviews(string id);
    }
}
