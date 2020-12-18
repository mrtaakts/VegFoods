using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.Models;

namespace VegFoods.Core.IRepositories
{
   public interface IRecipeRepository: IRepository<Recipe>
    {
        Task<IEnumerable<Recipe>> GetAllWithCategoryAsync();
        Task<Recipe> GetByIdAsync(int id);
        Task<IEnumerable<Recipe>> GetAllWithCategoryByCategoryIdAsync(int CategoryId);
    }
}

