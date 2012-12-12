using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            
            if (response.Root == null || response.Root.Value == "0")
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
            var response = XDocument.Load(Retriever.Get(GetURLForEpisoddeInfo(showID, episodeLabel)));

            return MapXMLToEpisodeInfoResponse(response);
        }

        public FullShowInfoResponse GetFullShowInfo(int showId) {
            var response = XDocument.Load(Retriever.Get(GetURLForFullShowInfo(showId)));

            return MapXMLToFullShowInfoResponse(response);
        }

        public ShowListResponse GetShowList() {
            var response = XDocument.Load(Retriever.Get(GetURLForShowList()));

            return MapXMLToShowListResponse(response);
        }
        #endregion

        #region OXM (Object-XML Mapper) - because the software world needs more acronyms
        private ShowInfoResponse MapXMLToShowInfoResponse(XDocument xml) {
            return xml.Descendants("showinfo").Select(x => new ShowInfoResponse {
            
            }).Single();
        }

        private EpisodeListResponse MapXMLToEpisodeListResponse(XDocument xml) {
            return xml.Descendants("show").Select(x => new EpisodeListResponse {
            
            }).Single();
        }

        private EpisodeInfoResponse MapXMLToEpisodeInfoResponse(XDocument xml) {
            return xml.Descendants("show").Select(x => new EpisodeInfoResponse {
            
            }).Single();
        }

        private FullShowInfoResponse MapXMLToFullShowInfoResponse(XDocument xml) {
            return xml.Descendants("?").Select(x => new FullShowInfoResponse {
            
            }).Single();
        }

        private ShowListResponse MapXMLToShowListResponse(XDocument xml) {
            return xml.Descendants("?").Select(x => new ShowListResponse {
            
            }).Single();
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