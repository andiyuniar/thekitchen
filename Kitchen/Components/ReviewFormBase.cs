using Microsoft.AspNetCore.Components;

namespace Kitchen.Components
{
    public class ReviewFormBase : ComponentBase
    {
        protected Kitchen.Model.Review Review { get; set; } = new Model.Review();

        [CascadingParameter]
        public string RecipeId { get; set; }

        protected void HandleValidSubmit()
        {

        }
    }
}
