using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using nRage.Contract.TheTVDB;

namespace nRage.Clients {

    public class TheTVDBClient : ClientBase
    {
        private ITvdbResponseMapper _mapper;

        public TheTVDBClient(IRetriever retriever) : base(retriever) { 
            _mapper = new TheTVDBResponseMapper();
        }

        #region URL generation
        public override string ApiRoot { get { return @"http://www.thetvdb.com/api"; } }
        private const string API_KEY = @"2A7162D6C1E477B0";

        private string GetURLForMirrors() {
            return GetURL(@"{0}/mirrors.xml", API_KEY); }
        private string GetURLForServerTime() {
            return GetURL(@"Updates.php?type=none"); }
        private string GetURLForGetSeries(string query) {
            return GetURL(@"GetSeries.php?seriesname={0}",query); }
        private string GetURLForGetSeriesById(string query) {
            return GetURL(@"GetSeriesByRemoteID.php?imdbid={0}", query); }
        private string GetURLForSeriesInfo(int seriesId) {
            return GetURL(@"{0}/series/{1}", API_KEY, seriesId); }
        private string GetURLForEpisodeList(int seriesId) {
            return GetURL(@"{0}/series/{1}/all", API_KEY, seriesId); }
        private string GetURLForUpdates(int updatedSince) {
            return GetURL(@"Updates.php?type=all&time={0}",updatedSince); }
        #endregion

        #region Public methods        
        public MirrorsResponse GetMirrors()
        {
            var response = GetXML(GetURLForMirrors());
            return _mapper.MapXMLToMirrors(response);
        }

        public ServerTimeResponse GetServerTime(){
            var response = GetXML(GetURLForServerTime());
            return _mapper.MapXMLToServerTime(response);
        }        

        /// <summary>
        /// Should more appropriately be called "SearchForSeries"
        /// </summary>
        public GetSeriesResponse GetSeries(string query){
            //TODO: format/clean input (eg ' ' to '+')            
            var response = GetXML(GetURLForGetSeries(query));
            return _mapper.MapXMLToGetSeries(response);
        }

        public GetSeriesByIdResponse GetSeriesById(string imdbId)
        {
            var response = GetXML(GetURLForGetSeriesById(imdbId));
            return _mapper.MapXMLToGetSeriesById(response);
        }

        public SeriesInfoResponse GetSeriesInfo(int seriesId){
            var rawResponse = Retriever.Get(GetURLForSeriesInfo(seriesId));
            ValidateResponse<ShowNotFoundException>(rawResponse);

            var response = XDocument.Load(rawResponse);
            return _mapper.MapXMLToSeriesInfo(response);
        }

        public EpisodeListResponse GetEpisodeList(int seriesId){
            var rawResponse = Retriever.Get(GetURLForSeriesInfo(seriesId));
            ValidateResponse<ShowNotFoundException>(rawResponse);

            var response = XDocument.Load(rawResponse);
            return _mapper.MapXMLToEpisodeList(response);
        }

        public GetUpdatesResponse GetUpdates(int updatedSince)
        {
            var dateTime = Helper.ToDateTime(updatedSince);

            var response = GetXML(GetURLForUpdates(updatedSince));
            return _mapper.MapXMLToUpdates(response);
        }
        #endregion
    
        private void ValidateResponse<T>(Stream rawResponse) where T : Exception, new()
        {            
            var sr = new StreamReader(rawResponse);
            if (sr.ReadLine().Substring(0,5)!="<?xml")
                throw new T();
            rawResponse.Position = 0;
        }    
    }
}