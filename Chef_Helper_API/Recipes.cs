using System;
using System.Collections.Generic;

namespace Chef_Helper_API;

public partial class Recipes
{
    public string RecipeName { get; set; }

    public string? IngredientsNeeded { get; set; }

    public string? DishWeight { get; set; }

    public string? CalorieValue { get; set; }
}
