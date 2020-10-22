using System;
using System.Collections.Generic;

namespace HelloWorld
{
    class Companies
    {
        public List<string> company = new List<string>();

        public void showCompaines(){
            Console.WriteLine("Here are the current companies:\n");
            foreach (var company in this.company){
                Console.WriteLine(company);
            }
        }
        
        public void addCompany(string company){
            this.company.Add(company);
        }

        public string getStarted(){
            Console.WriteLine("\nWhat company would you like to add?");
            string companyName = Console.ReadLine();
            return companyName;
        }

        public void displayFirst(){
            Console.WriteLine("What would you like to do here?");
            Console.WriteLine("HINT -- Enter the number associated\n");
            Console.WriteLine("1 Add a new company");
            Console.WriteLine("2 View the companies in the list");
            Console.WriteLine("3 Exit the program");
        }

        public void displaySecond(){
            Console.WriteLine("\n     1               2             3");
            Console.WriteLine("ADD COMPANY  /  VIEW COMPANIES  /  EXIT\n");
        }

        public void clearScreen(){
            Console.WriteLine("\nPress any key to continue");
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void outputCompanies(){
            System.IO.File.WriteAllLines("SavedListsOfCompanies.txt", this.company);
        }

        public void inputCompanies(){
            using (var input = new System.IO.StreamReader("SavedListsOfCompanies.txt")){
                while (input.Peek() >= 0)
                    this.company.Add(input.ReadLine());
            }
        }

        public void pseudoMain(){
            inputCompanies();
            var firstRun = true;
            var moreThanFirstRun = false;
            do{
                if (firstRun) { displayFirst(); }
                if (moreThanFirstRun) { displaySecond(); }

                string user = Console.ReadLine();
                var userChoiceInt = int.Parse(user);
            
                switch (userChoiceInt){
                    case 1:
                        Console.Clear();
                        var newCompany = getStarted();
                        addCompany(newCompany);
                        //Console.WriteLine("\n" + newCompany + " is being added!");
                        //System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        showCompaines();
                        clearScreen();
                        break;
                    case 3:
                        Console.WriteLine("\nK BYE!");
                        outputCompanies();
                        Environment.Exit(0);
                        break;
                }
                firstRun = false;
                moreThanFirstRun = true;
                
            } while (true);
        }
    }
}
