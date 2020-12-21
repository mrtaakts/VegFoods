using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VegFoods.Core.Models
{
    public class Recipe
    {
        public Recipe()
        {
            Ingredients = new Collection<Ingredient>();
        }
        public int Id { get; set; }
        public string Name { get; set;}
        public int CategoryId { get; set; }
        
        public string Description { get; set; }
        public ICollection<Ingredient> Ingredients{ get; set; }

        public Category Category { get; set;}

        
    }
}
