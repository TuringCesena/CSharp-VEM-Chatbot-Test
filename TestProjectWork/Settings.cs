using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TestProjectWork
{
    class Settings
    {
        public static string rootUrl { get; set; }
        public static string urlChat { get; set; }
        public static string urlNews { get; set; }
        public static string urlServizi { get; set; }
    }

    class SSettings
    {
        public string rootUrl { get; set; }
        public string urlChat { get; set; }
        public string urlNews { get; set; }
        public string urlServizi { get; set; }
    }

    static class ManageSettings
    {
        public static void ImportSettings(string url)
        {
            StreamReader sr = new StreamReader(url);
            string json = sr.ReadToEnd();

            SSettings s = JsonConvert.DeserializeObject<SSettings>(json);

            Settings.rootUrl = s.rootUrl;
            Settings.urlChat = s.urlChat;
            Settings.urlNews = s.urlNews;
            Settings.urlServizi = s.urlServizi;

            sr.Close();
        }

        public static void SaveSettings(string url, SSettings s)
        {
            StreamWriter sw = new StreamWriter(url);
            sw.WriteLine(JsonConvert.SerializeObject(s));
            sw.Close();
        }
    }



}
