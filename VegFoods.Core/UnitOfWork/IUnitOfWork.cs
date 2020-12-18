using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.IRepositories;

namespace VegFoods.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IRecipeRepository Recipes { get; }

        IingredientRepository Ingredients { get; }

        Task CommitAsync();

        void Commit();

    }
}
