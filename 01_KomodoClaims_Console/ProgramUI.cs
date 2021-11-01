using _01_KomodoClaims_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoClaims_Console
{
    public class ProgramUI
    {
        ClaimsRepo _claimsRepo = new ClaimsRepo();
        Queue<Claim> queueOfClaims;
        public void Run()
        {
            Claim firstClaim = new Claim(1, "Car", "Car accident on 465.", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            Claim secondClaim = new Claim(2, "House", "House fire in kitchen.", 4000.00, new DateTime(2018, 04, 26), new DateTime(2018, 04, 28), true);
            Claim thirdClaim = new Claim(3, "Theft", "Stolen pancakes.", 4.00, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);
            queueOfClaims = _claimsRepo.GetAllClaims();
            queueOfClaims.Enqueue(firstClaim);
            queueOfClaims.Enqueue(secondClaim);
            queueOfClaims.Enqueue(thirdClaim);
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Choose a menu item:" +
                    "\n1. See all claims" +
                    "\n2. Take care of next claim" +
                    "\n3. Enter a new claim" +
                    "\n0. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        SeeClaims();
                        break;
                    case 2:
                        NextClaim();
                        break;
                    case 3:
                        NewClaim();
                        break;
                    case 0:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Entry.");
                        break;
                }
            }
        }
        private void SeeClaims()
        {
            Console.Clear();
            Console.WriteLine("ClaimID" + "\tType" + "\tDescription" + "\t\tAmmount" +
                    "\t\tDateOfAccident" + "\t\t\tDateOfClaim" + "\t\t\tIsValid");
            foreach (Claim content in _claimsRepo.GetAllClaims())
            {
                Console.WriteLine($"{content.ClaimID} \t{content.ClaimType} \t{content.Description} \t{content.ClaimAmmount} " +
                    $"\t\t{content.DateOfAccident} \t\t{content.DateOfClaim} \t{content.IsValid}");
                Console.WriteLine();
            }
        }
        private void NextClaim()
        {
            Console.Clear();
            Console.WriteLine($"Number of items currently in queue: {queueOfClaims.Count}");
            Console.WriteLine();
            Console.WriteLine("ClaimID" + "\tType" + "\tDescription" + "\t\tAmmount" +
            "\t\tDateOfAccident" + "\t\t\tDateOfClaim" + "\t\t\tIsValid");
            Console.WriteLine($"{queueOfClaims.Peek()}");
            Console.WriteLine();
            Console.WriteLine("Would you like to deal with this claim? (y/n)");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                queueOfClaims.Dequeue();
            }
            Console.WriteLine();
        }
        private void NewClaim()
        {
            Console.Clear();
            Console.WriteLine("Enter the claim id: ");
            var claimid = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the claim type: ");
            var claimtype = Console.ReadLine();
            Console.WriteLine("\nEnter a claim description: ");
            var description = Console.ReadLine();
            Console.WriteLine("\nAmmount of Damage: ");
            var claimammount = double.Parse(Console.ReadLine());
            Console.WriteLine("\nDate of Accident: YYYY, MM, DD");
            var dateofaccident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("\nDate of Claim: YYYY, MM, DD");
            var dateofclaim = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("\nIs the claim valid and within 30 days of the accident? (y/n) ");
            string response = Console.ReadLine().ToLower();
            bool isvalid = false;
            if (response == "y")
            {
                isvalid = true;
            }
            else
            {
                isvalid = false;
            }
            Claim claim = new Claim(claimid, claimtype, description, claimammount, dateofaccident, dateofclaim, isvalid);
            _claimsRepo.AddClaim(claim);
        }
    }
}
