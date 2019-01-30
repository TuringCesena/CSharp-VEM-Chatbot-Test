using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectWork
{
    class QueryResult
    {
        public string id { get; set; }
        public string timestamp { get; set; }
        public string lang { get; set; }
        public Result result { get; set; }
        public Status status { get; set; }
        public string sessionId { get; set; }

    }

    class Result
    {
        public string source { get; set; }
        public string resolvedQuery { get; set; }
        public string action { get; set; }
        public bool actionIncomplete { get; set; }
        public Parameters parameters { get; set; }
        public string[] contexts { get; set; }
        public Metadata metadata { get; set; }
        public Fulfillment fulfillment { get; set; }
        public float score { get; set; }

    }

    class Parameters
    {
        public string aziende { get; set; }
    }

    class Metadata
    {
        public string intentId { get; set; }
        public string webhookUsed { get; set; }
        public string webhookForSlotFillingUsed { get; set; }
        public string isFallbackIntent { get; set; }
        public string intentName { get; set; }
    }

    class Fulfillment
    {
        public string speech { get; set; }
        public List<Message> messages { get; set; }
    }

    class Message
    {
        public int type { get; set; }
        public string speech { get; set; }
    }

    class Status
    {
        public int code { get; set; }
        public string errorType { get; set; }
    }


}
