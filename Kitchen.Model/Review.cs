using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Model
{
    public class Review
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public Guid RecipeId { get; set; }
    }
}
