using System;
using System.Collections.Generic;

namespace nRage.Contract.Tvrage
{
    [Serializable]
    public class FullSearchResponse
    {        
        public ICollection<FullSearchResult> Results { get; set; }
    }
}