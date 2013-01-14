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
            Assert.True(MockRetriever.GetLastURLCalled() == TheTVDBMockRetriever.GETSERIES_THEOFFICE);
        }

        [Fact]
        public void GetSeriesReturnsCorrectX()
        {
            var response = client.GetSeries("");
            Assert.False(true);
        }

    }
}
