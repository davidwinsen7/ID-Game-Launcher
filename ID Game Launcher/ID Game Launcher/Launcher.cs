using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ID_Game_Launcher
{
    class Launcher
    {
        public static void PlayGame(string fileName)
        {
            Process.Start(fileName);
        }

    }
}
