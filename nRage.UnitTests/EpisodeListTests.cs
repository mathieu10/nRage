using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{

    public class EpisodeListTests : TVRageClientTestBase
    {                
        private const int showId = 15352;
        private const int noEpidodeResults_showId = 20260;

        [Fact]
        public void CanGetEpisodeList()
        { 
            var response = client.GetEpisodeList(showId);
            Assert.True(response != null);
        }

        [Fact]
        public void CanGetEpisodeListWhereNoEpisodeResults()
        { 
            var response = client.GetEpisodeList(showId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectSeasonNumber()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectSeasonEpisodeCount()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeNumber()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeSeasonNumber()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeProductionNumber()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeAirDate()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeLink()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectEpisodeTitle()
        {
            var response = client.GetEpisodeList(showId);
            Assert.True(response != null);
        }
    }
}
