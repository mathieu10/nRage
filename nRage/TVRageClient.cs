using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using nRage.Contract.TVRage;

namespace nRage {

    public class TVRageClient {
        private IRetriever Retriever {
            get;
            set;
        }

        /// <summary>
        /// .ctor
        /// </summary>
        public TVRageClient(IRetriever retriever) {
            this.Retriever = retriever;
        }

        #region URL generation
        protected string FormatURLParam(string param) {
            return new string(param.Where(c => char.IsLetterOrDigit(c)).ToArray());
        }

        protected string GetURLForSearch(string title) {
            return String.Format(@"http://services.tvrage.com/feeds/search.php?show={0}", FormatURLParam(title));
        }
        protected string GetURLForFullSearch(string title) {
            return String.Format(@"http://services.tvrage.com/feeds/full_search.php?show={0}", FormatURLParam(title));
        }
        protected string GetURLForShowInfo(int showID) {
            return String.Format(@"http://services.tvrage.com/feeds/showinfo.php?sid={0}", showID);
        }
        protected string GetURLForEpisodeList(int showID) {
            return String.Format(@"http://services.tvrage.com/feeds/episode_list.php?sid={0}", showID);
        }
        protected string GetURLForEpisoddeInfo(int showID, string episodeLabel) {
            return String.Format(@"http://services.tvrage.com/feeds/episodeinfo.php?sid={0}&ep={1}", showID, FormatURLParam(episodeLabel));
        }
        protected string GetURLForFullShowInfo(int showID) {
            return String.Format(@"http://services.tvrage.com/feeds/full_show_info.php?sid={0}", showID);
        }
        protected string GetURLForShowList() {
            return @"http://services.tvrage.com/feeds/show_list.php";
        }
        #endregion

        #region Public methods
        public SearchResponse SearchByTitle(string title) {
            var result = new SearchResponse() {
                Results = new List<SearchResult>()
            };

            var response = XDocument.Load(Retriever.Get(GetURLForSearch(title)));
            if (response.Root == null || response.Root.Value == "0")
                return result;

            result.Results = MapXMLToSearchResponse(response);
            return result;
        }

        public FullSearchResponse FullSearchByTitle(string title) {
            var result = new FullSearchResponse() {
                Results = new List<FullSearchResult>()
            };

            var response = XDocument.Load(Retriever.Get(GetURLForFullSearch(title)));
            if (response.Root == null || response.Root.Value == "0")
                return result;

            result.Results = MapXMLToFullSearchResults(response);
            return result;
        }

        public ShowInfoResponse GetShowInfo(int showId) {
            var response = XDocument.Load(Retriever.Get(GetURLForShowInfo(showId)));
            
            if (response.Root == null || response.Root.Value == "")
                throw new ShowNotFoundException();

            return MapXMLToShowInfoResponse(response);
        }

        public EpisodeListResponse GetEpisodeList(int showId) {
            var response = XDocument.Load(Retriever.Get(GetURLForEpisodeList(showId)));
            
            return MapXMLToEpisodeListResponse(response);
        }

        public EpisodeInfoResponse GetEpisodeInfo(int showID, int season, int episode) {
            var episodeLabel = string.Format("{0}x{1:D2}", season, episode);
            return GetEpisodeInfo(showID, episodeLabel);
        }

        public EpisodeInfoResponse GetEpisodeInfo(int showID, string episodeLabel) {
            var rawResponse = Retriever.Get(GetURLForEpisoddeInfo(showID, episodeLabel));            
            if(rawResponse.Length < 40){                                    
                    var sr = new StreamReader(rawResponse);
                    if(sr.ReadLine().Substring(0,15)=="No Show Results") throw new ShowNotFoundException();   
                    rawResponse.Position = 0;
            }            
            var response = XDocument.Load(rawResponse);

            return MapXMLToEpisodeInfoResponse(response);
        }

        public FullShowInfoResponse GetFullShowInfo(int showId) {
            var response = XDocument.Load(Retriever.Get(GetURLForFullShowInfo(showId)));

            return MapXMLToFullShowInfoResponse(response);
        }

        public ShowListResponse GetShowList() {
            var response = XDocument.Load(Retriever.Get(GetURLForShowList()));
            var result = new ShowListResponse();
            result.Results = MapXMLToShowListResponse(response);
            return result;
        }
        #endregion

        #region OXM (Object-XML Mapper) - because the software world needs more acronyms
        private ShowInfoResponse MapXMLToShowInfoResponse(XDocument xml) {
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

        private EpisodeListResponse MapXMLToEpisodeListResponse(XDocument xml) {
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

        private EpisodeInfoResponse MapXMLToEpisodeInfoResponse(XDocument xml) {
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

        private FullShowInfoResponse MapXMLToFullShowInfoResponse(XDocument xml) {
            return xml.Descendants("?").Select(x => new FullShowInfoResponse {
            
            }).Single();
        }

        private List<ShowListResult> MapXMLToShowListResponse(XDocument xml) {
            return xml.Descendants("show").Select(x => new ShowListResult {
                ID = (int)x.Element("id"),
                Name = (string)x.Element("name"),
                Country = (string)x.Element("country"),
                Status = (string)x.Element("status"),
            }).ToList();
        }

        private List<FullSearchResult> MapXMLToFullSearchResults(XDocument xml) {
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

        private List<SearchResult> MapXMLToSearchResponse(XDocument xml) {
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
        #endregion

    }

}