using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2_APPZ.Games
{
    class Simulator : Game
    {
        public Simulator(string name, string platform, int cpu_requirement, int ram_requirement, int vram_requirement, int hdd_requirement, string[] logindata)
            : base(name,
                   "Simulator",
                   platform,
                   cpu_requirement,
                   ram_requirement,
                   vram_requirement,
                   hdd_requirement,
                   logindata)
        { }
    }
}
