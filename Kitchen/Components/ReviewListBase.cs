using Kitchen.Model;
using Kitchen.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Components
{
    public class ReviewListBase : ComponentBase
    {
        [CascadingParameter]
        public string RecipeId { get; set; }

        protected IEnumerable<Review> Reviews { get; set; }

        [Inject]
        protected IRecipeService service { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Reviews = (await service.GetReviews(RecipeId)).ToList();
        }
    }
}
