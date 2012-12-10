using System;
using System.Collections.Generic;

namespace nRage.Contract.TVRage
{
    [Serializable]
    public class ShowFullSearchResult : SearchResult
    {
        public string Network { get; set; }
        public string AirTime { get; set; }
        public string AirDay { get; set; }
        public List<AKA> AKAs { get; set; }
    }
}