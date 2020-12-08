using Kitchen.Model;
using Kitchen.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Kitchen.Components
{
    public class ReviewListBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<Review> Reviews { get; set; }

    }
}
