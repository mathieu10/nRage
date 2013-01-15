using System.Collections.Generic;
using System.Xml.Linq;
using nRage.Contract.Tvdb;

namespace nRage.Client
{
    public interface ITvdbResponseMapper
    {
        MirrorsResponse MapXMLToMirrors(XDocument xml);
        ServerTimeResponse MapXMLToServerTime(XDocument xml);
        GetUpdatesResponse MapXMLToUpdates(XDocument xml);
        SeriesInfoResponse MapXMLToSeriesInfo(XDocument xml);
        EpisodeListResponse MapXMLToEpisodeList(XDocument xml);
        GetSeriesResponse MapXMLToGetSeries(XDocument xml);
        GetSeriesByIdResponse MapXMLToGetSeriesById(XDocument xml);        
    }
}