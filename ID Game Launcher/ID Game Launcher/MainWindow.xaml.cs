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
using Path = System.IO.Path;

namespace ID_Game_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            GameSlot slot1 = new GameSlot();
            slot1.GameName.Content = "Agent Baby";
            slot1.Name = "AgentBaby";

            GameSlot slot2 = new GameSlot();
            slot2.GameName.Content = "Snow Yard";
            slot2.Name = "SnowYard";

            GameSlot slot3 = new GameSlot();
            slot3.GameName.Content = "Last Line";
            slot3.Name = "LastLine";

            GameTabGrid.Children.Add(slot1);
            GameTabGrid.Children.Add(slot2);
            GameTabGrid.Children.Add(slot3);

            Grid.SetColumn(slot2, 1);
            Grid.SetColumn(slot3, 2);

            slot1.GameImage.Source = new BitmapImage(new Uri("Images/agent baby logo.png", UriKind.Relative));
            slot2.GameImage.Source = new BitmapImage(new Uri("Images/snow-yard Icon.png", UriKind.Relative));
            slot3.GameImage.Source = new BitmapImage(new Uri("Images/Last Line icon.png", UriKind.Relative));
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

        private void MenuTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(MenuTab.SelectedIndex == 0)
            {
                MenuTitle.Content = "DASHBOARD";
            }
            else if(MenuTab.SelectedIndex == 1)
            {
                MenuTitle.Content = "LIBRARY";
            }
        }
    }
}
