using System;
using System.Collections.Generic;

namespace Chef_Helper_API.Models
{
    public partial class Recipes
    {
        public string RecipeName { get; set; } = null!;

        public string? IngredientsNeeded { get; set; }

        public string? DishWeight { get; set; }

        public string? CalorieValue { get; set; }
    }

}


