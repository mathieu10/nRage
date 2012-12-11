using System;
using System.Collections.Generic;

namespace nRage.Contract.TVRage
{
    [Serializable]
    public class FullSearchResponse
    {        
        public ICollection<FullSearchResult> Results { get; set; }
    }
}