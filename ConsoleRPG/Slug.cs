﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Slug : BaseMonster
    {
        public Slug()
        {
            name = "Slug";
            health = 3;
            maxHealth = 3;
            strength = 1;
            loot = 1;
            experience = 2;
        }
    }
}
