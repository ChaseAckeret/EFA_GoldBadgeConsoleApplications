using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class MenuRepo
    {
        private List<Menu> _menu = new List<Menu>();

        //Create
        public void AddToMenu(Menu item)
        {
            _menu.Add(item);
        }
        //Read
        public List<Menu> GetMenuList()
        {
            return _menu;
        }
        //Update
        public bool UpdateMenuItem(int item, Menu newItem)
        {
            //Find the item
            Menu oldItem = GetItemByID(item);

            //Update item
            if (oldItem != null)
            {
                oldItem.ID = newItem.ID;
                oldItem.Name = newItem.Name;
                oldItem.Description = newItem.Description;
                oldItem.Ingredients = newItem.Ingredients;
                oldItem.Price = newItem.Price;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveMenuItem(int id)
        {
            Menu item = GetItemByID(id);

            if (item == null)
            {
                return false;
            }

            int initialCount = _menu.Count;
            _menu.Remove(item);

            if (initialCount > _menu.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper Method
        public Menu GetItemByID(int id)
        {
            foreach (Menu item in _menu)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
