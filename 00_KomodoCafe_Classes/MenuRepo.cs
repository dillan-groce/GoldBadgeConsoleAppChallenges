using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_KomodoCafe_Classes
{
    public class MenuRepo
    {
        public List<Menu> _listOfMenuItems = new List<Menu>();
        public bool AddMenuItem(Menu item)
        {
            int ogCount = _listOfMenuItems.Count();
            _listOfMenuItems.Add(item);
            int newCount = _listOfMenuItems.Count();
            bool wasAdded = (newCount > ogCount) ? true : false;
            return wasAdded;
        }
        public List<Menu> DisplayMenuItems()
        {
            return _listOfMenuItems;
        }
        public bool DeleteMenuItem(Menu item)
        {
            int ogCount = _listOfMenuItems.Count();
            _listOfMenuItems.Remove(item);
            int newCount = _listOfMenuItems.Count();
            bool wasDeleted = (newCount < ogCount) ? true : false;
            return wasDeleted;
        }
    }
}
