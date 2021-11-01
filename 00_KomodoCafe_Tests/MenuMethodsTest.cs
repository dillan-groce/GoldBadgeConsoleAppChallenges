using _00_KomodoCafe_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _00_KomodoCafe_Tests
{
    [TestClass]
    public class MenuMethodsTest
    {
        MenuRepo repo = new MenuRepo();

        [TestMethod]
        public void Test_AddMenuItems()
        {
            Menu item = new Menu();
            MenuRepo repo = new MenuRepo();
            bool wasAdded = repo.AddMenuItem(item);
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void Test_DeleteMenuItem()
        {
            Menu item = new Menu();
            MenuRepo repo = new MenuRepo();
            bool wasDeleted = repo.DeleteMenuItem(item);
            Assert.IsFalse(wasDeleted);
        }
        [TestMethod]
        public void Test_ViewMenu()
        {
            Menu item = new Menu()
            {
                MealNumber = 1,
                MealName = "PeanutButtaJellehTime",
                ItemDescription = "a generous slap of creamy peanut butter and grape jelly evenly spread across on 2 slices of honeywheat bread smooshed together",
                ItemIngredients = "2 slices of honeywheat bread, peanut butter, jelly",
                ItemPrice = 4.99
            };
            MenuRepo repo = new MenuRepo();
            repo.AddMenuItem(item);
            List<Menu> menuItems = repo.DisplayMenuItems();
            bool menuHasItems = menuItems.Contains(item);
            Assert.IsTrue(menuHasItems);
        }
    }
}
