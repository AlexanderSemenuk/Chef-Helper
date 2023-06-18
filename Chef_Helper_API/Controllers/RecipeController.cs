using Microsoft.AspNetCore.Mvc;

namespace Chef_Helper_API.Controllers
{
    public class RecipeController : ControllerBase
    {
        public readonly ChefdbContext _dbContext;
        public RecipeController(ChefdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/Recipe
        [HttpGet]
        public IActionResult Get()
        {
            var recipes = _dbContext.Recipes.ToList();
            return Ok(recipes);
        }

        // GET: api/Recipe/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var recipe = _dbContext.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        // POST: api/Recipe
        [HttpPost]
        public IActionResult Post(Recipes recipe)
        {
            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT: api/Recipe/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Recipes updatedRecipe)
        {
            var recipeToUpdate = _dbContext.Recipes.Find(id);
            if (recipeToUpdate == null)
            {
                return NotFound();
            }

            recipeToUpdate.RecipeName = updatedRecipe.RecipeName;
            recipeToUpdate.IngredientsNeeded = updatedRecipe.IngredientsNeeded;
            recipeToUpdate.DishWeight = updatedRecipe.DishWeight;
            recipeToUpdate.CalorieValue = updatedRecipe.CalorieValue;

            _dbContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/Recipe/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var recipeToDelete = _dbContext.Recipes.Find(id);
            if (recipeToDelete == null)
            {
                return NotFound();
            }

            _dbContext.Recipes.Remove(recipeToDelete);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
