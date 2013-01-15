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
using nRage.Contract.Tvrage;
using nRage.Mapper;

namespace nRage.Client {

    public class TvrageClient : ClientBase
    {
        private readonly TvrageMapper _mapper;
        public TvrageClient(IRetriever retriever) : base(retriever) { _mapper = new TvrageMapper(); }               

        #region URL generation
        public override string ApiRoot { get { return @"http://services.tvrage.com/feeds"; } }

        protected string FormatURLParam(string param) {
            return param;
            ////TODO: what about '+', spaces, formatted chars etc? Need to investigate
            //return new string(param.Where(c => char.IsLetterOrDigit(c)).ToArray());
        }

        protected string GetURLForSearch(string title) {
            return GetURL(@"search.php?show={0}", FormatURLParam(title)); }
        protected string GetURLForFullSearch(string title) {
            return GetURL(@"full_search.php?show={0}", FormatURLParam(title)); }
        protected string GetURLForShowInfo(int showID) {
            return GetURL(@"showinfo.php?sid={0}", showID); }
        protected string GetURLForEpisodeList(int showID) {
            return GetURL(@"episode_list.php?sid={0}", showID); }
        protected string GetURLForEpisoddeInfo(int showID, string episodeLabel) {
            return GetURL(@"episodeinfo.php?sid={0}&ep={1}", showID, FormatURLParam(episodeLabel)); }
        protected string GetURLForFullShowInfo(int showID) {
            return GetURL(@"full_show_info.php?sid={0}", showID); }
        protected string GetURLForShowList() {
            return GetURL(@"show_list.php"); }
        protected string GetURLForLastUpdates(int hours) {
            return GetURL(@"last_updates.php?hours={0}", hours); }
        #endregion

        #region Public methods
        public LastUpdatesResponse LastUpdates()
        { 
            return LastUpdates(0);
        }
        
        public LastUpdatesResponse LastUpdates(TimeSpan timeSpan)
        { 
            var hours = (int)timeSpan.TotalHours;
            return LastUpdates(hours);
        }

        public LastUpdatesResponse LastUpdates(int hours)
        { 
            var response = GetXML(GetURLForLastUpdates(hours));
            
            return _mapper.MapXMLToEpisodeLastUpdates(response);
        }        

        public SearchResponse SearchByTitle(string title) {
            var result = new SearchResponse() {
                Results = new List<SearchResult>()
            };

            var response = GetXML(GetURLForSearch(title));
            if (response.Root == null || response.Root.Value == "0")
                return result;

            result.Results = _mapper.MapXMLToSearchResponse(response);
            return result;
        }

        public FullSearchResponse FullSearchByTitle(string title) {
            var result = new FullSearchResponse() {
                Results = new List<FullSearchResult>()
            };

            var response = GetXML(GetURLForFullSearch(title));
            if (response.Root == null || response.Root.Value == "0")
                return result;

            result.Results = _mapper.MapXMLToFullSearchResults(response);
            return result;
        }

        public ShowInfoResponse GetShowInfo(int showId) {
            var response = GetXML(GetURLForShowInfo(showId));
            
            if (response.Root == null || response.Root.Value == "")
                throw new ShowNotFoundException();

            return _mapper.MapXMLToShowInfoResponse(response);
        }

        public EpisodeListResponse GetEpisodeList(int showId) {
            var response = GetXML(GetURLForEpisodeList(showId));
            
            return _mapper.MapXMLToEpisodeListResponse(response);
        }

        public EpisodeInfoResponse GetEpisodeInfo(int showID, int season, int episode) {
            var episodeLabel = string.Format("{0:D2}x{1:D2}", season, episode);
            return GetEpisodeInfo(showID, episodeLabel);
        }

        public EpisodeInfoResponse GetEpisodeInfo(int showID, string episodeLabel) {
            var rawResponse = Retriever.Get(GetURLForEpisoddeInfo(showID, episodeLabel));            
            ValidateResponse(rawResponse);    
        
            var response = XDocument.Load(rawResponse);
            return _mapper.MapXMLToEpisodeInfoResponse(response);
        }

        public FullShowInfoResponse GetFullShowInfo(int showId) {            
            var rawResponse = Retriever.Get(GetURLForFullShowInfo(showId));
            ValidateResponse(rawResponse);            

            var response = XDocument.Load(rawResponse);
            return _mapper.MapXMLToFullShowInfoResponse(response);
        }

        public ShowListResponse GetShowList() {
            var response = GetXML(GetURLForShowList());
            var result = new ShowListResponse();
            result.Results = _mapper.MapXMLToShowListResponse(response);
            return result;
        }
        #endregion   
        
        private void ValidateResponse(Stream rawResponse)
        {
            if (rawResponse.Length < 40)
            {
                var sr = new StreamReader(rawResponse);
                if (sr.ReadLine().Substring(0, 15) == "No Show Results") throw new ShowNotFoundException();                
            }
            rawResponse.Position = 0;
        }        
    }    
}