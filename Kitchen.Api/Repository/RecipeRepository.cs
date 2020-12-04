using Kitchen.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kitchen.Api.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IMongoCollection<Recipe> _recipes;

        public RecipeRepository(IKitchenDbSetting settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);

            _recipes = database.GetCollection<Recipe>(settings.KitchenCollectionName);
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
    }
}
