using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace TestProjectWork
{
    class GetQuery
    {
        public GetQuery()
        {

        }

        public static List<string> GetJSON()
        {
            List<string> l = new List<string>();

            StreamReader sr = new StreamReader("Files\\Domande.json");
            string json = sr.ReadToEnd();
            sr.Close();

            List<Query> queries = JsonConvert.DeserializeObject<List<Query>>(json);

            foreach (Query q in queries)
            {
                l.Add(q.query);
            }

            return l;
        }
    }
}
