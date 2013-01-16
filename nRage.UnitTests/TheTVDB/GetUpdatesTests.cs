using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit.TheTVDB
{
    public class UpdatesTests : TestBase
    {      
        public UpdatesTests() : base(){}

        private const int timeStamp = 1355812429;
        private const int invalidTimeStamp = -1;
          
        [Fact]
        public void CanGetUpdates()
        { 
            var response = client.GetUpdates(timeStamp);
            Assert.True(response != null);
        }

        [Fact]
        public void GetUpdatesCallsCorrectURL()
        { 
            client.GetUpdates(timeStamp);
            Assert.True(MockRetriever.GetLastURLCalled() == TvdbMockRetriever.UPDATES_1355812429);
        }

        [Fact]
        public void GetUpdatesWithInvalidTimeThrowsException()
        { 
            Assert.Throws<ArgumentOutOfRangeException>(()=>
                client.GetUpdates(invalidTimeStamp)
            );
        }

        [Fact]
        public void GetUpdatesReturnsCorrectTime()
        {
            var response = client.GetUpdates(timeStamp);
            Assert.True(response.Time == timeStamp.ToString());
        }

        [Fact]
        public void GetUpdatesReturnsCorrectSeries()
        {
            var response = client.GetUpdates(timeStamp);
            Assert.True(response.Series.Count == 13);
            Assert.True(response.Series[0] == "70327");
            Assert.True(response.Series[12] == "257843");            
        }

    }
}
