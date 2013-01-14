using System.Collections.Generic;
using System.Xml.Linq;
using nRage.Contract.TheTVDB;

namespace nRage.Clients
{
    public interface ITvdbResponseMapper
    {
        List<string> ConvertPipedStringToList(string input);
        MirrorsResponse MapXMLToMirrors(XDocument xml);
        ServerTimeResponse MapXMLToServerTime(XDocument xml);
        GetUpdatesResponse MapXMLToUpdates(XDocument xml);
        SeriesInfoResponse MapXMLToSeriesInfo(XDocument xml);
        SearchResponse MapXMLToSearch(XDocument xml);
        EpisodeListResponse MapXMLToEpisodeList(XDocument xml);
    }
}