using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegFoods.Api.DTO
{
    public class RecipeWithIngredientsDTO : RecipeDTO
    {
        public ICollection<IngredientDTO> Ingredients { get; set; }
    }
}
