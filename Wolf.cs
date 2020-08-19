using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Wolf : Monster
    {
        public Wolf()
        {
            name = "Wolf";
            health = 6;
            strength = 2;
            loot = 1;
        }
    }
}
