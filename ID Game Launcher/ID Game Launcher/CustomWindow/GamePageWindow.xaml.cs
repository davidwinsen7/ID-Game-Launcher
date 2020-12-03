using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ID_Game_Launcher.CustomWindow
{
    /// <summary>
    /// Interaction logic for GamePageWindow.xaml
    /// </summary>
    public partial class GamePageWindow : Window
    {
        private enum GameIndex
        {
            AGENT_BABY,
            SNOW_YARD,
            LAST_LINE
        }

        private string[] gameDesc = new string[MainWindow.numOfGames];
        private GameIndex gameIndex;

        public void InitGameDesc()
        {
            gameDesc[(int)GameIndex.AGENT_BABY] = "Play as Agent Baby! a secret agent who possesses a powerful weapon that can rewind people to younger age! " +
                                                   "Infiltrate the evil lair and make your way to the boss in this fun little 2d platformer!";
            gameDesc[(int)GameIndex.LAST_LINE] = "The Robots are trying to take control! All efforts had been done but all we can do left is to defend. " +
                                                   "We're at the Last Line of defense now. Join the battle to prevent Human Pride from being taken by The Robots and end this once and for all!";
            gameDesc[(int)GameIndex.SNOW_YARD] = "Shoot as many snowman as you can within the time limit! Share and compete with your friends to see who can score the highest! " +
                                                   "Be careful, the snowman may slide on the slippery floor!";
        }

        public GamePageWindow()
        {
            InitializeComponent();
        }

        public GamePageWindow(GameSlot gameSlot)
        {
            InitializeComponent();
            Title = gameSlot.GameName.Content.ToString();
            displayImage.Source = gameSlot.GameImage.Source;
            displayName.Content = gameSlot.GameName.Content.ToString();

            switch (Title)
            {
                case "Agent Baby":
                    gameIndex = GameIndex.AGENT_BABY;
                    break;
                case "Snow-Yard":
                    gameIndex = GameIndex.SNOW_YARD;
                    break;
                case "Last Line":
                    gameIndex = GameIndex.LAST_LINE;
                    break;
            }
            InitGameDesc();
            gameDescription.Text = gameDesc[(int)gameIndex];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Launcher.PlayGame(Title);
        }

        private void backButton_MouseEnter(object sender, MouseEventArgs e)
        {
            backButton.Width = 55;
            backButton.Height = 55;
            backButton.Opacity = 0.5;
        }

        private void backButton_MouseLeave(object sender, MouseEventArgs e)
        {
            backButton.Width = 50;
            backButton.Height = 50;
            backButton.Opacity = 1;
        }

        private void backButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            GameSlot.gameWindowIsOpen = false;
        }
    }
}
