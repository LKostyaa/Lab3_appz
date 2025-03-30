using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2_APPZ.Games
{

    class AnotherGenreGame : Game
    {
        public AnotherGenreGame(string name, string genre, string platform, int cpu_requirement, int ram_requirement, int vram_requirement, int hdd_requirement, string[] logindata)
            : base(name,
                   genre,
                   platform,
                   cpu_requirement,
                   ram_requirement,
                   vram_requirement,
                   hdd_requirement,
                   logindata)
        { }
    }


}
