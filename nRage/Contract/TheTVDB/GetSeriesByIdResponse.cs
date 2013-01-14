using System.Collections.Generic;

namespace nRage.Contract.TheTVDB
{
    public class GetSeriesByIdResponse
    {
        public List<GetSeriesByIdResult> Series { get; set; }
    }
}