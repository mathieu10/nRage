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

    }
}
