using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{

    public class EpisodeListTests : TVRageClientTestBase
    {                
        private const int showId = 0;        

        [Fact]
        public void CanGetEpisodeList()
        { 
            var response = client.GetEpisodeList(showId);
            Assert.True(response != null);
        }

    }
}
