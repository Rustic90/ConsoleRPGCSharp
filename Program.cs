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
            while (choice == "Invalid")
            {
                choice = ChooseClass();
            }
            if (choice == "Warrior")
            {
                Warrior war1 = new Warrior(choice, 20, 4, 0);
                war1.PrintHeroInfo();
            }
            else if (choice == "Wizard")
            {
                Wizard wiz1 = new Wizard(choice, 20, 0, 2);
                wiz1.PrintHeroInfo();
            }
            else if (choice == "Ranger")
            {
                Ranger ran1 = new Ranger(choice, 20, 2, 0);
                ran1.PrintHeroInfo();
            }
            else if (choice == "Cleric")
            {
                Cleric cle1 = new Cleric(choice, 20, 0, 2);
                cle1.PrintHeroInfo();
            }
            Wolf wolf1 = new Wolf();
            wolf1.PrintMonsterInfo();
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
    }
}
