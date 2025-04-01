using Lab3_appz.Models;
using Lab3_appz.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_appz.Factories
{
    class AnotherGenreFactory : GameFactory
    {
        private string customGenre;

        public AnotherGenreFactory(string genre)
        {
            customGenre = genre;
        }

        public override Game CreateGame(string name, string platform, int cpu_requirement, int ram_requirement, int vram_requirement, int hdd_requirement, string[] logindata)
        {
            return new AnotherGenreGame(name, customGenre, platform, cpu_requirement, ram_requirement, vram_requirement, hdd_requirement, logindata);
        }
    }
}
