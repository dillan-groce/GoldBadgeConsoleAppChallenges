using _02_KomodoBadges_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoBadges_Console
{
    public class ProgramUI
    {
        private BadgeRepo _repo = new BadgeRepo();
        public void Run()
        {
            SeedBadges();
            Menu();
        }
        public void SeedBadges()
        {
            Badge badge1 = new Badge(12345, new List<string> { "A7" });
            Badge badge2 = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badge badge3 = new Badge(32345, new List<string> { "A4", "A5" });
            _repo.AddBadge(badge1);
            _repo.AddBadge(badge2);
            _repo.AddBadge(badge3);
        }
        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello, Security Admin! What would you like to do?\n" +
                    "\n" +
                    "1. Add a new badge\n" +
                    "2. Edit an existing badge\n" +
                    "3. Delete all doors from an existing badge\n" +
                    "4. View all badges\n" +
                    "5. Exit\n" +
                    "\n" +
                    "Please enter a selection:\n");
                string menuSelection = Console.ReadLine();
                switch (menuSelection)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        DeleteAllDoorsOnBadge();
                        break;
                    case "4":
                        ViewAll();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void AddBadge()
        {
            Console.Clear();
            Console.WriteLine("Add a badge\n" +
                "\nWhat is the number on the badge:\n");
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            if (_repo.GetABadgeByID(badgeNum) != null)
            {
                Console.WriteLine("Badge {0} already exists.\n", badgeNum,
                    "\nPress aany key to return to main menu.");
            }
            else
            {
                Badge newBadge = new Badge(badgeNum);
                bool stillAdding = true;
                List<string> doors = new List<string>();
                while (stillAdding)
                {
                    Console.WriteLine("Enter a door badge {0} will need access to:", badgeNum);
                    doors.Add(Console.ReadLine());
                    Console.WriteLine("Any other doors (y/n)?");
                    string moreDoors = Console.ReadLine();
                    if (moreDoors.ToLower() == "n")
                    {
                        stillAdding = false;
                    }
                }
                newBadge.Doors = doors;
                string doorResult = string.Join(",", doors);
                bool wasAdded = _repo.AddBadge(newBadge);
                if (wasAdded == true)
                {
                    Console.WriteLine($"Badge #{newBadge.BadgeID} was added successfully and hass access to:  {doorResult}.");
                }
                else
                {
                    Console.WriteLine("Badge #{0} could not be added at this time... Please try again.", newBadge.BadgeID);
                }
                Console.WriteLine("Press any key to return to the main menu.");
            }
            Console.ReadKey();
        }
        public void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("Update a Badge\n" +
                "\nWhat is the badge number to update?\n");
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            Badge badgeToUpdate = _repo.GetABadgeByID(badgeNum);
            List<string> doorsOnBadge = new List<string>();
            if (badgeToUpdate != null)
            {
                doorsOnBadge = badgeToUpdate.Doors;
                bool stillEditing = true;
                while (stillEditing)
                {
                    Console.Clear();
                    Console.WriteLine("Update a Badge");
                    string doorsResult = string.Join(",", badgeToUpdate.Doors);
                    Console.WriteLine($"\nBadge #{badgeToUpdate.BadgeID} has access to doors: {doorsResult}.\n");
                    Console.WriteLine("What would you like to do?\n" +
                        "       1.Remove a door\n" +
                        "       2. Add a door\n" +
                        "       3. Main menu\n" +
                        "\n");
                    string menuSelect = Console.ReadLine();
                    switch (menuSelect)
                    {
                        case "1":
                            Console.WriteLine("Which door would you like to remove?");
                            string doorToRemove = Console.ReadLine();
                            doorsOnBadge.Remove(doorToRemove);
                            badgeToUpdate.Doors = doorsOnBadge;
                            Console.WriteLine("Door removed.");
                            doorsResult = string.Join(",", badgeToUpdate.Doors);
                            Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to doors: {doorsResult}.\n");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("Which door would you like to add?\n");
                            string doorToAdd = Console.ReadLine();
                            doorsOnBadge.Add(doorToAdd);
                            badgeToUpdate.Doors = doorsOnBadge;
                            Console.WriteLine("Door added\n");
                            doorsResult = string.Join(",", badgeToUpdate.Doors);
                            Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to doors: {doorsResult}.\n");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "3":
                            stillEditing = false;
                            break;
                    }
                }
                bool wasUpdate = _repo.UpdateExistingBadge(badgeNum, badgeToUpdate);
                if (wasUpdate == true)
                {
                    Console.WriteLine("Badge updated successfully!");
                }
                else
                {
                    Console.WriteLine("Uh-oh... Something went wrong.  Please try update again.");
                }
            }
            else
            {
                Console.WriteLine("Badge ID not found.");

            }
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }
        public void DeleteAllDoorsOnBadge()
        {
            Console.Clear();
            Console.WriteLine("Delete All Doors From Badge\n" +
                "\nWhat is the badge number to updsate:");
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            Badge badgeToUpdate = _repo.GetABadgeByID(badgeNum);
            List<string> doorsOnBadge = new List<string>();
            if (badgeToUpdate != null)
            {
                string doorsResult = string.Join(",", badgeToUpdate.Doors);
                Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to doors: {doorsResult}.");
                Console.WriteLine($"Do you want to clear all doors from Badge #{badgeToUpdate.BadgeID}? (y/n)");
                string deleteAll = Console.ReadLine();
                if (deleteAll.ToLower() == "y")
                {
                    badgeToUpdate.Doors.Clear();
                    bool wasUpdate = _repo.UpdateExistingBadge(badgeNum, badgeToUpdate);
                    if (wasUpdate == true)
                    {
                        Console.WriteLine($"All Doors Deleted from Badge #{badgeNum}");
                    }
                    else
                    {
                        Console.WriteLine("Oops! Something went wrong.  Please try update again.");
                    }
                }
                else
                {
                    Console.WriteLine("Canceled.");
                }
            }
            else
            {
                Console.WriteLine("Badge ID not found.");
            }
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }
        public void ViewAll()
        {
            Console.Clear();
            Console.WriteLine("View All Badges\n" +
                "\nBadge#             Door Access:");
            Dictionary<int, List<string>> badges = _repo.GetAllBadges();
            foreach (KeyValuePair<int, List<string>> badge in badges)
            {
                string doorsResult = string.Join(",", badge.Value);
                Console.WriteLine($"{badge.Key}              {doorsResult}");
            }
            Console.WriteLine("\nPress any key to return to main menu.");
            Console.ReadKey();
        }
    }
}
