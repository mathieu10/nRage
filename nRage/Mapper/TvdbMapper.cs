﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using nRage.Client;
using nRage.Contract.Tvdb;
using nRage.Interface;

namespace nRage.Mapper
{
    internal class TvdbMapper : ITvdbResponseMapper
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
                            Id = (int)x.Element("id"),
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
                    Id = (int)x.Element("id"),
                    Actors = ConvertPipedStringToList((string)x.Element("Actors")),
                    AirsDayOfWeek = (string)x.Element("Airs_DayOfWeek"),
                    AirsTime = (string)x.Element("Airs_Time"),
                    ContentRating = (string)x.Element("ContentRating"),
                    FirstAired = (string)x.Element("FirstAired"),
                    Genre = ConvertPipedStringToList((string)x.Element("Genre")),
                    ImdbId = (string)x.Element("IMDB_Id"),
                    Language = (string)x.Element("Language"),
                    Network = (string)x.Element("Network"),
                    NetworkId = (string)x.Element("NetworkId"),
                    Overview = (string)x.Element("Overview"),
                    Rating = (string)x.Element("Rating"),
                    RatingCount = (string)x.Element("RatingCount"),
                    Runtime = (string)x.Element("Runtime"),
                    SeriesId = (string)x.Element("SeriesId"),
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
                    Id = (int)x.Element("id"),
                    Actors = ConvertPipedStringToList((string)x.Element("Actors")),
                    AirsDayOfWeek = (string)x.Element("Airs_DayOfWeek"),
                    AirsTime = (string)x.Element("Airs_Time"),
                    ContentRating = (string)x.Element("ContentRating"),
                    FirstAired = (string)x.Element("FirstAired"),
                    Genre = ConvertPipedStringToList((string)x.Element("Genre")),
                    ImdbId = (string)x.Element("IMDB_Id"),
                    Language = (string)x.Element("Language"),
                    Network = (string)x.Element("Network"),
                    NetworkId = (string)x.Element("NetworkId"),
                    Overview = (string)x.Element("Overview"),
                    Rating = (string)x.Element("Rating"),
                    RatingCount = (string)x.Element("RatingCount"),
                    Runtime = (string)x.Element("Runtime"),
                    SeriesId = (string)x.Element("SeriesId"),
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
                    AbsoluteNumber = (string)x.Element("absolute_number"),
                    FirstAired = (string)x.Element("FirstAired"),
                    LastUpdated = (string)x.Element("lastupdated"),
                    Overview = (string)x.Element("Overview"),
                    Rating = (string)x.Element("Rating"),
                    SeriesId = (string)x.Element("seriesid"),
                    ImdbId = (string)x.Element("IMDB_Id"),
                    RatingCount = (string)x.Element("RatingCount"),
                    AirsAfterSeason = (string)x.Element("airsafter_season"),
                    AirsBeforeEpisode = (string)x.Element("airsbefore_episode"),
                    AirsBeforeSeason = (string)x.Element("airsbefore_season"),
                    CombinedEpisodeNumber = (string)x.Element("Combined_episodenumber"),
                    CombinedSeason = (string)x.Element("Combined_season"),
                    Director = (string)x.Element("Director"),
                    DvdChapter = (string)x.Element("DVD_chapter"),
                    DvdDiscId = (string)x.Element("DVD_discid"),
                    DvdEpisodeNumber = (string)x.Element("DVD_episodenumber"),
                    DvdSeason = (string)x.Element("DVD_season"),
                    EpImgFlag = (string)x.Element("EpImgFlag"),
                    EpisodeName = (string)x.Element("EpisodeName"),
                    EpisodeNumber = (string)x.Element("EpisodeNumber"),
                    FileName = (string)x.Element("filename"),
                    Id = (string)x.Element("id"),
                    Langauge = (string)x.Element("Language"),
                    ProductionCode = (string)x.Element("ProductionCode"),
                    SeasonId = (string)x.Element("seasonid"),
                    SeasonNumber = (string)x.Element("SeasonNumber"),
                    Writer = (string)x.Element("Writer"),
                    GuestStars = ConvertPipedStringToList((string)x.Element("GuestStars")),
                }).ToList(),
            };            
        }

        public GetSeriesResponse MapXMLToGetSeries(XDocument xml) {
            return new GetSeriesResponse {
                Series = xml.Descendants("Series").Select(x=> new GetSeriesResult{
                       Id = (string)x.Element("id"),
                       SeriesId = (string)x.Element("seriesid"),
                       SeriesName = (string)x.Element("SeriesName"),
                       Language = (string)x.Element("language"),
                       Banner = (string)x.Element("banner"),
                       Overview = (string)x.Element("Overview"),
                       FirstAired = (string)x.Element("FirstAired"),
                       ImdbId = (string)x.Element("IMDB_Id"),
                       Zap2ItId = (string)x.Element("zap2it_id"),
                }).ToList(),
            };
        }        

        public GetSeriesByIdResponse MapXMLToGetSeriesById(XDocument xml) {
            return new GetSeriesByIdResponse()
            {
                Series = xml.Descendants("Series").Select(x => new GetSeriesByIdResult
                {
                    Id = (string)x.Element("id"),
                    SeriesId = (string)x.Element("seriesid"),
                    SeriesName = (string)x.Element("SeriesName"),
                    Language = (string)x.Element("language"),
                    Banner = (string)x.Element("banner"),
                    Overview = (string)x.Element("Overview"),
                    FirstAired = (string)x.Element("FirstAired"),
                    ImdbId = (string)x.Element("IMDB_Id"),
                    Zap2ItId = (string)x.Element("zap2it_id"),
                }).ToList(),
            };
        }
    }
}