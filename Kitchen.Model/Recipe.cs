using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Model
{
    public class Recipe 
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public double Rating { get; set; }
    }
}
