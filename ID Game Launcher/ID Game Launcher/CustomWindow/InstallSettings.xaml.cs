using System.Windows;
using System.Windows.Forms;
using System.IO;

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
