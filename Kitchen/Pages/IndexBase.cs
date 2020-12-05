using Kitchen.Model;
using Kitchen.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        protected IRecipeService RecipeService { get; set; }

        protected IEnumerable<Recipe> Recipes { get; set; }
        protected string Title { get; set; } = "This is title from backcode";

        protected override async Task OnInitializedAsync()
        {
            Recipes = (await RecipeService.GetRecipes()).ToList();
        }
    }
}
