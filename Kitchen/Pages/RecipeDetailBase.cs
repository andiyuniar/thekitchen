using Kitchen.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kitchen.Pages
{
    public class RecipeDetailBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        protected IRecipeService RecipeService { get; set; }

        protected Model.RecipeDetail Recipe { get; set; }

        protected IEnumerable<Model.Review> Reviews { get; set; }

        protected async Task ReviewCreated()
        {
            Reviews = await RecipeService.GetReviews(Id);
        }

        protected override async Task OnInitializedAsync()
        {
            Recipe = await RecipeService.GetRecipeById(Id);
            Reviews = await RecipeService.GetReviews(Id);
        }
    }
}
