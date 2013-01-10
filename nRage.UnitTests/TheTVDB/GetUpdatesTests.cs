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

        private const int timeStamp = 1355786893;
          
        [Fact]
        public void CanGetUpdates()
        { 
            var response = client.GetUpdates(timeStamp);
            Assert.True(response != null);
        }

        [Fact]
        public void GetUpdatesCallsCorrectURL()
        { 
            client.GetUpdates(1);
            Assert.True(MockRetriever.GetLastURLCalled() == TheTVDBMockRetriever.UPDATES);
        }

        [Fact]
        public void GetUpdatesWithInvalidTimeThrowsException()
        { 
            Assert.Throws<Exception>(()=>
                client.GetUpdates(-1)
            );
        }

        [Fact]
        public void GetUpdatesReturnsCorrectX()
        {
            var response = client.GetUpdates(1);
            Assert.False(true);
        }

    }
}
