﻿using Lab3_appz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_appz.Factories
{
    abstract class GameFactory
    {
        public abstract Game CreateGame(string name, string platform, int cpu_requirement, int ram_requirement, int vram_requirement, int hdd_requirement, string[] logindata);
    }
}
