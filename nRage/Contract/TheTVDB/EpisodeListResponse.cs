using System.Collections.Generic;

namespace nRage.Contract.TheTVDB
{
    public class EpisodeListResponse
    {
        public SeriesInfoResponse Series { get; set; }
        public List<EpisodeListResponseEpisode> Episodes { get; set; }
    }

    public class EpisodeListResponseEpisode
    {
        public string Id { get;set; }
        public string CombinedEpisodeNumber{ get;set; }
        public string CombinedSeason { get;set; }
        public string DvdChapter{ get;set; }
        public string DvdDiscId{ get;set; }
        public string DvdEpisodeNumber{ get;set; }
        public string DvdSeason{ get;set; }
        public string Director{ get;set; }
        public string EpImgFlag{ get;set; }
        public string EpisodeName{ get;set; }
        public string EpisodeNumber{ get;set; }
        public string FirstAired { get;set; }
        public List<string> GuestStars { get;set; }
        public string ImdbId { get;set; }
        public string Langauge{ get;set; }
        public string Overview{ get;set; }
        public string ProductionCode{ get;set; }
        public string Rating{ get;set; }
        public string RatingCount{ get;set; }
        public string SeasonNumber{ get;set; }
        public string Writer{ get;set; }
        public string AbsoluteNumber{ get;set; }
        public string AirsAfterSeason{ get;set; }
        public string FileName{ get;set; }
        public string LastUpdated{ get;set; }
        public string SeasonId{ get;set; }
        public string SeriesId{ get;set; }    
    }
}