using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Warrior : BaseHero
    {
        public Warrior()
        {

        }
        public Warrior(string Hero, int Health, int Strength, int Magic)
        {
            hero = Hero;
            health = Health;
            strength = Strength;
            magic = Magic;
        }
    }
}
