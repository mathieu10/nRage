using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit.TVRage
{

    public class EpisodeListTests : TestBase
    {                
        private const int showId = 15352;
        private const int noEpisodeResults_showId = 20260;

        [Fact]
        public void CanGetEpisodeList()
        { 
            var response = client.GetEpisodeList(showId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListCallsCorrectURL()
        { 
            client.GetEpisodeList(showId);
            Assert.True(MockRetriever.GetLastURLCalled() == TvrageMockRetriever.EPISODELIST_15352);
        }

        [Fact]
        public void CanGetEpisodeListWhereNoEpisodeResults()
        { 
            var response = client.GetEpisodeList(noEpisodeResults_showId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectSeasonCount()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response.TotalSeasons == "2");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectSeasonEpisodeCount()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response.Seasons[0].Episodes.Count == 8);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeNumber()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response.Seasons[1].Episodes[0].EpNum == "9");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeSeasonNumber()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response.Seasons[1].Episodes[0].SeasonNum == "01");
        }        

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeAirDate()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response.Seasons[0].Episodes[4].AirDate == "2007-04-16");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeLink()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response.Seasons[1].Episodes[4].Link == @"http://www.tvrage.com/shows/id-15352/episodes/1064916984");
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeTitle()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response.Seasons[1].Episodes[4].Title == "The Ice Dog Cometh");
        }


        #pragma warning disable 612,618 // Ignore warning about obsolete params
        [Fact]
        public void GetEpisodeListDoesNotReturnObsoleteValues()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(string.IsNullOrEmpty(response.Seasons[0].Episodes[0].ProdNum));
        }
        #pragma warning restore 612,618
    }
}
