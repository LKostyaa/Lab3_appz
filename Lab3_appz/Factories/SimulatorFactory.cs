using Lab3_appz.Models;

using Lab3_appz.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_appz.Factories
{
    class SimulatorFactory : GameFactory
    {
        public override Game CreateGame(string name, string platform, int cpu_requirement, int ram_requirement, int vram_requirement, int hdd_requirement, string[] logindata)
        {
            return new Simulator(name, platform, cpu_requirement, ram_requirement, vram_requirement, hdd_requirement, logindata);
        }
    }
}
