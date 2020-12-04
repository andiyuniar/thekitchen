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
            HttpResponseMessage response = await httpClient.GetAsync("api/Recipe/GetRecipes");
            response.EnsureSuccessStatusCode();
            var jsonstr = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<ResponseModel<IEnumerable<Recipe>>>(jsonstr);

            return res.Data;
        }
    }
}
