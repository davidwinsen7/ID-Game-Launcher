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
        private int libraryRow = 2;
        private int libraryColumn = 4;

        public MainWindow()
        {
            InitializeComponent();

            LoadGamesToLibrary();
        }
        
        private void LoadGamesToLibrary()
        {
            List<GameSlot> gameSlots = new List<GameSlot>();
            gameSlots.Add(new GameSlot("AgentBaby", "Agent Baby"));
            gameSlots.Add(new GameSlot("SnowYard", "Snow-Yard"));
            gameSlots.Add(new GameSlot("LastLine", "Last Line"));

            for(int i = 0; i < gameSlots.Count; i++)
            {
                gameSlots[i].GameImage.Source = new BitmapImage(new Uri("GameImages/" + gameSlots[i].Name + ".png", UriKind.Relative));
                GameTabGrid.Children.Add(gameSlots[i]);
                Grid.SetColumn(gameSlots[i], i); //This need to be fixed
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Directing to game library!");
            MenuTab.SelectedIndex = 1;
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
