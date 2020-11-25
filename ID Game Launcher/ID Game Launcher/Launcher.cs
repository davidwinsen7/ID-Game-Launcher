using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Path = System.IO.Path;
using System.IO;

namespace ID_Game_Launcher
{   
    class Launcher
    {
        private static string rootDirectory;
        private static string gameDirectory;
        private static string gameExe;

        private static string gameFolder;
        private static string gameExeName;
        public static void PlayGame(string fileName)
        {
            switch (fileName)
            {
                case "AgentBaby":
                    gameFolder = "Agent Baby";
                    gameExeName = "Agent Baby.exe";
                    break;
                case "SnowYard":
                    gameFolder = "Snow-Yard";
                    gameExeName = "Snow-Yard.exe";
                    break;
            }

            rootDirectory = Directory.GetCurrentDirectory();
            gameDirectory = Path.Combine(rootDirectory, "Games");
            gameExe = Path.Combine(gameDirectory, gameFolder, gameExeName);

            if (File.Exists(gameExe))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(gameExe);
                startInfo.WorkingDirectory = Path.Combine(gameDirectory, "Agent Baby");
                Process.Start(startInfo);
            }
        }
    }
}
