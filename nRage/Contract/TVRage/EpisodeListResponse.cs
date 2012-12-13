using System.Collections.Generic;

namespace nRage.Contract.TVRage
{
    public class EpisodeListResponse
    {
        public string Name{get;set;}
        public string TotalSeasons{get;set;}    
    
        public List<EpisodeListResultSeason> Seasons {get;set;}        
        public List<EpisodeListResultEpisode> Specials {get;set;}        
    }    
}