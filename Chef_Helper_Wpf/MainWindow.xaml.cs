using Chef_Helper_API;
using Chef_Helper_API.Models;
using Chef_Helper_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chef_Helper_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Food> recept { get; set; }
        private RecipesService recipesService;
        public MainWindow()
        {
            recept = getrecpt();
            var dbContext = new ChefdbContext();
            recipesService = new RecipesService(dbContext);
            InitializeComponent();

        }

        private List<Food>? getrecpt()
        {
            var list = new List<Food>();
            if (recipesService != null)
            {
                foreach (var recept in recipesService.GetRecipes())
                {
                    list.Add(new Food()
                    {
                        recipeName = recept.RecipeName,
                        ingredientsNeeded = recept.IngredientsNeeded,
                        dishWeight = recept.DishWeight,
                        calorieValue = recept.CalorieValue,
                    });

                }
            }
            return list;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var recept = this.recept;
            datagrid.DataContext = recept;
        }
    }
}
