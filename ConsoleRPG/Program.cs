using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;



namespace ConsoleRPG
{
    class Program
    {
        public static string gameState = "menu";
        public static string gameType;
        public static bool isDead = false;
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
                    StreamReader sr = new StreamReader(@"C:\Users\alcor\source\repos\ConsoleRPG\ConsoleRPG\bin\Debug\savefile.json");
                    string saveFile = sr.ReadToEnd();
                    playerHero = JsonConvert.DeserializeObject<Hero>(saveFile);
                    playerHero.PrintHeroInfo();
                    startGame = true;
                    DisplayCurrentState(playerHero);
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
            string monsterSelection = ChooseMonster();
            
            while (monsterSelection == "Invalid")
            {
                monsterSelection = ChooseMonster();
            }
            if (monsterSelection == "slug")
            {
                Slug slug = new Slug();
                Battle battle = new Battle(PlayerHero, slug);
                battle.BeginBattle();
            }
            else if (monsterSelection == "wolf")
            {
                Wolf wolf = new Wolf();
                Battle battle = new Battle(PlayerHero, wolf);
                battle.BeginBattle();
            }
            gameState = "menu";
            DisplayCurrentState(PlayerHero);
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
                    Console.WriteLine("Do you want to battle monsters (b), heal(h), save (s), or quit (q)?");
                    string menuSelection = Console.ReadLine();
                    if (menuSelection == "b")
                    {
                        gameState = "battle";
                        Battle(playerHero);
                    }
                    else if (menuSelection == "h")
                    {
                        playerHero.health = playerHero.maxHealth;
                        DisplayCurrentState(playerHero);
                    }
                    else if (menuSelection == "q")
                    {
                        System.Environment.Exit(1);
                    }
                    else if (menuSelection == "s")
                    {
                        string saveFile = JsonConvert.SerializeObject(playerHero);
                        using (StreamWriter sw = new StreamWriter(@"C:\Users\alcor\source\repos\ConsoleRPG\ConsoleRPG\bin\Debug\savefile.json"))
                        {
                            sw.Write(saveFile);
                        }
                        Console.WriteLine("Save Complete");
                        Console.ReadLine();
                    }
            }
        }
        
    }
}
