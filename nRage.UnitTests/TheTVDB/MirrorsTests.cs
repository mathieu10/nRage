using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit.TheTVDB
{

    public class MirrorsTests : TestBase
    {                        
        [Fact]
        public void CanGetMirrors()
        { 
            var response = client.GetMirrors();
            Assert.True(response != null);
        }

        [Fact]
        public void GetMirrorsCallsCorrectURL()
        { 
            client.GetMirrors();
            Assert.True(MockRetriever.GetLastURLCalled() == TheTVDBMockRetriever.MIRRORS);
        }

        [Fact]
        public void GetMirrorsReturnsCorrectMirrorID()
        {
            var response = client.GetMirrors();
            var result = response.Mirrors.First();

            Assert.True(result.ID == 1);
        }

        [Fact]
        public void GetMirrorsReturnsCorrectMirrorPath()
        {
            var response = client.GetMirrors();
            var result = response.Mirrors.First();

            Assert.True(result.MirrorPath == "http://thetvdb.com");
        }

        [Fact]
        public void GetMirrorsReturnsCorrectMirrorTypeMask()
        {
            var response = client.GetMirrors();
            var result = response.Mirrors.First();

            Assert.True(result.TypeMask == 7);
        }

    }
}
