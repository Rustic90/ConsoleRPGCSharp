using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Program
    {
        public static string gameState = "menu";
        static void Main(string[] args)
        {
            // Displays initial messages and prompts user to pick a class
            Console.WriteLine("Welcome to ConsoleRPG!");
            Console.WriteLine("Let's begin by getting you a character.");
            Console.WriteLine("Are you a Warrior, Wizard, Ranger, or Cleric?");
            string choice = ChooseClass();

            // Created Empty Object to have Global Stats of the Character
            Hero playerHero = new Hero();

            // Main Flow of Game
            while (choice == "Invalid")
            {
                choice = ChooseClass();
            }
            if (choice == "Warrior")
            {
                playerHero = new Hero("Warrior");
            }
            else if (choice == "Wizard")
            {
                playerHero = new Hero("Wizard");
            }
            else if (choice == "Ranger")
            {
                playerHero = new Hero("Ranger");
            }
            else if (choice == "Cleric")
            {
                playerHero = new Hero("Cleric");
            }
            Console.WriteLine("Do you want to battle monsters (b) or quit (q)?");
            string menuSelection = Console.ReadLine();
            if (menuSelection == "b")
            {
                gameState = "battle";
                Battle(playerHero);
           
            }
            else if (menuSelection == "q")
            {
                return;
            }
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
            string[] monsterChoices = {"slug", "wolf" };
            Console.WriteLine("What monster do you choose to fight? " + monsterChoices[0] + " or " + monsterChoices[1]);
            monsterChoice = Console.ReadLine();
            if (Array.IndexOf(monsterChoices, monsterChoice) > -1)
            {
                return monsterChoice;
            }
            else
            {
                Console.WriteLine("Please select a valid monster to fight.");
                return "Invalid";
            }
        }

        public static void Battle(Hero PlayerHero)
        {
            // Create Monster Objects
            Slug slug = new Slug();
            Wolf wolf = new Wolf();
            string monsterSelection = ChooseMonster();
            
            while (monsterSelection == "Invalid")
            {
                monsterSelection = ChooseMonster();
            }
            if (monsterSelection == "slug")
            {
                while (PlayerHero.health > 0 && slug.health > 0 && gameState == "battle")
                {
                    Console.Clear();
                    PlayerHero.PrintHeroInfo();
                    slug.PrintMonsterInfo();
                    Console.WriteLine("Attack (a) or Run (r)");
                    string decision = Console.ReadLine();
                    if (decision == "a")
                    {
                        PlayerHero.TakeDamage(slug.strength);
                        slug.health -= PlayerHero.GetStrength();
                        PlayerHero.PrintHeroInfo();
                        slug.PrintMonsterInfo();
                    }
                    if (decision == "r")
                    {
                        break;
                    }
                }
                if (PlayerHero.health > 0)
                {
                    PlayerHero.GetLoot(slug.loot);
                }
                gameState = "menu";
                DisplayCurrentState(PlayerHero);
            }
            else if (monsterSelection == "wolf")
            {
                while (PlayerHero.health > 0 && wolf.health > 0 && gameState == "battle")
                {
                    Console.Clear();
                    PlayerHero.PrintHeroInfo();
                    wolf.PrintMonsterInfo();
                    Console.WriteLine("Attack (a) or Run (r)");
                    string decision = Console.ReadLine();
                    if (decision == "a")
                    {
                        PlayerHero.TakeDamage(wolf.strength);
                        wolf.health -= PlayerHero.GetStrength();
                        PlayerHero.PrintHeroInfo();
                        wolf.PrintMonsterInfo();
                    }
                    if (decision == "r")
                    {
                        break;
                    }
                }
                if (PlayerHero.health > 0)
                {
                    PlayerHero.GetLoot(wolf.loot);
                }
                gameState = "menu";
                DisplayCurrentState(PlayerHero);
            }

           
            Console.ReadLine();
            
        }

        public static void DisplayCurrentState(Hero playerHero)
        {
            Console.Clear();
            if (gameState == "menu")
            {
                Console.Clear();
                playerHero.PrintHeroInfo();
                Console.WriteLine("Do you want to battle monsters (b) or quit (q)?");
                string menuSelection = Console.ReadLine();
                if (menuSelection == "b")
                {
                    gameState = "battle";
                    Battle(playerHero);

                }
                else if (menuSelection == "q")
                {
                    System.Environment.Exit(1);
                }

            }
        }
        
    }
}
