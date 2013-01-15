using System.Collections.Generic;
using System.Xml.Linq;
using nRage.Contract.Tvrage;

namespace nRage.Interface
{
    public interface ITvrageMapper
    {
        ShowInfoResponse MapXMLToShowInfoResponse(XDocument xml);
        EpisodeListResponse MapXMLToEpisodeListResponse(XDocument xml);
        EpisodeInfoResponse MapXMLToEpisodeInfoResponse(XDocument xml);
        FullShowInfoResponse MapXMLToFullShowInfoResponse(XDocument xml);
        List<ShowListResult> MapXMLToShowListResponse(XDocument xml);
        List<FullSearchResult> MapXMLToFullSearchResults(XDocument xml);
        List<SearchResult> MapXMLToSearchResponse(XDocument xml);
        LastUpdatesResponse MapXMLToEpisodeLastUpdates(XDocument xml);
    }
}