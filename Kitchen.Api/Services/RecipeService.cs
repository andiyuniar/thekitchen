using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.Api.Repository;
using Kitchen.Model;

namespace Kitchen.Api.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository repo;
        public RecipeService(IRecipeRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            List<Recipe> result = new List<Recipe>();
            var dbRecipes = (await repo.GetRecipes()).ToList();

            if (dbRecipes.Count > 0)
            {
                foreach(var item in dbRecipes)
                {
                    Kitchen.Model.Recipe recipe = new Recipe();
                    recipe.Title = item.Title;
                    recipe.ImgUrl = item.ImgUrl;
                    recipe.Rating = item.Rating;

                    result.Add(recipe);
                }
            }
            return result;
        }

        private double GetRatingAverage(List<Kitchen.Api.Models.Review> review)
        {
            return review.Select(r => r.Rating).DefaultIfEmpty(0).Average();
        }
    }
}
