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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Launcher.PlayGame(Title);
        }
    }
}
