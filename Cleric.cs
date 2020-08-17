using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Cleric : BaseHero
    {
        public Cleric(string Hero, int Health, int Strength, int Magic)
        {
            hero = Hero;
            health = Health;
            strength = Strength;
            magic = Magic;
        }
    }
}
