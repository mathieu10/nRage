using System;
using System.Collections.Generic;

namespace nRage.Contract.TVRage
{
    [Serializable]
    public class ShowSearchResponse
    {
        public ICollection<SearchResult> Results { get; set; }
    }
}