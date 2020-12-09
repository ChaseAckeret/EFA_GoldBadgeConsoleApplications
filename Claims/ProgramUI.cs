using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    class ProgramUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();

        public void Run()
        {
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1: See all claims\n" +
                    "2: Take care of next claim\n" +
                    "3: Enter new claim\n" +
                    "4: Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewClaims();
                        break;
                    case "2":
                        TakeCareOfClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ViewClaims()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _claimsRepo.ViewClaimList();

            foreach(Claim claim in queueOfClaims)
            {
                Console.WriteLine($"{claim.ClaimID} , {claim.TypeOfClaim}," +
                    $"{claim.Description},{claim.ClaimAmount},{claim.DateOfIncident.ToShortDateString()}," +
                    $"{claim.DateOfClaim.ToShortDateString()},{claim.IsValid}");
            }
        }

        private void TakeCareOfClaim()
        {
            Queue<Claim> queueClaims = _claimsRepo.ViewClaimList();
            Claim currentClaim = queueClaims.Peek();

            Console.WriteLine($"Here are the details for the next claim to be handled:\n" +
              $"{currentClaim.ClaimID}, {currentClaim.TypeOfClaim}, {currentClaim.Description}," +
              $"{currentClaim.ClaimAmount}, {currentClaim.DateOfIncident}, {currentClaim.DateOfClaim}," +
              $"{currentClaim.IsValid}");

            Console.WriteLine("\n\nDo you want to deal with this claim now? (y/n)");
            string input = Console.ReadLine().ToLower();

            if(input == "y")
            {
                queueClaims.Dequeue();
            }
            else
            {
                Menu();
            }
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Claim claim = new Claim();

            Console.WriteLine("\nEnter ID of claim.");
            claim.ClaimID = Int16.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter claim type.\n" +
                "1: Car \n" +
                "2: Home \n" +
                "3: Theft \n");
            claim.TypeOfClaim = (ClaimType)Int16.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter description.");
            claim.Description = Console.ReadLine();

            Console.WriteLine("\nEnter claim amount.");
            claim.ClaimAmount= decimal.Parse(Console.ReadLine());
           
            
            Console.WriteLine("\nEnter date of incident.");
            claim.DateOfIncident = DateTime.Parse(Console.ReadLine());


            Console.WriteLine("\nEnter date of claim.");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            TimeSpan timespan = claim.DateOfClaim - claim.DateOfIncident;
            int days = (int)timespan.TotalDays;

            if (days <= 30)
            {
                claim.IsValid = true;

            }
            else
            {
                claim.IsValid = false;
            }

            _claimsRepo.AddClaim(claim);
        }
    }
}
