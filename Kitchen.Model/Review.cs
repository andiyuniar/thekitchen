using System;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Model
{
    public class Review
    {
        [Required]
        [MinLength(4, ErrorMessage = "Name length should be 4 or more characters")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required]
        public string Email { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string RecipeId { get; set; }
    }
}
