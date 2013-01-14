using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit.TheTVDB
{
    public class GetSeriesByIdTests : TestBase
    {      
        public GetSeriesByIdTests() : base(){}

        private const string seriesId = "tt0290978";
        private const string invalidSeriesId = "1";

        [Fact]
        public void CanGetSeriesById()
        { 
            var response = client.GetSeriesById(seriesId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetSeriesByIdCallsCorrectURL()
        { 
            client.GetSeriesById(seriesId);
            Assert.True(MockRetriever.GetLastURLCalled() == TheTVDBMockRetriever.GETSERIESBYID_TT029097);
        }

        [Fact]
        public void GetSeriesByIdThrowsWhenInvalidSeriesId()
        { 
            Assert.Throws<ShowNotFoundException>(()=>
                client.GetSeriesById(invalidSeriesId)
            );
        }

        [Fact]
        public void GetSeriesReturnsExactlyOneResult()
        {
            var response = client.GetSeriesById(seriesId);
            Assert.True(response.Series != null);
            Assert.True(response.Series.Count == 1);
        }

        [Fact]
        public void GetSeriesReturnsCorrectId()
        {
            var response = client.GetSeriesById(seriesId);
            Assert.True(response.Series[0].Id == "78107");
        }

        [Fact]
        public void GetSeriesReturnsCorrectSeriesId()
        {
            var response = client.GetSeriesById(seriesId);
            Assert.True(response.Series[0].SeriesId == "78107");
        }

        [Fact]
        public void GetSeriesReturnsCorrectLanguage()
        {
            var response = client.GetSeriesById(seriesId);
            Assert.True(response.Series[0].Language == "en");
        }

        [Fact]
        public void GetSeriesReturnsCorrectSeriesName()
        {
            var response = client.GetSeriesById(seriesId);
            Assert.True(response.Series[0].SeriesName == "The Office (UK)");
        }

        [Fact]
        public void GetSeriesReturnsCorrectBanner()
        {
            var response = client.GetSeriesById(seriesId);
            Assert.True(response.Series[0].Banner == "graphical/78107-g10.jpg");
        }

        [Fact]
        public void GetSeriesReturnsCorrectOverview()
        {
            var response = client.GetSeriesById(seriesId);
            Assert.True(response.Series[0].Overview == "A mockumentary about life in a mid-sized suboffice paper merchants in a bleak British industrial town, where manager David Brent thinks he's the coolest, funniest, and most popular boss ever. He isn't. That doesn't stop him from embarrassing himself in front of the cameras on a regular basis, whether from his political sermonizing, his stand-up 'comedy', or his incredibly unique dancing. Meanwhile, long-suffering Tim longs after Dawn the engaged receptionist and keeps himself sane by playing childish practical jokes on his insufferable, army-obsessed deskmate Gareth. Will the Slough office be closed? Will the BBC give David a game show? Will Tim and Dawn end up with each other? And more importantly, will Gareth realize what a hopeless prat he is?");
        }

        [Fact]
        public void GetSeriesReturnsCorrectFirstAired()
        {
            var response = client.GetSeriesById(seriesId);
            Assert.True(response.Series[0].FirstAired == "2001-07-01");
        }

        [Fact]
        public void GetSeriesReturnsCorrectImdbId()
        {
            var response = client.GetSeriesById(seriesId);
            Assert.True(response.Series[0].ImdbId == "tt0290978");
        }

        [Fact]
        public void GetSeriesReturnsCorrectZap2ItId()
        {
            var response = client.GetSeriesById(seriesId);
            Assert.True(response.Series[0].Zap2ItId == null);
        }

    }
}
