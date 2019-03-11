using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectWork.Structures
{
    class api_chat
    {
        String response { get; set; }
    }

    class api_news
    {
        public int id { get; set; }
        public List<string> servizi { get; set; }
        public string news { get; set; }
        public string testo { get; set; }
        public string allegato { get; set; }
        public DateTime data_pubblicazione { get; set; }
        public DateTime data_fine_pubblicazione { get; set; }
    }

    class api_servizi
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string descrizione { get; set; }
    }

    class test_news
    {
        public int id { get; set; }
    }

}
