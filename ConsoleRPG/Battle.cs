using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Battle
    {
        public Hero playerHero;
        public BaseMonster monster;
        public bool inBattle = false;

        public Battle(Hero PlayerHero, BaseMonster Monster)
        {
            playerHero = PlayerHero;
            monster = Monster;
            inBattle = true;
        }

        public void BeginBattle()
        {
            while (playerHero.health > 0 && monster.health > 0 && inBattle == true)
            {
                Console.Clear();
                playerHero.PrintHeroInfo();
                monster.PrintMonsterInfo();
                Console.WriteLine("Attack (a) or Run (r)");
                string decision = Console.ReadLine();
                if (decision == "a")
                {
                    playerHero.TakeDamage(monster.strength);
                    monster.health -= playerHero.GetStrength();
                    playerHero.PrintHeroInfo();
                    monster.PrintMonsterInfo();
                    if (playerHero.health > 0 && monster.health <= 0)
                    {
                        playerHero.GetLoot(monster.loot);
                        playerHero.GetExperience(monster.experience);
                    }
                }
                if (decision == "r")
                {
                    inBattle = false;
                }
            }
            if (playerHero.health <= 0)
            {
                Console.Clear();
                Console.WriteLine("You died, press enter to exit.");
                Console.ReadLine();
                System.Environment.Exit(1);
            }
        }
    }
}
