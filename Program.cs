using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            // Displays initial messages and prompts user to pick a class
            Console.WriteLine("Welcome to ConsoleRPG!");
            Console.WriteLine("Let's begin by getting you a character.");
            Console.WriteLine("Are you a Warrior, Wizard, Ranger, or Cleric?");
            string choice = ChooseClass();

            // Created Empty Objects to have Global Stats of the Character
            Warrior war = new Warrior();
            Wizard wiz = new Wizard();
            Ranger ran = new Ranger();
            Cleric cle = new Cleric();

            Slug slu;
            Wolf wol;

            // Main Flow of Game
            while (choice == "Invalid")
            {
                choice = ChooseClass();
            }
            if (choice == "Warrior")
            {
                war = new Warrior(choice, 20, 2, 0);
                war.PrintHeroInfo();
            }
            else if (choice == "Wizard")
            {
                wiz = new Wizard(choice, 20, 0, 2);
                wiz.PrintHeroInfo();
            }
            else if (choice == "Ranger")
            {
                ran = new Ranger(choice, 20, 2, 0);
                ran.PrintHeroInfo();
            }
            else if (choice == "Cleric")
            {
                cle = new Cleric(choice, 20, 0, 2);
                cle.PrintHeroInfo();
            }
         
            string monsterSelection = ChooseMonster();
            while (monsterSelection  == "Invalid")
            {
                monsterSelection = ChooseMonster();
            }
            if (monsterSelection == "Slug")
            {
                Slug monster = new Slug();
            }
            else if (monsterSelection == "Wolf")
            {
                Wolf monster = new Wolf();
            }
          
            Console.WriteLine("Press enter to begin the battle.");
            Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("Battle will begin here.");
            Console.ReadLine();
        }

        // Takes user input and compares it to available classes. Returns a string
        public static string ChooseClass()
        {
            string classChoice;
            string[] classChoices = { "Warrior", "Wizard", "Ranger", "Cleric" };
            classChoice = Console.ReadLine();
            if (Array.IndexOf(classChoices, classChoice) > -1)
            {
                Console.WriteLine("Ahh, you're a " + classChoice +"!");
                return classChoice;
            }
            else
            {
                Console.WriteLine("Please enter a valid class.");
                return "Invalid";
            }
        }

        public static string ChooseMonster()
        {
            string monsterChoice;
            string[] monsterChoices = {"Slug", "Wolf" };
            Console.WriteLine("What monster do you choose to fight? " + monsterChoices[0] + " or " + monsterChoices[1]);
            monsterChoice = Console.ReadLine();
            if (Array.IndexOf(monsterChoices, monsterChoice) > -1)
            {
                Console.WriteLine("You wish to fight the " + monsterChoice + ". Very Well");
                return monsterChoice;
            }
            else
            {
                Console.WriteLine("Please select a valid monster to fight.");
                return "Invalid";
            }
        }

        public static void Battle()
        {

        }
        
    }
}
