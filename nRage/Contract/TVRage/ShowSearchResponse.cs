using System;
using System.Collections.Generic;

namespace nRage.Contract.TVRage
{
    [Serializable]
    public class ShowSearchResponse
    {
        public ICollection<ShowSearchResult> Results { get; set; }
    }
}