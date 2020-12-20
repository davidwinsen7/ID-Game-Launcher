using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ID_Game_Launcher.CustomWindow
{
    /// <summary>
    /// Interaction logic for InstallSettings.xaml
    /// </summary>
    public partial class InstallSettings : Window
    {
        public string defaultDirectory;
        public static string currentDirectory;

        public InstallSettings()
        {
            InitializeComponent();
            initialSetup();
        }

        private void initialSetup()
        {
            defaultDirectory = System.IO.Path.Combine(Directory.GetCurrentDirectory(),"Games");
            Directory.CreateDirectory(defaultDirectory);
            if (currentDirectory != null)
            {
                locationText.Text = currentDirectory;
            }              
            else
            {
                currentDirectory = defaultDirectory;
                locationText.Text = defaultDirectory;            
            }
                
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            locationText.Text = folderBrowser.SelectedPath;

            if(currentDirectory != defaultDirectory)
            {
                //Directory.CreateDirectory(currentDirectory);
                currentDirectory = folderBrowser.SelectedPath;
            }
            
        }
    }
}
