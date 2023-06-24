using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chef_Helper_Wpf
{
    public class Food
    {
        public string recipeName { get; set; } = null!;

        public string? ingredientsNeeded { get; set; }

        public string? dishWeight { get; set; }

        public string? calorieValue { get; set; }
    }
}
