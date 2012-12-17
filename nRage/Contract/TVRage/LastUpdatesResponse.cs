using System.Collections.Generic;

namespace nRage.Contract.TVRage
{
    public class LastUpdatesResponse
    {
        public string Timestamp{get;set;}
        public string UpdatesCount{get;set;}
        public string Sorting{get;set;}
        public string ShowingPeriod{get;set;}

        public List<LastUpdatesShowResult> Shows{get;set;}
    }

}