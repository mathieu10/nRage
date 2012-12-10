using System;
using System.Collections.Generic;

namespace nRage.Contract.TVRage
{
    [Serializable]
    public class SearchResponse
    {        
        public ICollection<SearchResult> Results { get; set; }
    }
}