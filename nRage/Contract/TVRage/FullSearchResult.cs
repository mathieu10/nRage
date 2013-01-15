using System;
using System.Collections.Generic;

namespace nRage.Contract.Tvrage
{
    [Serializable]
    public class FullSearchResult : SearchResult
    {
        public string RunTime {get;set;}
        public string Network { get; set; }
        public string AirTime { get; set; }
        public string AirDay { get; set; }
        public List<AKA> AKAs { get; set; }
    }
}