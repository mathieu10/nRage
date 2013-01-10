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
using nRage.Contract.TheTVDB;

namespace nRage.Clients {

    public class TheTVDBClient : ClientBase
    {
        public TheTVDBClient(IRetriever retriever) : base(retriever) { }

        #region URL generation                        
        public override string ApiRoot { get { return @"http://www.thetvdb.com/api"; } }
        private const string API_KEY = @"2A7162D6C1E477B0";

        private string GetURLForMirrors() {
            return GetURL(@"{0}/mirrors.xml", API_KEY); }
        private string GetURLForServerTime() {
            return GetURL(@"Updates.php?type=none"); }
        private string GetURLForSearch(string query) {
            return GetURL(@"GetSeries.php?seriesname={0}",query); }
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
            return MapXMLToMirrors(response);
        }

        public ServerTimeResponse GetServerTime(){
            var response = GetXML(GetURLForServerTime());
            return MapXMLToServerTime(response);
        }        

        public SearchResponse Search(string query){
            //TODO: format/clean input (eg ' ' to '+')            
            var response = GetXML(GetURLForSearch(query));
            return MapXMLToSearch(response);
        }

        public SeriesInfoResponse GetSeriesInfo(int seriesId){   
            // http://www.thetvdb.com/api/2A7162D6C1E477B0/series/81189/all/en.xml
            var response = GetXML(GetURLForSeriesInfo(seriesId));
            return MapXMLToSeriesInfo(response);
        }

        public EpisodeListResponse GetEpisodeList(int seriesId){   
            // http://www.thetvdb.com/api/2A7162D6C1E477B0/series/81189/all/en.xml
            var response = GetXML(GetURLForEpisodeList(seriesId));
            return MapXMLToEpisodeList(response);
        }

        public GetUpdatesResponse GetUpdates(int updatedSince)
        {
            //TODO: Validate input
            var dateTime = Helper.ToDateTime(updatedSince);

            var response = GetXML(GetURLForUpdates(updatedSince));
            return MapXMLToUpdates(response);
        }
        #endregion

        #region OXM (Object-XML Mapper) - because the software world needs more acronyms
         private MirrorsResponse MapXMLToMirrors(XDocument xml) {
            return new MirrorsResponse {
                Mirrors = xml.Descendants("Mirror").Select(x => new Mirror{
                    ID = (int)x.Element("id"),
                    MirrorPath = (string)x.Element("mirrorpath"),
                    TypeMask = (byte)(int)x.Element("typemask"),
                }).ToList(),
            };
        }

        private ServerTimeResponse MapXMLToServerTime(XDocument xml) { 
            return new ServerTimeResponse{
                Time = xml.Descendants("Time").Single().Value,
            };
        }

        private SearchResponse MapXMLToSearch(XDocument response) { throw new NotImplementedException(); }        
        private SeriesInfoResponse MapXMLToSeriesInfo(XDocument response) { throw new NotImplementedException(); }
        private EpisodeListResponse MapXMLToEpisodeList(XDocument response) { throw new NotImplementedException(); }
        private GetUpdatesResponse MapXMLToUpdates(XDocument response) { 
            return new GetUpdatesResponse{
                   
            };
        }
        #endregion                 
    }    
}