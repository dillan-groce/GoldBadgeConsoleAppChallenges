using _00_KomodoCafe_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_KomodoCafe_Console
{
    public class ProgramUI
    {
        MenuRepo _menuRepo = new MenuRepo();
        List<Menu> menuItem;
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            menuItem = _menuRepo.DisplayMenuItems();
            bool stillRunning = true;
            while (stillRunning)
            {
                Console.WriteLine("Hello, Komodo Cafe! Please select an option below:\n" +
                    "\n1. Add a new menu item" +
                    "\n2. View all menu items" +
                    "\n3. Delete a menu item" +
                    "/n4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        ViewMenuItems();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        stillRunning = false;
                        break;
                    default:
                        Console.WriteLine("User input not recogniced. Please select a valid option by entering a number from 1 thorugh 4.");
                        break;
                }
            }
        }
        private void AddMenuItem()
        {
            Console.Clear();
            Menu newItem = new Menu();
            Console.WriteLine("Please assign this menu item a number on the menu:");
            newItem.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("\nPlease name this item:");
            newItem.MealName = Console.ReadLine();
            Console.WriteLine("\nPlease describe this item:");
            newItem.ItemDescription = Console.ReadLine();
            Console.WriteLine("\nPlease list each ingredient, separated by commas:");
            newItem.ItemIngredients = Console.ReadLine();
            Console.WriteLine("\nWhat are you going to charge for this item?");
            newItem.ItemPrice = double.Parse(Console.ReadLine());
            _menuRepo.AddMenuItem(newItem);
        }
        private void ViewMenuItems()
        {
            Console.Clear();
            foreach (Menu item in _menuRepo.DisplayMenuItems())
            {
                Console.WriteLine($"#{item.MealNumber}. {item.MealName}\n" +
                    $"Description: {item.ItemDescription}\n" +
                    $"Ingredients: {item.ItemIngredients}\n" +
                    $"Price: {item.ItemPrice}\n" +
                    $"\n");
            }
        }
        private void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter the item number for the item you would like to remove:");
            foreach (Menu item in _menuRepo.DisplayMenuItems())
            {
                Console.WriteLine();
            }
            int removeMenuItem = int.Parse(Console.ReadLine());

            foreach (Menu meal in _menuRepo.DisplayMenuItems())
            {
                if (removeMenuItem == meal.MealNumber)
                {
                    _menuRepo.DeleteMenuItem(meal);
                    break;
                }
            }
        }
    }
}
