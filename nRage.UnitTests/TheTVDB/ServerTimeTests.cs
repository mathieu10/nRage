using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit.TheTVDB
{
    public class ServerTimeTests : TestBase
    {      
        public ServerTimeTests() : base(){}
          
        [Fact]
        public void CanGetServerTime()
        { 
            var response = client.GetServerTime();
            Assert.True(response != null);
        }

        [Fact]
        public void GetServerTimeCallsCorrectURL()
        { 
            client.GetServerTime();
            Assert.True(MockRetriever.GetLastURLCalled() == TheTVDBMockRetriever.SERVERTIME);
        }

        [Fact]
        public void GetServerTimeReturnsCorrectServerTime()
        {
            var response = client.GetServerTime();
            Assert.True(response.Time=="1355786893");
        }

    }
}
