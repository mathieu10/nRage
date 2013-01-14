using System.Collections.Generic;
using System.Xml.Linq;
using nRage.Contract.TheTVDB;

namespace nRage.Clients
{
    public interface ITvdbResponseMapper
    {
        MirrorsResponse MapXMLToMirrors(XDocument xml);
        ServerTimeResponse MapXMLToServerTime(XDocument xml);
        GetUpdatesResponse MapXMLToUpdates(XDocument xml);
        SeriesInfoResponse MapXMLToSeriesInfo(XDocument xml);
        GetSeriesResponse MapXMLToGetSeries(XDocument xml);
        EpisodeListResponse MapXMLToEpisodeList(XDocument xml);
        GetSeriesResponse MapXMLToGetSeriesById(XDocument xml);
    }
}