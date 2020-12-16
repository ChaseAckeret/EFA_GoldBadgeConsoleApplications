using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    class ProgramUI
    {
        private BadgesRepo _badgesRepo = new BadgesRepo();

        public void Run()
        {
            SeedList();
            Menu();
        }

        private void Menu()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?\n\n" +
                    "1: Add new badge.\n" +
                    "2: Edit a badge.\n" +
                    "3: List all badges.\n" +
                    "4: Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadgeMenu();
                        break;
                    case "3":
                        Console.Clear();
                        ViewBadges();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                //Console.WriteLine("Please hit a key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddBadge()
        {
            Badge badge = new Badge();

            Console.Clear();
            Console.WriteLine("Please enter badge ID.");
            int id = Int16.Parse(Console.ReadLine());
            badge.BadgeID = id;

            bool keepAddingDoors = true;
            while (keepAddingDoors)
            {
                Console.WriteLine("What door does this badge need access to?");
                string door = Console.ReadLine();
                badge.Doors.Add(door);

                Console.WriteLine("Would you like to add another door? (y/n)");
                string input = Console.ReadLine().ToLower();

                if (input == "n")
                {
                    keepAddingDoors = false;
                    Console.Clear();
                }
            }
            _badgesRepo.AddToAccessList(badge);
            Menu();
        }

        private void EditBadgeMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?\n\n" +
                "1: Remove a door\n" +
                "2: Add a door\n" +
                "3: Main Menu");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RemoveDoor();
                    break;
                case "2":
                    AddDoor();
                    break;
                case "3":
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid number");
                    break;
            }
            Console.WriteLine("Please hit a key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        private void RemoveDoor()
        {
            Console.Clear();
            ViewBadges();
            Console.WriteLine("What is the badge ID that needs updated?");
            int id = Int16.Parse(Console.ReadLine());

            var badge = _badgesRepo.GetBadgeById(id);

            string masterList = "";
            foreach (var door in badge.Doors)
            {
                masterList += $"{door,-5}";   //Fix comma?
            }

            Console.WriteLine("Badge {0} has access to doors {1}\n\n", id, masterList);
            Console.WriteLine("Which door would you like to remove?\n\n");
            string oldDoor = Console.ReadLine();

            bool wasDeleted = _badgesRepo.DeleteDoor(id, oldDoor);
            if (wasDeleted)
            {
                Console.WriteLine("Door was removed");
                

            }
            else
            {
                Console.WriteLine("Door was not removed");
                

            }
            Console.ReadKey();
            Menu();
           
        }

        private void AddDoor()
        {
            Console.Clear();
            ViewBadges();
            Console.WriteLine("What is the badge ID that needs updated?");
            int id = Int16.Parse(Console.ReadLine());

            var badge = _badgesRepo.GetBadgeById(id);

            string masterList = "";
            foreach (var door in badge.Doors)
            {
                masterList += $"{door,-5}";   //Fix comma?
            }

            Console.WriteLine("Badge {0} has access to doors {1}\n\n", id, masterList);
            Console.WriteLine("What door would you like to add?\n\n");
            string newDoor = Console.ReadLine();

            bool wasAdded = _badgesRepo.AddDoor(id, newDoor);
            if (wasAdded)
            {
                Console.WriteLine("Door was added");
                Console.ReadKey();
                Menu();
            }
            else
            {
                Console.WriteLine("Door was not added");
                Console.ReadKey();
                Menu();
            }
        }

        private void ViewBadges()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgesRepo.GetAccessList();

            Console.WriteLine($"{"Badge ID",-10} {"Door Access",-10}\n");
            foreach (KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                string masterList = "";
                foreach (var door in badge.Value)
                {
                    masterList += $"{ door,-5}";   //Fix comma?
                }
                Console.WriteLine($"{badge.Key,-10} {masterList}\n");
            }
        }

        private void SeedList()
        {
            List<string> doors1 = new List<string>();
            List<string> doors2 = new List<string>();
            List<string> doors3 = new List<string>();
            List<string> doors4 = new List<string>();

            doors1.Add("A1");
            doors1.Add("A2");
            doors1.Add("A3");

            doors2.Add("A4");
            doors2.Add("A5");
            doors2.Add("A6");

            doors3.Add("A1");
            doors3.Add("A3");
            doors3.Add("A5");

            doors4.Add("A2");
            doors4.Add("A4");
            doors4.Add("A6");

            Badge badge1 = new Badge(1001, doors1);
            Badge badge2 = new Badge(2001, doors2);
            Badge badge3 = new Badge(3001, doors3);
            Badge badge4 = new Badge(4001, doors4);

            _badgesRepo.AddToAccessList(badge1);
            _badgesRepo.AddToAccessList(badge2);
            _badgesRepo.AddToAccessList(badge3);
            _badgesRepo.AddToAccessList(badge4);
        }
    }
}

