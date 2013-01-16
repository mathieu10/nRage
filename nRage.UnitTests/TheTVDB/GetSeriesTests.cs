using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit.TheTVDB
{
    public class GetSeriesTests : TestBase
    {      
        public GetSeriesTests() : base(){}

        private const string query = "the Office";
        private const string invalidQuery = "SROTIJSRTRH";
          
        [Fact]
        public void CanGetSeries()
        { 
            var response = client.GetSeries(query);
            Assert.True(response != null);
        }

        [Fact]
        public void GetSeriesCallsCorrectURL()
        { 
            client.GetSeries(query);
            Assert.True(MockRetriever.GetLastURLCalled() == TvdbMockRetriever.GETSERIES_THEOFFICE);
        }

        [Fact]
        public void GetSeriesReturnsCorrectSeriesList()
        {
            var response = client.GetSeries(query);
            Assert.True(response.Series != null);
            Assert.True(response.Series.Count == 3);
        }

        [Fact]
        public void GetSeriesReturnsCorrectId()
        {
            var response = client.GetSeries(query);
            Assert.True(response.Series[0].Id  == "73244");
        }

        [Fact]
        public void GetSeriesReturnsCorrectSeriesId()
        {
            var response = client.GetSeries(query);
            Assert.True(response.Series[0].SeriesId == "73244");
        }

        [Fact]
        public void GetSeriesReturnsCorrectLanguage()
        {
            var response = client.GetSeries(query);
            Assert.True(response.Series[0].Language == "en");
        }

        [Fact]
        public void GetSeriesReturnsCorrectSeriesName()
        {
            var response = client.GetSeries(query);
            Assert.True(response.Series[0].SeriesName == "The Office (US)");
        }

        [Fact]
        public void GetSeriesReturnsCorrectBanner()
        {
            var response = client.GetSeries(query);
            Assert.True(response.Series[0].Banner == "graphical/73244-g9.jpg");
        }

        [Fact]
        public void GetSeriesReturnsCorrectOverview()
        {
            var response = client.GetSeries(query);
            Assert.True(response.Series[0].Overview == "A fresh and funny mockumentary-style glimpse into the daily interactions of the eccentric workers at the Dunder Mifflin paper supply company. This fast-paced comedy parodies contemporary American water-cooler culture.");
        }

        [Fact]
        public void GetSeriesReturnsCorrectFirstAired()
        {
            var response = client.GetSeries(query);
            Assert.True(response.Series[0].FirstAired == "2005-03-24");
        }

        [Fact]
        public void GetSeriesReturnsCorrectImdbId()
        {
            var response = client.GetSeries(query);
            Assert.True(response.Series[0].ImdbId == "tt0386676");
        }

        [Fact]
        public void GetSeriesReturnsCorrectZap2ItId()
        {
            var response = client.GetSeries(query);
            Assert.True(response.Series[0].Zap2ItId == "SH00726133");
        }

    }
}
