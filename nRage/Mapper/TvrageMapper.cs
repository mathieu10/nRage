using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using nRage.Contract.TVRage;

namespace nRage.Clients
{
    internal class TvrageMapper : ITvrageMapper
    {
        public TvrageMapper() { }

        public ShowInfoResponse MapXMLToShowInfoResponse(XDocument xml) {
            return xml.Descendants("Showinfo").Select(x => new ShowInfoResponse {
                ShowID = (int)x.Element("showid"),
                ShowName = (string)x.Element("showname"),
                ShowLink = (string)x.Element("showlink"),
                Seasons = (string)x.Element("seasons"),
                Started = (string)x.Element("started"),
                StartDate = (string)x.Element("startdate"),
                Ended = (string)x.Element("ended"),
                OriginCountry = (string)x.Element("origin_country"),
                Status = (string)x.Element("status"),
                Genres = x.Descendants("genre").Select(y => y.Value).ToList(),
                RunTime = (string)x.Element("runtime"),
                Network = (string)x.Element("network"),
                AirDay = (string)x.Element("airday"),
                AirTime = (string)x.Element("airtime"),
                TimeZone = (string)x.Element("timezone"),
                Classification = (string)x.Element("classification"),
            }).Single();
        }

        public EpisodeListResponse MapXMLToEpisodeListResponse(XDocument xml) {
            return xml.Descendants("Show").Select(x => new EpisodeListResponse {
                Name = (string)x.Element("name"),
                TotalSeasons = (string)x.Element("totalseasons"),
                Seasons = x.Descendants("EpisodeListResultSeason").Select(y=>new EpisodeListResultSeason{
                    Number = y.Attribute("no").Value.ToString(),
                    Episodes = y.Descendants("episode").Select(z=>new EpisodeListResultEpisode{
                        EpNum = (string)z.Element("epnum"),
                        SeasonNum = (string)z.Element("seasonnum"),
                        Link = (string)z.Element("link"),
                        AirDate = (string)z.Element("airdate"),
                        Title = (string)z.Element("title"),
                        ProdNum = (string)z.Element("prodnum"), 
                    }).ToList(),
                }).ToList(),
                                 
            }).Single();
        }

        public EpisodeInfoResponse MapXMLToEpisodeInfoResponse(XDocument xml) {
            return xml.Descendants("show").Select(x => new EpisodeInfoResponse {
                Name = (string)x.Element("name"),
                Link = (string)x.Element("link"),
                Started = (string)x.Element("started"),
                Ended = (string)x.Element("ended"),
                Country = (string)x.Element("country"),
                Status = (string)x.Element("status"),
                Classification = (string)x.Element("classification"),
                Genres = x.Descendants("genre").Select(y=>y.Value).ToList(),
                AirTime = (string)x.Element("airtime"),
                RunTime = (string)x.Element("runtime"),
                Episode = x.Descendants("episode").Select(y=>new EpisodeResult{
                    AirDate = (string)y.Element("airdate"),
                    Title = (string)y.Element("title"),
                    Number = (string)y.Element("number"),
                    URL = (string)y.Element("url"),
                }).SingleOrDefault(),
            }).Single();
        }

        public FullShowInfoResponse MapXMLToFullShowInfoResponse(XDocument xml) {
            return xml.Descendants("Show").Select(x => new FullShowInfoResponse {
                ShowID = (int)x.Element("showid"),
                Name = (string)x.Element("name"),
                ShowLink = (string)x.Element("showlink"),
                TotalSeasons = (string)x.Element("totalseasons"),
                Started = (string)x.Element("started"),
                Ended = (string)x.Element("ended"),
                Image = (string)x.Element("image"),
                OriginCountry = (string)x.Element("origin_country"),
                Status = (string)x.Element("status"),
                Genres = x.Descendants("genre").Select(y => y.Value).ToList(),
                RunTime = (string)x.Element("runtime"),
                Network = (string)x.Element("network"),
                AirDay = (string)x.Element("airday"),
                AirTime = (string)x.Element("airtime"),
                TimeZone = (string)x.Element("timezone"),
                Classification = (string)x.Element("classification"),
                Seasons = x.Descendants("EpisodeListResultSeason").Select(y=>new EpisodeListResultSeason{
                    Number = y.Attribute("no").Value.ToString(),
                    Episodes = y.Descendants("episode").Select(z=>new EpisodeListResultEpisode{
                        EpNum = (string)z.Element("epnum"),
                        SeasonNum = (string)z.Element("seasonnum"),
                        Link = (string)z.Element("link"),
                        AirDate = (string)z.Element("airdate"),
                        Title = (string)z.Element("title"),
                        ProdNum = (string)z.Element("prodnum"), 
                    }).ToList(),
                }).ToList(),
            }).Single();
        }

        public List<ShowListResult> MapXMLToShowListResponse(XDocument xml) {
            return xml.Descendants("show").Select(x => new ShowListResult {
                ID = (int)x.Element("id"),
                Name = (string)x.Element("name"),
                Country = (string)x.Element("country"),
                Status = (string)x.Element("status"),
            }).ToList();
        }

        public List<FullSearchResult> MapXMLToFullSearchResults(XDocument xml) {
            return xml.Descendants("show").Select(x => new FullSearchResult {
                ShowID = (int)x.Element("showid"),
                Name = (string)x.Element("name"),
                Link = (string)x.Element("link"),
                Country = (string)x.Element("country"),
                Started = (string)x.Element("started"),
                Ended = (string)x.Element("ended"),
                Seasons = (string)x.Element("seasons"),
                Status = (string)x.Element("status"),
                Classification = (string)x.Element("classification"),
                Genres = x.Descendants("genre").Select(y => y.Value).ToList(),
                RunTime = (string)x.Element("runtime"),
                AirTime = (string)x.Element("airtime"),
                Network = (string)x.Element("network"),
                AirDay = (string)x.Element("airday"),
                AKAs = x.Descendants("aka").Select(y => new AKA {
                    Country = (string)y.Attribute("country"),
                    Name = y.Value,
                }).ToList(),
            }).ToList();
        }

        public List<SearchResult> MapXMLToSearchResponse(XDocument xml) {
            return xml.Descendants("show").Select(x => new SearchResult {
                ShowID = (int)x.Element("showid"),
                Name = (string)x.Element("name"),
                Link = (string)x.Element("link"),
                Country = (string)x.Element("country"),
                Started = (string)x.Element("started"),
                Ended = (string)x.Element("ended"),
                Seasons = (string)x.Element("seasons"),
                Status = (string)x.Element("status"),
                Classification = (string)x.Element("classification"),
                Genres = x.Descendants("genre").Select(y => y.Value).ToList(),
            }).ToList();
        }

        public LastUpdatesResponse MapXMLToEpisodeLastUpdates(XDocument xml) { 
            return new LastUpdatesResponse{
                Timestamp = (string)xml.Element("updates").Attribute("at"),
                UpdatesCount = (string)xml.Element("updates").Attribute("found"),
                Sorting = (string)xml.Element("updates").Attribute("sorting"),
                ShowingPeriod = (string)xml.Element("updates").Attribute("showing"),

                Shows = xml.Descendants("show").Select(x=>new LastUpdatesShowResult{
                    ShowID = (int)x.Element("id"),
                    Last = (string)x.Element("last"),
                    LatestEpisode = (string)x.Element("lastepisode"),
                }).ToList(),
            };

        }
    }
}