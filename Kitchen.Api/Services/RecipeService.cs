using Kitchen.Api.Repository;
using Kitchen.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            if (dbRecipes != null && dbRecipes.Count > 0)
            {
                foreach(var item in dbRecipes)
                {
                    Kitchen.Model.Recipe recipe = new Recipe();
                    recipe.Id = item.Id;
                    recipe.Title = item.Title;
                    recipe.ImgUrl = item.ImgUrl;
                    recipe.Rating = item.Rating;

                    result.Add(recipe);
                }
            }
            return result;
        }

        public async Task<RecipeDetail> GetRecipeDetail(string id)
        {
            RecipeDetail result = new RecipeDetail();
            var recipe = await repo.GetRecipeDetail(id);

            if (recipe != null)
            {
                result.Id = recipe.Id;
                result.Title = recipe.Title;
                result.ImgUrl = recipe.ImgUrl;
                result.Description = recipe.Description;
                result.Rating = recipe.Rating;
                if (recipe.Ingredients != null)
                {
                    foreach(var item in recipe.Ingredients)
                    {
                        Ingredient ingredient = new Ingredient
                        {
                            Item = item.Item,
                            Quantity = item.Quantity
                        };
                        result.Ingredients.Add(ingredient);
                    }
                }
                if (recipe.Instructions != null)
                {
                    foreach(var data in recipe.Instructions)
                    {
                        Instruction instruction = new Instruction
                        {
                            Step = data.Step,
                            Description = data.Description
                        };
                        result.Instructions.Add(instruction);
                    }
                }
            }
            return result;
        }

        public async Task AddReview(Kitchen.Model.Review review)
        {
            Kitchen.Api.Models.Review dbReview = new Models.Review
            {
                Name = review.Name,
                Email = review.Email,
                Description = review.Description,
                Rating = review.Rating,
                RecipeId = review.RecipeId
            };

            await repo.AddReview(dbReview);
        }

        public async Task<IEnumerable<Review>> GetReviews(string id)
        {
            List<Review> result = new List<Review>();
            var reviews = (await repo.GetReviews(id)).ToList();
            if(reviews != null && reviews.Count > 0)
            {
                foreach(var review in reviews)
                {
                    Review _review = new Review
                    {
                        Name = review.Name,
                        Email = review.Email,
                        Description = review.Description,
                        Rating = review.Rating,
                        RecipeId = review.RecipeId
                    };
                    result.Add(_review);
                }
            }
            return result;
        }
    }
}
