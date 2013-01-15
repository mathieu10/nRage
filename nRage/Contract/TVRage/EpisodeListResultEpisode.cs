using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace nRage.Contract.Tvrage
{
    public class EpisodeListResultEpisode
    {
        public string EpNum{get;set;}
        public string SeasonNum{get;set;}        
        public string AirDate{get;set;}
        public string Link{get;set;}
        public string Title{get;set;}

        [Obsolete,NotMapped]
        public string ProdNum{get;set;}
    }
}