using Kitchen.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kitchen.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient httpClient;
        public RecipeService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            HttpResponseMessage response = await httpClient.GetAsync("api/recipe");
            response.EnsureSuccessStatusCode();
            var jsonstr = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<ResponseModel<Recipe>>(jsonstr);

            return res.Data;
        }
    }
}
