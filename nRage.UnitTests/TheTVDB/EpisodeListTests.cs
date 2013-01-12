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
          
        [Fact]
        public void CanGetEpisodeList()
        { 
            var response = client.GetEpisodeList(1);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListCallsCorrectURL()
        { 
            client.GetEpisodeList(1);
            Assert.True(MockRetriever.GetLastURLCalled() == TheTVDBMockRetriever.EPISODELIST);
        }

        [Fact]
        public void GetEpisodeListReturnsCorrectX()
        {
            var response = client.GetEpisodeList(1);
            Assert.False(true);
        }

    }
}
