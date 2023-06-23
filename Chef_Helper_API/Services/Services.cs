using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Chef_Helper_API;
using Chef_Helper_API.Models;

namespace Chef_Helper_API.Services
{
    public class RecipesService
    {
        private readonly ChefdbContext _dbContext;

        public RecipesService(ChefdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Recipes> GetRecipes()
        {
            return _dbContext.Recipes.ToList();
        }
    }
}