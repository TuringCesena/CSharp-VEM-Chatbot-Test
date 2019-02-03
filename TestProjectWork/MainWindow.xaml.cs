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

namespace TestProjectWork
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string url = "https://api.api.ai/v1/query?v=20150910";
        string token = "cb7af0ed21dd41d9bac5c64afcc45b27";

        public MainWindow()
        {
            InitializeComponent();

            ImportaImpostazioni();
        }

        void ImportaImpostazioni()
        {
            StreamReader sr = new StreamReader("Files\\Impostazioni.json");
            string impostazioni = sr.ReadToEnd();
            sr.Close();

            Settings sett = JsonConvert.DeserializeObject<Settings>(impostazioni);

            txtUrl.Text = sett.url;
            txtToken.Text = sett.token;
            txtLang.Text = sett.language;

            btnAggiornaAPI.IsEnabled = false;
        }

        public string GetResult(string query)
        {
            string json = DoRequest(query, "en", "somerandomthing");
            QueryResult qr = JsonConvert.DeserializeObject<QueryResult>(json);
            return qr.result.fulfillment.speech;
        }

        public string DoRequest(string text, string language, string sessionID)
        {

            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "query", text },
                { "lang", language },
                { "sessionId", sessionID }
            };

            var data = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var result = "";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = client.PostAsync(url, data).Result;

            using (HttpContent content = response.Content)
            {
                result = response.Content.ReadAsStringAsync().Result;
                return result.ToString();
            }

        }

        void IniziaTest()
        {
            List<string> l = GetQuery.GetJSON();
            List<Test> tests = new List<Test>();

            foreach(string s in l)
            {
                Test test = new Test();
                test.query = s;
                test.response = GetResult(s);
                tests.Add(test);
            }

            grdEsito.ItemsSource = tests;
        }

        private void btnDomande_Click(object sender, RoutedEventArgs e)
        {
            Domande dom = new Domande();
            dom.ShowDialog();
        }

        private void txtUrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnAggiornaAPI.IsEnabled = true;
        }

        private void txtToken_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnAggiornaAPI.IsEnabled = true;
        }

        private void txtLang_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnAggiornaAPI.IsEnabled = true;
        }

        private void btnAggiornaAPI_Click(object sender, RoutedEventArgs e)
        {
            btnAggiornaAPI.IsEnabled = false;

            Settings sett = new Settings();
            sett.url = txtUrl.Text;
            sett.token = txtToken.Text;
            sett.language = txtLang.Text;

            StreamWriter sw = new StreamWriter("Files\\Impostazioni.json");
            sw.Write(JsonConvert.SerializeObject(sett));
            sw.Close();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            IniziaTest();
        }
    }
}
