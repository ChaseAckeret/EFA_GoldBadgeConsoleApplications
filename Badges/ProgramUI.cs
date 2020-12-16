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
            Menu();
        }

        private void Menu()
        {
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
            }
            Console.WriteLine("Please hit a key to continue.");
            Console.ReadKey();
            Console.Clear();
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
        }

        private void EditBadgeMenu()
        {
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
            Console.WriteLine("What is the badge ID that needs updated?");
            int id = Int16.Parse(Console.ReadLine());

            var badge = _badgesRepo.GetBadgeById(id);

            string masterList = "";
            foreach (var door in badge.Doors) 
            {
                masterList += door + ",";   //Fix comma?
            }

            Console.WriteLine("Badge {0} has access to doors {1}\n\n", id, masterList);
            Console.WriteLine("Which door would you like to remove?");
            string oldDoor = Console.ReadLine();

            bool wasDeleted = _badgesRepo.DeleteAccessList(id, oldDoor);
            if (wasDeleted)
            {
                Console.WriteLine("Door was removed");
            }
            else
            {
                Console.WriteLine("Door was not removed");
            }
        }

        private void AddDoor()
        {

        }

        private void ViewBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgeDictionary = _badgesRepo.GetAccessList();

            Console.WriteLine($"{"Badge ID",-10} {"Door Access",-10}");
            foreach (KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                string masterList = "";
                foreach (var door in badge.Value)
                {
                    masterList += door + ",";   //Fix comma?
                }
                Console.WriteLine("{0} {1}", badge.Key, masterList);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

