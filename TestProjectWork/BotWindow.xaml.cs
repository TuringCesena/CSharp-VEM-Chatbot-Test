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

        public void AddQuestion(string text, double wndWidth)
        {

            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Right;
            tb.FontSize = 16;
            tb.Background = Brushes.LightBlue;
            tb.Margin = new Thickness(5,5,5,5);
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Text = text;

            Grid g = new Grid();
            g.ColumnDefinitions.Add(new ColumnDefinition());
            g.ColumnDefinitions.Add(new ColumnDefinition());
            g.ColumnDefinitions.Add(new ColumnDefinition());
            
            g.VerticalAlignment = VerticalAlignment.Top;

            Grid g1 = new Grid();
            g1.SetValue(Grid.ColumnSpanProperty, 2);
            g1.SetValue(Grid.ColumnProperty, 2);

            g1.Children.Add(tb);
            g.Children.Add(g1);
            w.Children.Add(g);

        }

        public void AddReply(string text, double maxWidth)
        {

            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Right;
            tb.FontSize = 16;
            tb.Background = Brushes.LightBlue;
            tb.Margin = new Thickness(5, 5, 5, 5);
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Text = text;

            Grid g = new Grid();
            g.ColumnDefinitions.Add(new ColumnDefinition());
            g.ColumnDefinitions.Add(new ColumnDefinition());
            g.ColumnDefinitions.Add(new ColumnDefinition());

            g.VerticalAlignment = VerticalAlignment.Top;

            Grid g1 = new Grid();
            g1.SetValue(Grid.ColumnSpanProperty, 2);
            g1.SetValue(Grid.ColumnProperty, 1);

            g1.Children.Add(tb);
            g.Children.Add(g1);
            w.Children.Add(g);

        }

    }
}
