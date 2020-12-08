using Kitchen.Services;
using Microsoft.AspNetCore.Components;

namespace Kitchen.Components
{
    public class ReviewFormBase : ComponentBase
    {
        [Inject]
        protected IRecipeService Service { get; set; }
        protected Model.Review Review { get; set; } = new Model.Review();

        [Parameter]
        public string RecipeId { get; set; }

        [Parameter]
        public EventCallback<bool>OnReviewCreated { get; set; }

        protected async void HandleValidSubmit()
        {
            Review.RecipeId = RecipeId;
            bool result = await Service.AddReview(Review);

            if (result)
            {
                Review = new Model.Review();
                StateHasChanged();
                await OnReviewCreated.InvokeAsync(true);
            }
        }
    }
}
