using System.Collections.Generic;

namespace nRage.Contract.Tvdb
{
    public class SeriesInfoResponse
    {
        public int Id { get; set; }
        public List<string> Actors { get; set; }
        public string AirsDayOfWeek { get; set; }
        public string AirsTime { get; set; }
        public string ContentRating { get; set; }
        public string FirstAired { get; set; }
        public List<string> Genre { get; set; }
        public string ImdbId { get; set; }
        public string Language { get; set; }
        public string Network { get; set; }
        public string NetworkId { get; set; }
        public string Overview { get; set; }
        public string Rating { get; set; }
        public string RatingCount { get; set; }
        public string Runtime { get; set; }
        public string SeriesId { get; set; }
        public string SeriesName { get; set; }
        public string Status { get; set; }
        public string Added { get; set; }
        public string AddedBy { get; set; }
        public string Banner { get; set; }
        public string FanArt { get; set; }
        public string LastUpdated { get; set; }
        public string Poster { get; set; }
        public string Zap2ItId { get; set; }
    }
}