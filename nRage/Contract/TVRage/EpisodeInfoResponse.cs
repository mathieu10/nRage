using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace nRage.Contract.Tvrage
{
    public class EpisodeInfoResponse
    {        
        public string Name{get;set;}
        public string Link{get;set;}
        public string Started{get;set;}
        public string Ended{get;set;}
        public string Country{get;set;}
        public string Status{get;set;}
        public string Classification{get;set;}
        public List<string> Genres{get;set;}
        public string AirTime{get;set;}
        public string RunTime{get;set;}       
        public EpisodeResult Episode {get;set;}

        [NotMapped, Obsolete]
        public string LatestEpisodeNumber{get;set;}
        [NotMapped, Obsolete]
        public string LatestEpisodeTitle{get;set;}
        [NotMapped, Obsolete]
        public string LatestEpisodeAirDate{get;set;}
            
    }
}