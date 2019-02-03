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
    /// Logica di interazione per BotWindow.xaml
    /// </summary>
    public partial class BotWindow : UserControl
    {
        public BotWindow()
        {
            InitializeComponent();
        }

        public void AddQuestion(string text)
        {

            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Right;
            tb.FontSize = 16;
            tb.MaxWidth = uc.Width / (4 / 3);
            tb.Background = Brushes.LightBlue;
            tb.Margin = new Thickness(5,5,5,5);
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Text = text;

            Grid g = new Grid();
            g.VerticalAlignment = VerticalAlignment.Top;
            g.Width = uc.Width;
            g.Children.Add(tb);

            w.Children.Add(g);
        }

        public void AddReply(string text)
        {

            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Left;
            tb.FontSize = 16;
            tb.MaxWidth = uc.Width / (4 / 3);
            tb.Background = Brushes.Yellow;
            tb.Margin = new Thickness(5, 5, 5, 5);
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Text = text;

            Grid g = new Grid();
            g.VerticalAlignment = VerticalAlignment.Top;
            g.Width = uc.Width;
            g.Children.Add(tb);

            w.Children.Add(g);
        }
    }
}
