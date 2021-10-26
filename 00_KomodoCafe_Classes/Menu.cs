using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_KomodoCafe_Classes
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemIngredients { get; set; }
        public double ItemPrice { get; set; }

        public Menu() { }
        public Menu (int mealNumber, string mealName, string itemDescription, string itemIngredients, double itemPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            ItemDescription = itemDescription;
            ItemIngredients = itemDescription;
            ItemPrice = itemPrice;
        }
    }
}
