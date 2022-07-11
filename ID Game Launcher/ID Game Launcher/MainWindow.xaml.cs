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
            LoadPromoBoxes();
            directoryManagement.InitialSetup();
        }
        
        private void LoadPromoBoxes()
        {
            List<User_Controls.PromotionalBox> promoBoxes = new List<User_Controls.PromotionalBox>();
            promoBoxes.Add(new User_Controls.PromotionalBox("DISCOVER"));
            promoBoxes.Add(new User_Controls.PromotionalBox("NAVIGATE"));
            promoBoxes.Add(new User_Controls.PromotionalBox("EXPERIENCE"));

            for (int i = 0; i < promoBoxes.Count; i++)
            {
                promoBoxes[i].promoImage.Source = new BitmapImage(new Uri("GameImages/" + "Screenshot" + (i+1) + ".png", UriKind.Relative));
                DashboardGrid.Children.Add(promoBoxes[i]);
                Grid.SetRow(promoBoxes[i], 1);
                Grid.SetColumn(promoBoxes[i], i);
                promoBoxes[i].VerticalAlignment = VerticalAlignment.Top;
            }         
        }

        private void LoadGamesToLibrary()
        {
            maxRow = GameTabGrid.RowDefinitions.Count - 1; //Get the value of maximum row in library page
            maxColumn = GameTabGrid.ColumnDefinitions.Count - 1; //Get the value of maximum column in library page

            List<GameSlot> gameSlots = new List<GameSlot>();
            gameSlots.Add(new GameSlot("AgentBaby", "Agent Baby"));
            gameSlots.Add(new GameSlot("SnowYard", "Snow-Yard"));
            gameSlots.Add(new GameSlot("LastLine", "Last Line"));
            gameSlots.Add(new GameSlot("MoonConquest", "Moon Conquest"));
            
            numOfGames = gameSlots.Count;

            for(int i = 0; i < gameSlots.Count; i++)
            {
                if (currentRow > maxRow)
                    MessageBox.Show("Row overloaded!");

               
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

        private void FileExitMenu(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void InstallSettingsMenu(object sender, RoutedEventArgs e)
        {
            CustomWindow.InstallSettings installSettings = new CustomWindow.InstallSettings();
            installSettings.ShowDialog();
        }

        //source code for window_sizechanged from: https://stackoverflow.com/questions/19393774/how-to-make-all-controls-resize-accordingly-proportionally-when-window-is-maximi
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            myGrid.Width = e.NewSize.Width;
            myGrid.Height = e.NewSize.Height;

            double xChange = 1, yChange = 1;

            if (e.PreviousSize.Width != 0)
                xChange = (e.NewSize.Width / e.PreviousSize.Width);

            if (e.PreviousSize.Height != 0)
                yChange = (e.NewSize.Height / e.PreviousSize.Height);

            foreach (FrameworkElement fe in myGrid.Children)
            {
                //because I didn't want to resize the grid I'm having inside the canvas in this particular instance. (doing that from xaml) 
                if (fe is Grid == false)
                {
                    fe.Height = fe.ActualHeight * yChange;
                    fe.Width = fe.ActualWidth * xChange;

                    Canvas.SetTop(fe, Canvas.GetTop(fe) * yChange);
                    Canvas.SetLeft(fe, Canvas.GetLeft(fe) * xChange);
                }
            }
        }       
    }
}
