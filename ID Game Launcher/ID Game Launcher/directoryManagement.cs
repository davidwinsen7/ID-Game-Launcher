using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;


namespace ID_Game_Launcher
{
    class directoryManagement
    {
        public static string locTxt = Path.Combine(Directory.GetCurrentDirectory(), "Install Location.txt");

        public static string defaultDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Games");
        public static string currentDirectory; 

        public static void initialSetup()
        {

            if (File.ReadAllText(locTxt) == "")
            {
                File.WriteAllText(locTxt, defaultDirectory);
                currentDirectory = defaultDirectory;
            }
            else
            {
                currentDirectory = File.ReadAllText(locTxt);
                Directory.CreateDirectory(currentDirectory); //create directory just in case
            }

        }
    }
}
