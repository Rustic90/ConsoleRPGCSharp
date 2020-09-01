using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Wolf : BaseMonster
    {
        public Wolf()
        {
            name = "Wolf";
            health = 6;
            strength = 3;
            loot = 3;
            experience = 5;
        }
    }
}
