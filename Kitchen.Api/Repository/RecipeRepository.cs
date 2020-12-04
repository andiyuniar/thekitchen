using Kitchen.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            try
            {
                return await _recipes.Find(data => data.Type == 0).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot read to database");
            }
        }
    }
}
