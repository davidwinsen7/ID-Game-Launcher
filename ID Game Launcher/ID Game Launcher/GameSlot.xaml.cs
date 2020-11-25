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

        private void PanelClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(this.Name + " clicked");
            Launcher.PlayGame(this.Name);
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
