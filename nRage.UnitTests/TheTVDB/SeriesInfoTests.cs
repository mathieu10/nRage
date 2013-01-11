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
          
        [Fact]
        public void CanGetSeriesInfo()
        { 
            var response = client.GetSeriesInfo(seriesId);
            Assert.True(response != null);
        }

        [Fact]
        public void GetSeriesInfoCallsCorrectURL()
        { 
            client.GetSeriesInfo(1);
            Assert.True(MockRetriever.GetLastURLCalled() == TheTVDBMockRetriever.SERIESINFO);
        }

        [Fact]
        public void GetSeriesInfoReturnsCorrectX()
        {
            var response = client.GetSeriesInfo(1);
            Assert.False(true);
        }

    }
}
