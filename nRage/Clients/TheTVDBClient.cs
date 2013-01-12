﻿using System;
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
            var response = GetXML(GetURLForSeriesInfo(seriesId));
            return MapXMLToSeriesInfo(response);
        }

        public EpisodeListResponse GetEpisodeList(int seriesId){
            var response = GetXML(GetURLForEpisodeList(seriesId));
            return MapXMLToEpisodeList(response);
        }

        public GetUpdatesResponse GetUpdates(int updatedSince)
        {
            var dateTime = Helper.ToDateTime(updatedSince);

            var response = GetXML(GetURLForUpdates(updatedSince));
            return MapXMLToUpdates(response);
        }
        #endregion

        #region OXM (Object-XML Mapper) - because the software world needs more acronyms

        private List<string> ConvertPipedStringToList(string input) {
            return input.Split('|').Where(x=>x.Length > 0).ToList();
        }

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

        private GetUpdatesResponse MapXMLToUpdates(XDocument xml)
        {
            return new GetUpdatesResponse
            {
                Time = (string)xml.Descendants("Time").Single(),
                Series = xml.Descendants("Series").Select(x => x.Value).ToList(),
            };
        }

        private SeriesInfoResponse MapXMLToSeriesInfo(XDocument xml)
        {
            return xml.Descendants("Series").Select(x => new SeriesInfoResponse {
                ID = (int)x.Element("id"),                
                Actors = ConvertPipedStringToList((string)x.Element("Actors")),
                AirsDayOfWeek = (string)x.Element("Airs_DayOfWeek"),
                AirsTime = (string)x.Element("Airs_Time"),
                ContentRating = (string)x.Element("ContentRating"),
                FirstAired = (string)x.Element("FirstAired"),
                Genre = ConvertPipedStringToList((string)x.Element("Genre")),
                ImdbId = (string)x.Element("IMDB_ID"),
                Language = (string)x.Element("Language"),
                Network = (string)x.Element("Network"),
                NetworkId = (string)x.Element("NetworkID"),
                Overview = (string)x.Element("Overview"),
                Rating = (string)x.Element("Rating"),
                RatingCount = (string)x.Element("RatingCount"),
                Runtime = (string)x.Element("Runtime"),
                SeriesId = (string)x.Element("SeriesID"),
                SeriesName = (string)x.Element("SeriesName"),
                Status = (string)x.Element("Status"),
                Added = (string)x.Element("added"),
                AddedBy = (string)x.Element("addedBy"),
                Banner = (string)x.Element("banner"),
                FanArt = (string)x.Element("fanart"),
                LastUpdated = (string)x.Element("lastupdated"),
                Poster = (string)x.Element("poster"),
                Zap2ItId = (string)x.Element("zap2it_id"),
            }).Single();            
        }

        private SearchResponse MapXMLToSearch(XDocument xml) { throw new NotImplementedException(); }        
        private EpisodeListResponse MapXMLToEpisodeList(XDocument xml) { throw new NotImplementedException(); }        
        #endregion                 
    }    
}