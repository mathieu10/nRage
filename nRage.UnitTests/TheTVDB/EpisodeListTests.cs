using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit.TheTVDB
{
    public class EpisodeListTests : TestBase
    {      
        public EpisodeListTests() : base(){}

        private const int seriesId = 81189;
        private const int invalidSeriesId = 1;

        [Fact]
        public void CanGetEpisodeList()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListThrowsIfInvalidSeriesId()
        {
            Assert.Throws<ShowNotFoundException>(() =>
                client.GetEpisodeList(invalidSeriesId)
            );
        }

        [Fact]
        public void GetEpisodeListCallsCorrectURL()
        { 
            client.GetEpisodeList(seriesId);
            Assert.True(MockRetriever.GetLastURLCalled() == TheTVDBMockRetriever.EPISODELIST_81189);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeCount()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.NotNull(response.Episodes);
            Assert.True(response.Episodes.Count == 2);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeId()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.Id == "3859781");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeCombinedEpisodeNumber()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.CombinedEpisodeNumber == "1");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeCombinedSeason()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.CombinedSeason == "0");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeDvdChapter()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.DvdChapter == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeDvdDiscId()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.DvdDiscId == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeDvdEpisodeNumber()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.DvdEpisodeNumber == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeDvdSeason()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.DvdSeason == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeDirector()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.Director == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeEpImgFlag()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.EpImgFlag == "2");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeEpisodeName()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.EpisodeName == "Good Cop Bad Cop");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeEpisodeNumber()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.EpisodeNumber == "1");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeFirstAired()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.FirstAired == "2009-02-17");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeGuestStars()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.GuestStars.Count == 0);
        }
        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeImdbId()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.ImdbId == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeLanguage()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.Langauge == "en");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeOverview()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.Overview == "Hank and Marie try to spice up their relationship on Valentine's Day.");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeProductionCode()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.ProductionCode == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeRating()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.Rating == "6.0");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeRatingCount()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.RatingCount == "1");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeSeasonNumber()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.SeasonNumber == "0");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeWriter()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.Writer == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeAbsoluteNumber()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.AbsoluteNumber == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeAirsAfterSeason()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.AirsAfterSeason == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeAirsBeforeEpisode()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.AirsBeforeEpisode == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeAirsBeforeSeason()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.AirsBeforeSeason == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeFileName()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.FileName == @"episodes/81189/3859781.jpg");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeLastUpdated()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.LastUpdated == "1301948371");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeSeasonId()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.SeasonId == "439371");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeSeriesId()
        {
            var response = client.GetEpisodeList(seriesId);
            var result = response.Episodes[0];
            Assert.True(result.SeriesId == "81189");
        }                

        #region Series info tests
        [Fact]
        public void GetEpisodeListReturnsCorrectId()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Id == seriesId);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectActors()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Actors.Count == 11);
            Assert.True(response.Series.Actors.First() == "Bryan Cranston");
            Assert.True(response.Series.Actors.Last() == "Bob Odenkirk");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectAiredDayOfWeek()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.AirsDayOfWeek == "Sunday");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectAiredTime()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.AirsTime == "10:00 PM");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectContentRating()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.ContentRating == "TV-MA");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectFirstAiredDate()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.FirstAired == "2008-01-20");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectGenres()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Genre.Count == 1);
            Assert.True(response.Series.Genre.First() == "Drama");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectImdbId()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.ImdbId == "tt0903747");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectLanguage()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Language == "en");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectNetwork()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Network == "AMC");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectNetworkId()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.NetworkId == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectOverview()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Overview == "Walter White, a struggling high school chemistry teacher is diagnosed with advanced lung cancer. He turns to a life of crime, producing and selling methamphetamine accompanied by a former student, Jesse Pinkman with the aim of securing his family's financial future before he dies.");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectRating()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Rating == "9.3");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectRatingCount()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.RatingCount == "397");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectRuntime()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Runtime == "60");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectSeriesId()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.SeriesId == seriesId.ToString());
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectSeriesName()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.SeriesName == "Breaking Bad");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectStatus()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Status == "Continuing");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectAdded()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Added == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectAddedBy()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.AddedBy == "");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectBanner()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Banner == @"graphical/81189-g13.jpg");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectFanart()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.FanArt == @"fanart/original/81189-38.jpg");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectLastUpdated()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.LastUpdated == "1355787349");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectPoster()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Poster == @"posters/81189-2.jpg");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectZap2itId()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.Zap2ItId == "SH01009396");
        }
        #endregion

    }
}
