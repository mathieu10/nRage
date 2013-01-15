using System;
using System.Collections.Generic;

namespace nRage.Contract.Tvrage
{

    [Serializable]
    public class SearchResponse
    {        
        public ICollection<SearchResult> Results { get; set; }
    }
}