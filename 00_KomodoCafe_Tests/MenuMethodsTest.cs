using _00_KomodoCafe_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _00_KomodoCafe_Tests
{
    [TestClass]
    public class MenuMethodsTest
    {
        [TestClass]
        public class RepoTests
        {
            MenuRepo _repo = new MenuRepo();
            Menu _item = new Menu()
            {
                MealNumber = 1,
                MealName = "PeanutButtaJellehTime",
                ItemDescription = "a generous slap of creamy peanut butter and grape jelly evenly spread across on 2 slices of honeywheat bread smooshed together",
                ItemIngredients = "2 slices of honeywheat bread, peanut butter, jelly",
                ItemPrice = 4.99
            };
        }
        [TestMethod]
        public void TestAddMenuItems_ShouldReturnTrue()
        {
            MenuRepo _repo = new MenuRepo();
            Menu item = new Menu();
            List<Menu> localList = _repo.DisplayMenuItems();
            int beforeCount = localList.Count;
            _repo.AddMenuItem(item);
            List <Menu> newLocalList = _repo.DisplayMenuItems();
            int newCount = newLocalList.Count;
            bool result = newCount == (beforeCount + 1) ? true : false;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_DeleteMenuItems(int itemNumber)
        {
            MenuRepo _repo = new MenuRepo();
            Menu item = new Menu();
            List<Menu> localList = _repo.DisplayMenuItems();
            int beforeCount = localList.Count;
            _repo.DeleteMenuItem(itemNumber);
            List<Menu> newLocalList = _repo.DisplayMenuItems();
            int newCount = newLocalList.Count;
            bool result = newCount == (beforeCount - 1) ? true : false;
            Assert.IsTrue(result);
        }
    }
}
