using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Path = System.IO.Path;
using System.IO;
using System.Windows;

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
            gameFolder = fileName;
            gameExeName = fileName + ".exe";

            rootDirectory = Directory.GetCurrentDirectory();
            gameDirectory = Path.Combine(rootDirectory, "Games");
            gameExe = Path.Combine(gameDirectory, gameFolder, gameExeName);

            if (File.Exists(gameExe))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(gameExe);
                Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show("Game file not found!");
            }
        }
    }
}
