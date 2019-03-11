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
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace TestProjectWork
{
    

    public partial class MainWindow : Window
    {
        int newsState = 0;
        int serviziState = 0;
        bool newsImplementate = true;

        public static string urlNewsCompleto;
        public static string urlChatCompleto;
        public static string urlServiziCompleto;

        public MainWindow()
        {
            InitializeComponent();

            btnNewsAll.IsEnabled = false;
            btnNewsOne.IsEnabled = true;
            btnNewsUser.IsEnabled = true;
            btnSaveSettings.IsEnabled = false;
            grdNewsChoose.Visibility = Visibility.Collapsed;

            ImportaImpostazioni();
            InizializzaNews(0);
            InizializzaServizi(0);
        }

        public void ImportaImpostazioni()
        {
            UpdateStatus(0, "Caricamento delle impostazioni in corso");
            ManageSettings.ImportSettings("Settings.json");
            txtSettingsRoot.Text = Settings.rootUrl;
            txtSettingsApiChat.Text = Settings.urlChat;
            txtSettingsApiNews.Text = Settings.urlNews;
            txtSettingsApiServizi.Text = Settings.urlServizi;
            UpdateStatus(0, "Caricamento delle impostazioni completato");

            urlChatCompleto = Settings.rootUrl + "/" + Settings.urlChat;
            urlServiziCompleto = Settings.rootUrl + "/" + Settings.urlServizi;
            urlNewsCompleto = Settings.rootUrl + "/" + Settings.urlNews;
        }

        public async void InizializzaNews(int type, int num = 0)
        {
            if (!newsImplementate)
            {
                return;
            }

            

            List<Structures.api_news> tabella = new List<Structures.api_news>();
            UpdateStatus(0, "Download delle news in corso");
            
            try { 
                switch (type)
                {
                    case 0:
                        tabella = await Task.Run(() => GetQuery.GetNews());
                        dgrNews.ItemsSource = tabella;
                        lblHttpNews.Content = Settings.urlNews;
                        await UpdateStatus(0, "Download delle news completato");
                        break;
                    case 1:
                        tabella = await Task.Run(() => GetQuery.GetOneNews(num));
                        dgrNews.ItemsSource = tabella;
                        lblHttpNews.Content = Settings.urlNews + "/" + num.ToString();
                        await UpdateStatus(0, "Download delle news completato");
                        break;
                    case 2:
                        tabella = await Task.Run(() => GetQuery.GetNewsFromUser(num));
                        dgrNews.ItemsSource = tabella;
                        lblHttpNews.Content = Settings.urlNews + "/users/" + num.ToString();
                        await UpdateStatus(0, "Download delle news completato");
                        break;
                }
            }
            catch (Exception e)
            {
                await UpdateStatus(1, "Errore durante il download delle news: " + e.Message.ToString());
            }
        }

        public async void InizializzaServizi(int type, int num = 0)
        {
            List<Structures.api_servizi> tabella;
            UpdateStatus(0, "Download dei servizi in corso");

            try
            {
                switch (type)
                {
                    case 0:
                        tabella = await Task.Run(() => GetQuery.GetServizi());
                        dgrServizi.ItemsSource = tabella;
                        lblHttpServizi.Content = Settings.urlServizi;

                        UpdateStatus(0, "Download dei servizi completato");
                        break;
                    case 1:
                        tabella = await Task.Run(() => GetQuery.GetOneServizio(num));
                        dgrServizi.ItemsSource = tabella;
                        lblHttpServizi.Content = Settings.urlServizi;

                        UpdateStatus(0, "Download dei servizi completato");
                        break;
                    case 2:
                        tabella = await Task.Run(() => GetQuery.GetServiziUser(num));
                        dgrServizi.ItemsSource = tabella;
                        lblHttpServizi.Content = Settings.urlServizi;

                        UpdateStatus(0, "Download dei servizi completato");
                        break;
                }
                

            }

            catch (Exception e)
            {
                UpdateStatus(1, "Download dei servizi fallito: " + e.Message.ToString());
            }
        }


        async Task UpdateStatus(int type, string message)
        {

            switch (type)
            {
                case 0:
                    imgStatus.Source = new BitmapImage(new Uri("img\\icons\\Check.png", UriKind.RelativeOrAbsolute));
                    lblStatus.Content = message;
                    break;
                case 1:
                    imgStatus.Source = new BitmapImage(new Uri("img\\icons\\Error.png", UriKind.RelativeOrAbsolute));
                    lblStatus.Content = message;
                    break;
            }
        }

        void NewsControllaNumero()
        {
            int.TryParse(txtNewsID.Text, out int r);
        }

        private void btnNewsAll_Click(object sender, RoutedEventArgs e)
        {
            newsState = 0;

            btnNewsAll.IsEnabled = false;
            btnNewsOne.IsEnabled = true;
            btnNewsUser.IsEnabled = true;
            grdNewsChoose.Visibility = Visibility.Collapsed;

            InizializzaNews(0);

        }

        private void btnNewsOne_Click(object sender, RoutedEventArgs e)
        {
            newsState = 1;

            btnNewsAll.IsEnabled = true;
            btnNewsOne.IsEnabled = false;
            btnNewsUser.IsEnabled = true;
            grdNewsChoose.Visibility = Visibility.Visible;

            InizializzaNews(newsState, int.Parse(txtNewsID.Text));
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("\\d");
            if (!regex.IsMatch(e.Text) && e.Text.IsNumeric())
            { 
                e.Handled = true;
            }
        }

        private void btnNewsUser_Click(object sender, RoutedEventArgs e)
        {
            newsState = 2;

            btnNewsAll.IsEnabled = true;
            btnNewsOne.IsEnabled = true;
            btnNewsUser.IsEnabled = false;
            grdNewsChoose.Visibility = Visibility.Visible;

            InizializzaNews(newsState, int.Parse(txtNewsID.Text));
        }

        private void txtNewsID_TextChanged(object sender, TextChangedEventArgs e)
        {
            InizializzaNews(newsState, int.Parse(txtNewsID.Text));
        }

        private void SettingsTextChanged(object sender, TextChangedEventArgs e)
        {
            btnSaveSettings.IsEnabled = true;
        }

        private void btnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            ManageSettings.SaveSettings("Settings.json", new SSettings
            {
                rootUrl = txtSettingsRoot.Text,
                urlChat = txtSettingsApiChat.Text,
                urlNews = txtSettingsApiNews.Text,
                urlServizi = txtSettingsApiServizi.Text
            });

            btnSaveSettings.IsEnabled = false;

            ImportaImpostazioni();
        }

        private void btnServiziAll_Click(object sender, RoutedEventArgs e)
        {
            btnServiziOne.IsEnabled = true;
            btnServiziUser.IsEnabled = true;
            btnServiziAll.IsEnabled = false;

            grdServiziChoose.Visibility = Visibility.Collapsed;

            serviziState = 0;

            InizializzaServizi(serviziState);


        }

        private void btnServiziOne_Click(object sender, RoutedEventArgs e)
        {
            btnServiziOne.IsEnabled = false;
            btnServiziUser.IsEnabled = true;
            btnServiziAll.IsEnabled = true;

            grdServiziChoose.Visibility = Visibility.Visible;
            txtServiziID.Focus();

            serviziState = 1;
            InizializzaServizi(serviziState, int.Parse(txtServiziID.Text));
        }

        private void btnServiziUser_Click(object sender, RoutedEventArgs e)
        {
            btnServiziOne.IsEnabled = true;
            btnServiziUser.IsEnabled = false;
            btnServiziAll.IsEnabled = true;

            grdServiziChoose.Visibility = Visibility.Visible;
            txtServiziID.Focus();

            serviziState = 2;
            InizializzaServizi(serviziState, int.Parse(txtServiziID.Text));
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            InizializzaServizi(serviziState);
            InizializzaNews(newsState);
        }

        private void btnNewsTest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
