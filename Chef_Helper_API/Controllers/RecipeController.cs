using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Chef_Helper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        public readonly ChefdbContext _dbContext;
        public RecipeController(ChefdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/Recipe
        [HttpGet("/Recipes")]
        public IActionResult Get()
        {
            var recipes = _dbContext.Recipes.ToList();
            return Ok(recipes);
        }

        // GET: api/Recipe/5
        [HttpGet("/RecipeByName")]
        public IActionResult Get(string name)
        {
            var recipe = _dbContext.Recipes.Find(name);
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
            // Разделяем список ингредиентов, указанных в поле IngredientsNeeded, по запятой
            var ingredientsList = recipe.IngredientsNeeded?.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            if (ingredientsList != null && ingredientsList.Length > 0)
            {
                // Приводим все названия ингредиентов к нижнему регистру
                var lowercaseIngredients = ingredientsList.Select(ingredient => ingredient.Split(' ')[1].Trim().ToLower());

                // Получаем все названия ингредиентов в таблице Warehouse в нижнем регистре
                var warehouseIngredients = _dbContext.Warehouse.Select(w => w.IngredientName.ToLower()).ToList();

                // Проверяем наличие каждого ингредиента в списке Warehouse
                foreach (var ingredient in lowercaseIngredients)
                {
                    if (!warehouseIngredients.Contains(ingredient))
                    {
                        // Ингредиент не найден в таблице Warehouse
                        return BadRequest($"Ингредиент '{ingredient}' отсутствует в таблице Warehouse.");
                    }
                }
            }
            else
            {
                // Список ингредиентов пуст или не указан
                return BadRequest("Список ингредиентов пуст или не указан.");
            }



            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT: api/Recipe/5
        [HttpPut]
        public IActionResult Put(string name, Recipes updatedRecipe)
        {
            var recipeToUpdate = _dbContext.Recipes.Find(name);
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
        [HttpDelete]
        public IActionResult Delete(string name)
        {
            var recipeToDelete = _dbContext.Recipes.Find(name);
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
