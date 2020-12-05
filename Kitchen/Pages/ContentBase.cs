using Kitchen.Model;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Kitchen.Pages
{
    public class ContentBase : ComponentBase
    {
        [Parameter]
        public List<Ingredient> Ingredients { get; set; }

        [Parameter]
        public List<Instruction> Instructions { get; set; }
    }
}
