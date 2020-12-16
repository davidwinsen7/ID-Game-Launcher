using System.Windows;
using System.Windows.Controls;
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
            /*Open selected game page window*/          
            GamePageWindow gamePageWindow = new GamePageWindow(this);
            gamePageWindow.ShowDialog(); //use showdialog to disable other window when game page window is open                     
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
