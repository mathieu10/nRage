using System.Collections.Generic;

namespace nRage.Contract.Tvdb
{
    public class GetSeriesByIdResponse
    {
        public List<GetSeriesByIdResult> Series { get; set; }
    }
}