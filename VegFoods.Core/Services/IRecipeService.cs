using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.Models;

namespace VegFoods.Core.Services
{
    public interface IRecipeService : IService<Recipe>
    {
        // TODO: SERVİSLER DÜZENLENECEK
        Task<IEnumerable<Recipe>> GetAllWithCategoryAsync();
        Task<Recipe> GetByIdAsync(int id);
        Task<IEnumerable<Recipe>> GetAllWithCategoryByCategoryIdAsync(int CategoryId);
    }
}
