using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Hero
    {
        private string hero;
        private int level;
        public int experience;
        public int maxHealth;
        public int health;
        private int strength;
        private int magic;
        private int gold = 0;
        

        public Hero()
        {

        }
        public Hero(string classChoice)
        {
            if (classChoice == "Warrior")
            {
                this.hero = "Warrior";
                this.level = 1;
                this.experience = 0;
                this.maxHealth = 20;
                this.health = 20;
                this.strength = 4;
                this.magic = 0;
                this.gold = 0;
            }
            else if (classChoice == "Wizard")
            {
                this.hero = "Wizard";
                this.level = 1;
                this.experience = 0;
                this.maxHealth = 10;
                this.health = 10;
                this.strength = 2;
                this.magic = 2;
                this.gold = 0;
            }
            else if (classChoice == "Ranger")
            {
                this.hero = "Ranger";
                this.level = 1;
                this.experience = 0;
                this.maxHealth = 12;
                this.health = 12;
                this.strength = 2;
                this.magic = 2;
                this.gold = 0;
            }
            else if (classChoice == "Cleric")
            {
                this.hero = "Cleric";
                this.level = 1;
                this.experience = 0;
                this.maxHealth = 10;
                this.health = 10;
                this.strength = 2;
                this.magic = 2;
                this.gold = 0;
            }
        }

        public void PrintHeroInfo()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("Class: " + hero);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Experience: " + experience);
            Console.WriteLine("Health: " + health + " / " + maxHealth);
            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("Magic: " + magic);
            Console.WriteLine("Gold: " + gold);
            Console.WriteLine("-----------------");
        }

        public void TakeDamage(int MonsterStrength)
        {
            this.health -= MonsterStrength;
        }

        public int GetStrength()
        {
            return this.strength;
        }

        public void GetLoot(int Loot)
        {
            this.gold += Loot;
        }

        public void GetExperience(int Experience)
        {
            this.experience += Experience;
        }
    }


}
