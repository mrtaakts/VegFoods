using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.IRepositories;
using VegFoods.Core.UnitOfWork;
using VegFoods.Data.Repositories;

namespace VegFoods.Data.UnitOfWork
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private CategoryRepository _categoryRepository;
        private RecipeRepository _recipeRepository;
        private IngredientRepository _ıngredientRepository;

        

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public IRecipeRepository Recipes => _recipeRepository = _recipeRepository ?? new RecipeRepository(_context);

        public IingredientRepository Ingredients => _ıngredientRepository = _ıngredientRepository ?? new IngredientRepository(_context);

       // public ICategoryRepository categories => _CategoryRepository = _CategoryRepository ?? new CategoryRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
