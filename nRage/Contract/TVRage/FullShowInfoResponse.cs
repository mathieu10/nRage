using System.Collections.Generic;

namespace nRage.Contract.TVRage
{
    public class FullShowInfoResponse
    {
        public string Name{get;set;}
        public string TotalSeasons{get;set;}
        public int ShowID{get;set;}
        public string ShowLink{get;set;}
        public string Started{get;set;}
        public string Ended{get;set;}
        public string Image{get;set;}
        public string OriginCountry{get;set;}
        public string Status{get;set;}
        public string Classification{get;set;}
        public List<string> Genres{get;set;}
        public string RunTime{get;set;}
        public string Network{get;set;} //TODO: country of network
        public string AirTime{get;set;}
        public string AirDay{get;set;}
        public string TimeZone{get;set;}
        public List<EpisodeListResultSeason> Seasons {get;set;}
    }

}