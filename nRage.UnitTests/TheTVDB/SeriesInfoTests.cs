using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit.TheTVDB
{
    public class SeriesInfoTests : TestBase
    {        
        public SeriesInfoTests() : base(){}

        private const int seriesId = 81189;
        private const int invalidSeriesId = 1;
          
        [Fact]
        public void CanGetSeriesInfo()
        { 
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetSeriesInfoThrowsIfInvalidSeriesId()
        {
            Assert.Throws<ShowNotFoundException>(() =>
                client.GetSeriesInfo(invalidSeriesId)
            );
        }

        [Fact]
        public void GetSeriesInfoCallsCorrectURL()
        { 
            client.GetSeriesInfo(1);
            Assert.True(MockRetriever.GetLastURLCalled() == TheTVDBMockRetriever.SERIESINFO_81189);
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectSeriesID()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.ID == seriesId);
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectActors()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.Actors.Count == 11);
            Assert.True(response.Actors.First() == "Bryan Cranston");
            Assert.True(response.Actors.Last() == "Bob Odenkirk");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectAiredDayOfWeek()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.AirsDayOfWeek == "Sunday");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectAiredTime()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.AirsTime == "10:00 PM");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectContentRating()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.ContentRating=="TV-MA");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectFirstAiredDate()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.FirstAired=="2008-01-20");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectGenres()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.Genre.Count == 1);
            Assert.True(response.Genre.First() == "Drama");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectImdbId()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.ImdbId == "tt0903747");
        }
        
        [Fact]
        public void GetSeriesInfoReturnsCorrectLanguage()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.Language=="en");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectNetwork()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.Network == "AMC");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectNetworkId()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.NetworkId == "");
        }
        
        [Fact]
        public void GetSeriesInfoReturnsCorrectOverview()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.Overview == "Walter White, a struggling high school chemistry teacher is diagnosed with advanced lung cancer. He turns to a life of crime, producing and selling methamphetamine accompanied by a former student, Jesse Pinkman with the aim of securing his family's financial future before he dies.");
        }
        
        [Fact]
        public void GetSeriesInfoReturnsCorrectRating()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.Rating == "9.3");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectRatingCount()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.RatingCount == "397");
        }
        
        [Fact]
        public void GetSeriesInfoReturnsCorrectRuntime()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.Runtime == "60");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectSeriesId()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.SeriesId == "74713");
        }
        
        [Fact]
        public void GetSeriesInfoReturnsCorrectSeriesName()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.SeriesName == "Breaking Bad");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectStatus()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.Status == "Continuing");
        }
        
        [Fact]
        public void GetSeriesInfoReturnsCorrectAdded()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.Added == "");
        }
        
        [Fact]
        public void GetSeriesInfoReturnsCorrectAddedBy()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.AddedBy == "");
        }
        
        [Fact]
        public void GetSeriesInfoReturnsCorrectBanner()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.Banner == @"graphical/81189-g13.jpg");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectFanart()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.FanArt == @"fanart/original/81189-38.jpg");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectLastUpdated()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.LastUpdated == "1355787349");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectPoster()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.Poster == @"posters/81189-2.jpg");
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectZap2itId()
        {
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response.Zap2ItId == "SH01009396");
        }

    }
}
