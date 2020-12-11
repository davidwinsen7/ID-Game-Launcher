using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ID_Game_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int numOfGames;//To be used in game page window

        private int currentRow = 0; //currentRow for library page
        private int maxRow; //maximum row for library page
        private int currentColumn = 0; //current column for library page
        private int maxColumn; //maximum column for library page

        public MainWindow()
        {
            InitializeComponent();
            LoadGamesToLibrary();
        }
        
        private void LoadGamesToLibrary()
        {
            maxRow = GameTabGrid.RowDefinitions.Count - 1; //Get the value of maximum row in library page
            maxColumn = GameTabGrid.ColumnDefinitions.Count - 1; //Get the value of maximum column in library page

            List<GameSlot> gameSlots = new List<GameSlot>();
            gameSlots.Add(new GameSlot("AgentBaby", "Agent Baby"));
            gameSlots.Add(new GameSlot("SnowYard", "Snow-Yard"));
            gameSlots.Add(new GameSlot("LastLine", "Last Line"));

            numOfGames = gameSlots.Count;

            for(int i = 0; i < gameSlots.Count; i++)
            {
                if (currentRow > maxRow)
                    MessageBox.Show("Row overloaded!");

                gameSlots[i].GameImage.Source = new BitmapImage(new Uri("GameImages/" + gameSlots[i].Name + ".png", UriKind.Relative));
                GameTabGrid.Children.Add(gameSlots[i]);

                /*Game slots position management*/
                if (currentColumn > maxColumn)
                {
                    currentColumn = 0;
                    currentRow++;
                }
                Grid.SetRow(gameSlots[i], currentRow);
                Grid.SetColumn(gameSlots[i], currentColumn);
                currentColumn++;                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.SelectedIndex = 1; //Go to library page
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
