using Kitchen.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kitchen.Api.Repository
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<Recipe> GetRecipeDetail(string Id);
        Task AddReview(Review data);
        Task<IEnumerable<Review>> GetReviews(string recipeId);
    }
}
