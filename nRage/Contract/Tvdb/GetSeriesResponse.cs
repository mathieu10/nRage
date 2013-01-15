using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nRage.Contract.Tvdb
{
    public class GetSeriesResponse
    {
        public List<GetSeriesResult> Series { get; set; }
    }
}
