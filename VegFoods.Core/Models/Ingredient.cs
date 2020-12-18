using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VegFoods.Core.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public int Piece { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public ICollection<Recipe> Recipes { get; set; }
    }
}
