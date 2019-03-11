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

namespace TestProjectWork
{
    /// <summary>
    /// Logica di interazione per FiveRating.xaml
    /// </summary>
    public partial class FiveRating : UserControl
    {
        private int rating = 3;

        public FiveRating()
        {
            InitializeComponent();
            
            ChangeRating();
        }

        private void ChangeRating()
        {
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            btn5.IsEnabled = true;

            switch (rating)
            {
                case 1:
                    btn1.IsEnabled = false;
                    break;
                case 2:
                    btn2.IsEnabled = false;
                    break;
                case 3:
                    btn3.IsEnabled = false;
                    break;
                case 4:
                    btn4.IsEnabled = false;
                    break;
                case 5:
                    btn5.IsEnabled = false;
                    break;
            }
        }

        public string Header
        {
            get
            {
                return lblHeader.Content.ToString();
            }
            
            set
            {
                lblHeader.Content = value;
            }
        }

        public int Rating {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
                ChangeRating();
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            rating = 1;
            ChangeRating();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            rating = 2;
            ChangeRating();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            rating = 3;
            ChangeRating();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            rating = 4;
            ChangeRating();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            rating = 5;
            ChangeRating();
        }
    }
}
