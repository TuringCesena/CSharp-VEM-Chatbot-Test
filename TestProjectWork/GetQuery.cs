using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;

namespace TestProjectWork
{
    

    class GetQuery

    {

        public static async Task<List<Structures.api_news>> GetNews()
        {
            string link = MainWindow.urlNewsCompleto;
            List<Structures.api_news> l = new List<Structures.api_news>();

            var response = await ReturnJSON(new Uri(link, UriKind.Absolute));

            return JsonConvert.DeserializeObject<List<Structures.api_news>>(response);
        }


        public static async Task<List<Structures.api_news>> GetOneNews(int num)
        {
            string link = MainWindow.urlNewsCompleto + "/" + num.ToString();
            List<Structures.api_news> l = new List<Structures.api_news>();

            var response = await ReturnJSON(new Uri(link, UriKind.Absolute));

            return JsonConvert.DeserializeObject<List<Structures.api_news>>(response); 
        }

        public static async Task<List<Structures.api_news>> GetNewsFromUser(int num)
        {
            string link = MainWindow.urlNewsCompleto + "/users/" + num.ToString();
            List<Structures.api_news> l = new List<Structures.api_news>();

            var response = await ReturnJSON(new Uri(link, UriKind.Absolute));

            return JsonConvert.DeserializeObject<List<Structures.api_news>>(response);
        }

        public static async Task<List<Structures.api_servizi>> GetServizi()
        {
            string link = MainWindow.urlServiziCompleto;
            List<Structures.api_servizi> l = new List<Structures.api_servizi>();

            var response = await ReturnJSON(new Uri(link, UriKind.Absolute));

            return JsonConvert.DeserializeObject<List<Structures.api_servizi>>(response);
        }

        public static async Task<List<Structures.api_servizi>> GetOneServizio(int num)
        {
            string link = MainWindow.urlServiziCompleto + "/" + num.ToString();
            List<Structures.api_servizi> l = new List<Structures.api_servizi>();

            var response = await ReturnJSON(new Uri(link, UriKind.Absolute));

            return JsonConvert.DeserializeObject<List<Structures.api_servizi>>(response);
        }

        public static async Task<List<Structures.api_servizi>> GetServiziUser(int num)
        {
            string link = MainWindow.urlServiziCompleto + "/user/" + num.ToString();
            List<Structures.api_servizi> l = new List<Structures.api_servizi>();

            var response = await ReturnJSON(new Uri(link, UriKind.Absolute));

            return JsonConvert.DeserializeObject<List<Structures.api_servizi>>(response);
        }

        private static async Task<string> ReturnJSON(Uri url)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(url);
            return result;
        }
    }
}
