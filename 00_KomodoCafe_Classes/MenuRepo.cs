using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_KomodoCafe_Classes
{
    public class MenuRepo
    {
        protected readonly List<Menu> _listOfMenuItems = new List<Menu>();
        public bool AddMenuItem(Menu item)
        {
            int initialCountOfItems = _listOfMenuItems.Count();
            _listOfMenuItems.Add(item);
            if (_listOfMenuItems.Count > initialCountOfItems)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Menu> DisplayMenuItems()
        {
            return _listOfMenuItems;
        }
        public Menu SearchByMenuItemNumber(int id)
        {
            foreach (Menu item in _listOfMenuItems)
            {
                if (item.MealNumber == id)
                {
                    return item;
                }
            }
            return null;
        }
        public bool DeleteMenuItem(int itemNumber)
        {
            Menu item = SearchByMenuItemNumber(itemNumber);
            if (itemNumber == null)
            {
                return false;
            }
            int initialCountOfItems = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(item);
            if (initialCountOfItems > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
