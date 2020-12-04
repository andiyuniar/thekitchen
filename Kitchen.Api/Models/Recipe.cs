using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Api.Models
{
    public class Recipe : RecipeBase
    {
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }

        public int Rating { get; set; }

        public List<Instruction> Instructions { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
