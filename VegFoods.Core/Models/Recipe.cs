using System;
using System.Collections.Generic;

namespace VegFoods.Core.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public int CategoryId { get; set; }
        
        public string Description { get; set; }
        public ICollection<Ingredient> Ingredients{ get; set; }

        public Category Category { get; set;}

        
    }
}
