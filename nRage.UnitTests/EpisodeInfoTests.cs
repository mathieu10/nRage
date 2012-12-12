using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{
    public class EpisodeInfoTests : TVRageClientTestBase
    {                
        private const int showId = 5481;
        private const int seasonNumber = 2;
        private const int episodeNumber = 13;
        private const string episodeLabel = "02x13";

        private const int invalid_showId = 999999999;
        private const string invalid_episodeLabel = "99x99";
        
        [Fact]
        public void CanGetEpisodeList()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeListThrowsWhenInvalidShowID()
        {
            Assert.Throws<ShowNotFoundException>(()=>{
               client.GetEpisodeInfo(invalid_showId,invalid_episodeLabel); 
            });
        }



    }
}
