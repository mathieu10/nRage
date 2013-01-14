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
        private const string invalidSeriesId = "";

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
                client.GetSeriesById("")
            );
        }

        [Fact]
        public void GetSeriesReturnsCorrectX()
        {
            var response = client.GetSeries("");
            Assert.False(true);
        }

    }
}
