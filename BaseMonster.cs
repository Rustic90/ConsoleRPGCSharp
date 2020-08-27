using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public abstract class BaseMonster
    {
        public string name;
        public int health;
        public int strength;
        public int loot;

        public void PrintMonsterInfo()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("Monster: " + name);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Strength: " + strength);
        }
    }
}
