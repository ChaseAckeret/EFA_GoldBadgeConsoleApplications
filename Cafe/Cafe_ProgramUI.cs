using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            SeedMenuList();
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1: Add new item\n" +
                    "2: View menu\n" +
                    "3: View item by ID\n" +
                    "4: Update menu item\n" +
                    "5: Delete menu item\n" +
                    "6: Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewItem();
                        break;
                    case "2":
                        ViewMenu();
                        break;
                    case "3":
                        ViewItemByID();
                        break;
                    case "4":
                        UpdateMenuItem();
                        break;
                    case "5":
                        DeleteMenuItem();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddNewItem()
        {
            Console.Clear();
            MenuClass item = new MenuClass();

            Console.WriteLine("Enter ID number.");
            item.ID = Int16.Parse(Console.ReadLine());

            Console.WriteLine("Enter item's name.");
            item.Name = Console.ReadLine();

            Console.WriteLine("Enter the description.");
            item.Description = Console.ReadLine();

            Console.WriteLine("What ingredients does this item have?");
            item.Ingredients = Console.ReadLine();

            Console.WriteLine("What is the price of this item?");
            item.Price = Decimal.Parse(Console.ReadLine());

            _menuRepo.AddToMenu(item);
        }
        private void ViewMenu()
        {
            Console.Clear();
            List<MenuClass> listOfMenu = _menuRepo.GetMenuList();

            foreach (MenuClass item in listOfMenu)
            {
                Console.WriteLine($"{item.ID}: {item.Name} -- {item.Price}");
            }
        }
        private void ViewItemByID()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID of item you would like to see.");
            int id = Int16.Parse(Console.ReadLine());

            MenuClass item = _menuRepo.GetItemByID(id);

            if (item != null)
            {
                Console.WriteLine($"ID: {item.ID}\n" +
                    $"Name: {item.Name}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {item.Ingredients}\n" +
                    $"Price: {item.Price}");
            }
            else
            {
                Console.WriteLine("No item by that ID");
            }
        }
        private void UpdateMenuItem()
        {
            ViewMenu();

            Console.WriteLine("Enter the ID of the item you would like to update");
            int oldId = Int16.Parse(Console.ReadLine());

            Console.Clear();
            MenuClass newItem = new MenuClass();

            newItem.ID = oldId;

            Console.WriteLine("Enter the name of the item.");
            newItem.Name = Console.ReadLine();

            Console.WriteLine("Enter the description of the item.");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("Enter the ingredients for the item.");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("What is the price for this item?");
            newItem.Price = decimal.Parse(Console.ReadLine());

            bool wasUpdated = _menuRepo.UpdateMenuItem(oldId, newItem);

            if (wasUpdated)
            {
                Console.WriteLine("Item was succesfully updated.");
            }
            else
            {
                Console.WriteLine("Item could not be updated.");
            }
        }
        private void DeleteMenuItem()
        {
            ViewMenu();

            Console.WriteLine("\nEnter the ID of the item you would like to remove.");
            int id = Int16.Parse(Console.ReadLine());

            bool wasDeleted = _menuRepo.RemoveMenuItem(id);

            if (wasDeleted)
            {
                Console.WriteLine("The item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The item could not be deleted.");
            }

        }
        private void SeedMenuList()
        {
            MenuClass cheeseburger = new MenuClass(1, "Big Cheesy", "Two 80/20 100% USDA Beef between two perfectly toasted buns.\n", "Hamburger, Cheese, Lettuce, Tomato, Mayo, Onion.", 4.99m);
            MenuClass hotDog = new MenuClass(2, "Hot Dog", "Hot dog between a toasted bun.\n", "Hot Dog, Mustard, Ketchup, Bun.", 1.50m);
            MenuClass steak = new MenuClass(3, "Ribeye", "100% USDA Ribeye Steak.\n", "Steak, fried onions, herb butter", 14.99m);

            _menuRepo.AddToMenu(cheeseburger);
            _menuRepo.AddToMenu(hotDog);
            _menuRepo.AddToMenu(steak);
        }
    }
}
