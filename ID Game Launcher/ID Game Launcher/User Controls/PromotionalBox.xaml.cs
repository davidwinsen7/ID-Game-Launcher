using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ID_Game_Launcher.User_Controls
{
    /// <summary>
    /// Interaction logic for PromotionalBox.xaml
    /// </summary>
    public partial class PromotionalBox : UserControl
    {
        public PromotionalBox()
        {
            InitializeComponent();
        }
        public PromotionalBox(string _Slogan)
        {
            InitializeComponent();
            sloganText.Content = _Slogan;

            switch (_Slogan)
            {
                case "DISCOVER":
                    promoDescText.Text = "Library of games developed by the indie game developer: Indie David!";
                    break;
                case "NAVIGATE":
                    promoDescText.Text = "Throughout the launcher flawlessly with no limitations";
                    break;
                case "EXPERIENCE":
                    promoDescText.Text = "True freedom of playing. Every single game in this launcher is FREE!";
                    break;
            }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            promoGrid.Width += 10;
            promoGrid.Height += 10;
            promoPanel.Width += 10;
            promoPanel.Height += 10;
            promoImage.Width += 10;
            promoImage.Height += 10;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            promoGrid.Width -= 10;
            promoGrid.Height -= 10;
            promoPanel.Width -= 10;
            promoPanel.Height -= 10;
            promoImage.Width -= 10;
            promoImage.Height -= 10;
        }
    }
}
