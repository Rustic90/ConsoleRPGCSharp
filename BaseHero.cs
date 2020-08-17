using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class BaseHero
    {
        public string hero;
        public int health;
        public int strength;
        public int magic;

        public void PrintHeroInfo()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("Class: " + hero);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("Magic: " + magic);
        }
    }


}
