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
            return GetURL(@"{0}/series/{1}/all/en.xml", API_KEY, seriesId); }
        private string GetURLForUpdates(string query) {
            return GetURL(@"Updates.php?type=all&time=<previoustime>. "); }
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

        public object GetSeriesInfo(int seriesId){
            // http://www.thetvdb.com/api/api/2A7162D6C1E477B0/series/81189/all/en.xml
            throw new NotImplementedException();
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
        #endregion                 
    }    
}