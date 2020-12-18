using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;
using VegFoods.Core.Services;
using VegFoods.Core.UnitOfWork;

namespace VegFoods.Services.Services
{
    public class RecipeService : Service<Recipe>, IRecipeService
    {
        public RecipeService(IUnitOfWork unitOfWork, IRepository<Recipe> repository) : base(unitOfWork, repository)
        {

        }
        public Task<IEnumerable<Recipe>> GetAllWithCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetAllWithCategoryByCategoryIdAsync(int CategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
