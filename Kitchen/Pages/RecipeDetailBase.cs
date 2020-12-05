using Kitchen.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Kitchen.Pages
{
    public class RecipeDetailBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        protected IRecipeService RecipeService { get; set; }

        protected Kitchen.Model.RecipeDetail Recipe { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Recipe = await RecipeService.GetRecipeById(Id);
        }
    }
}
