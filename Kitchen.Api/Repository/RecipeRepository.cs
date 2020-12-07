using Kitchen.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kitchen.Api.Repository
{
    /// <summary>
    /// Provides methods to access database
    /// </summary>
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IMongoCollection<Recipe> _recipes;
        private readonly IMongoCollection<Review> _reviews;

        public RecipeRepository(IKitchenDbSetting settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);

            _recipes = database.GetCollection<Recipe>("Recipes");
            _reviews = database.GetCollection<Review>("Reviews");
        }

        /// <summary>
        /// Get all recipes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            try
            {
                return await _recipes.Find(data => data.Type == 0).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Cannot read to database");
            }
        }

        /// <summary>
        /// Get recipe by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Recipe> GetRecipeDetail(string id)
        {
            try
            {
                return await _recipes.Find(recipe => recipe.Id == id && recipe.Type == 0).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new Exception("Cannot read to database");
            }
        }

        public async Task AddReview(Review data)
        {
            try
            {
                await _reviews.InsertOneAsync(data);
            }
            catch (Exception)
            {
                throw new Exception("Cannot update to database");
            }
        }

        public async Task<IEnumerable<Review>> GetReviews(string recipeId)
        {
            try
            {
                return await _reviews.Find(data => data.RecipeId == recipeId).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Cannot read to database");
            }
        }
    }
}
