using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_appz.Models

{
    class OnlineAdventures : Game
    {

        public OnlineAdventures(string name, string platform, int cpu_requirement, int ram_requirement, int vram_requirement, int hdd_requirement, string[] logindata)
            : base(name, "Online Adventures", platform, cpu_requirement, ram_requirement, vram_requirement, hdd_requirement, logindata)
        {
            SetOnline();
        }
    }
}
