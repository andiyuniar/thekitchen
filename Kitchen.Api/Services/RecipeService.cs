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

        private double GetRatingAverage(List<Kitchen.Api.Models.Review> review)
        {
            return review.Select(r => r.Rating).DefaultIfEmpty(0).Average();
        }
    }
}
