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
        public InstallSettings()
        {
            InitializeComponent();
            locationText.Text = directoryManagement.currentDirectory;
        }        

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            if(folderBrowser.SelectedPath != "")
            {
                locationText.Text = folderBrowser.SelectedPath;
                Directory.CreateDirectory(folderBrowser.SelectedPath); //create directory just in case
                directoryManagement.currentDirectory = folderBrowser.SelectedPath;
                File.WriteAllText(directoryManagement.locTxt, directoryManagement.currentDirectory);
            }
            else
            {
                return;
            }
           
        }
    }
}
