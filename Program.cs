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
        public static string gameType;
        static void Main(string[] args)
        {
            // Created Empty Object to have Global Stats of the Character
            Hero playerHero = new Hero();

            // Displays initial information and sets game up
            Console.WriteLine("ConsoleRPG - A Text RPG Game");
            bool startGame = false;
            while (startGame == false)
            {
                Console.WriteLine("New Game(n) or Load Game(l)?");
                gameType = Console.ReadLine();
                if (gameType == "n")
                {
                    startGame = true;
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
                    DisplayCurrentState(playerHero);
                }
                else if (gameType == "l")
                {
                    Console.WriteLine("Feature coming in later version.");
                }
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

        // Allows user to choose what monster they want to fight
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

        // Primary method for when in a battle with a monster
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
                        if (PlayerHero.health > 0)
                        {
                            PlayerHero.GetLoot(slug.loot);
                        }
                    }
                    if (decision == "r")
                    {
                        break;
                    }
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
                        if (PlayerHero.health > 0)
                        {
                            PlayerHero.GetLoot(wolf.loot);
                        }
                    }
                    if (decision == "r")
                    {
                        break;
                    }
                }
                gameState = "menu";
                DisplayCurrentState(PlayerHero);
            }

           
            Console.ReadLine();
            
        }

        // Displays the current information based on what scenario the player is in. Mostly used for transitioning from scenario to another such as battle to menu or menu to battle.
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
