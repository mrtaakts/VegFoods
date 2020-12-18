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
   public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        protected readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetAllWithRecipesAsync(int CategoryID)
        {
            // TODO: Repositoryi doldur!

            // return await _context.Categories.Include(a=> a.Recipes).SingleOrDefault(a=> a.Id == CategoryID);
            throw new NotImplementedException();
        }
    }
}
