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
        public void GetEpisodeListReturnsCorrectX()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.False(true);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectSeriesID()
        {
            var response = client.GetEpisodeList(seriesId);
            Assert.True(response.Series.ID == seriesId);
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
            Assert.True(response.Series.SeriesId == "74713");
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

    }
}
