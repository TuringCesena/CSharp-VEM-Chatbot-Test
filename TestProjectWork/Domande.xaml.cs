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
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace TestProjectWork
{
    /// <summary>
    /// Logica di interazione per Domande.xaml
    /// </summary>
    public partial class Domande : Window
    {
        string json;
        List<Query> domande;
        bool daSalvare = false;

        public Domande()
        {
            InitializeComponent();
            Imposta();
            ImportaDomande();
        }

        void Imposta()
        {
            
        }

        void ImportaDomande()
        {
            StreamReader sr = new StreamReader("Files\\Domande.json");
            json = sr.ReadToEnd();
            sr.Close();

            domande = JsonConvert.DeserializeObject<List<Query>>(json);

            dgrDomande.ItemsSource = domande;

            /*dgrDomande.Columns[0].Header = "Domanda";
            dgrDomande.Columns[1].Header = "Modificabile?";*/
        }


        private void btnEditFields_Click(object sender, RoutedEventArgs e)
        {
            btnEditFields.IsEnabled = false;
            dgrDomande.IsReadOnly = false;
        }

        private void btnCloseWithoutSaving_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCloseWIthSaving_Click(object sender, RoutedEventArgs e)
        {
            List<Query> queries = new List<Query>();

            foreach(Query query in dgrDomande.ItemsSource)
            {
                queries.Add(query);
            }

            StreamWriter sw = new StreamWriter("Files\\Domande.json");
            sw.AutoFlush = true;
            sw.Write(JsonConvert.SerializeObject(queries));
            sw.Close();
        }

        private void grdPrincipal_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Process.Start("notepad", Environment.CurrentDirectory + "\\Files\\Domande.json");
        }
    }
}
