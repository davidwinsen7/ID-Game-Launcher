using System.Diagnostics;
using System.IO;
using System.Windows;

namespace ID_Game_Launcher
{   
    class Launcher
    {
        public static void PlayGame(string gameFile)
        {
            if (File.Exists(gameFile))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(gameFile);
                Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show("Game file not found!");
            }
        }       
    }
}
