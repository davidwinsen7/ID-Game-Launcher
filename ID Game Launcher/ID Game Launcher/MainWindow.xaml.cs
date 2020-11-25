using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ID_Game_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string AgentBabyDesc = "Play as Agent Baby! a secret agent who possesses a powerful weapon that can rewind people to younger age! Infiltrate the evil lair and make your way to the boss in this fun little 2d platformer!";

        public MainWindow()
        {
            InitializeComponent();
            GameDesc.Text = AgentBabyDesc;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Directing to game library!");
            MenuTab.SelectedIndex = 1;
            
        }

        private void PlayAgentBaby_Click(object sender, RoutedEventArgs e)
        {
            //Launcher.PlayGame(gameExe);
        }
    }
}
