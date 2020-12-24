using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VegFoods.Core.Models;
using VegFoods.Data.Config;

namespace VegFoods.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
        }



    }
}
