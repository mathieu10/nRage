using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using nRage.Contract.TheTVDB;

namespace nRage.Clients
{
    public class TheTVDBResponseMapper : ITvdbResponseMapper
    {
        private List<string> ConvertPipedStringToList(string input)
        {
            return input.Split('|').Where(x => x.Length > 0).ToList();
        }

        public MirrorsResponse MapXMLToMirrors(XDocument xml)
        {
            return new MirrorsResponse
                {
                    Mirrors = xml.Descendants("Mirror").Select(x => new Mirror
                        {
                            ID = (int)x.Element("id"),
                            MirrorPath = (string)x.Element("mirrorpath"),
                            TypeMask = (byte)(int)x.Element("typemask"),
                        }).ToList(),
                };
        }

        public ServerTimeResponse MapXMLToServerTime(XDocument xml)
        {
            return new ServerTimeResponse
                {
                    Time = xml.Descendants("Time").Single().Value,
                };
        }

        public GetUpdatesResponse MapXMLToUpdates(XDocument xml)
        {
            return new GetUpdatesResponse
                {
                    Time = (string)xml.Descendants("Time").Single(),
                    Series = xml.Descendants("Series").Select(x => x.Value).ToList(),
                };
        }

        public SeriesInfoResponse MapXMLToSeriesInfo(XDocument xml)
        {
            return xml.Descendants("Series").Select(x => new SeriesInfoResponse
                {
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

        public EpisodeListResponse MapXMLToEpisodeList(XDocument xml)
        {
            return new EpisodeListResponse
            {
                Series = xml.Descendants("Series").Select(x => new SeriesInfoResponse
                {
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
                }).Single(),
                Episodes = xml.Descendants("Episode").Select(x => new EpisodeListResponseEpisode{

                }).ToList(),
            };            
        }

        public GetSeriesResponse MapXMLToGetSeries(XDocument xml) { throw new NotImplementedException(); }        

        public GetSeriesByIdResponse MapXMLToGetSeriesById(XDocument xml) { throw new NotImplementedException(); }
    }
}