using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Models;

namespace VegFoods.Data.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        protected readonly AppDbContext _context;
        public RecipeRepository(AppDbContext dbContext):base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Recipe>> GetAllWithCategoryAsync()
        {
            return await _context.Recipes.Include(a => a.Category).ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetAllWithCategoryByCategoryIdAsync(int CategoryId)
        {
            return await _context.Recipes.Include(a => a.Category).Where(x => x.CategoryId == CategoryId).ToListAsync();
        }
        public async Task<Recipe> GetByIdAsync(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        Task<IEnumerable<Recipe>> IRecipeRepository.GetAllWithCategoryAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Recipe>> IRecipeRepository.GetAllWithCategoryByCategoryIdAsync(int CategoryId)
        {
            throw new NotImplementedException();
        }

        Task<Recipe> IRecipeRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
