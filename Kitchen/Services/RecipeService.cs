using Kitchen.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kitchen.Services
{
    /// <summary>
    /// Provides methods to call recipes REST endpoint
    /// </summary>
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient httpClient;
        public RecipeService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            HttpResponseMessage response = await httpClient.GetAsync("api/Recipe/GetRecipes");
            response.EnsureSuccessStatusCode();
            var jsonstr = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<ResponseModel<IEnumerable<Recipe>>>(jsonstr);

            return res.Data;
        }

        public async Task<RecipeDetail> GetRecipeById(string id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"api/Recipe/GetRecipeById?id={id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseModel<RecipeDetail>>(json);

            return result.Data;
        }

        public Task AddReview(Review review)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Review>> GetReviews(string recipeId)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"api/recipe/getreviews?id={recipeId}");
            response.EnsureSuccessStatusCode();
            var jsonstr = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseModel<IEnumerable<Review>>>(jsonstr);
            return result.Data;
        }
    }
}
