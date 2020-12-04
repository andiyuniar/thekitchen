using System.Collections.Generic;

namespace Kitchen.Model
{
    public class RecipeDetail : Recipe
    {
        public List<Instruction> Instructions { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
