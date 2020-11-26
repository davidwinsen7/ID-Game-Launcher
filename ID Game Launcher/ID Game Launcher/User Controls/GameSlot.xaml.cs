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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ID_Game_Launcher.CustomWindow;

namespace ID_Game_Launcher
{
    /// <summary>
    /// Interaction logic for GameSlot.xaml
    /// </summary>
    public partial class GameSlot : UserControl
    {
        public GameSlot()
        {
            InitializeComponent();
        }

        public GameSlot(string _Name, string _displayName)
        {
            
            InitializeComponent();
            Name = _Name;
            GameName.Content = _displayName;
        }

        private void PanelClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(this.Name + " clicked");
            //Launcher.PlayGame(displayName);
            GamePageWindow gamePageWindow = new GamePageWindow(this);
            gamePageWindow.Show();
        }
        private void MouseHover(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.5f;
        }
        private void Mouse_Leave(object sender, RoutedEventArgs e)
        {
            this.Opacity = 1f;
        }
    }
}
