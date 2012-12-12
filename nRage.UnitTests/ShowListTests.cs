using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{

    public class ShowListTests : TestBase
    {                
        private const int showId = 0;
        private TVRageClient client;

        public ShowListTests()
        {
            client = _ioc.Get<TVRageClient>();
        }

        [Fact]
        public void CanGetEpisodeList()
        { 
            var response = client.GetShowList();
            Assert.True(response != null);
        }

    }
}
