using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MenuRepo
    {
        private List<MenuClass> _menu = new List<MenuClass>();

        //Create
        public void AddToMenu(MenuClass item)
        {
            _menu.Add(item);
        }
        //Read
        public List<MenuClass> GetMenuList()
        {
            return _menu;
        }
        //Update
        public bool UpdateMenuItem(int item, MenuClass newItem)
        {
            //Find the item
            MenuClass oldItem = GetItemByID(item);

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
            MenuClass item = GetItemByID(id);

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
        public MenuClass GetItemByID(int id)
        {
            foreach (MenuClass item in _menu)
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
