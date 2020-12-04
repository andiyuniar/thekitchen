using System.Collections.Generic;

namespace Kitchen.Model
{
    public class RecipeDetail : Recipe
    {
        public RecipeDetail()
        {
            Ingredients = new List<Ingredient>();
            Instructions = new List<Instruction>();
        }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Instruction> Instructions { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
