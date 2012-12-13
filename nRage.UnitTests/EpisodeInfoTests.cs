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
        public void CanGetEpisodeInfo()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response != null);
        }

        [Fact]
        public void GetEpisodeInfoThrowsWhenInvalidShowID()
        {
            Assert.Throws<ShowNotFoundException>(()=>{
               client.GetEpisodeInfo(invalid_showId,invalid_episodeLabel); 
            });
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectName()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Name == "");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectLink()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.LatestEpisodeAirDate == "");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectStarted()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Started == "");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectEnded()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Ended == "");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectCountry()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Country == "");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectStatus()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Status == "");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectClassification()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Classification == "");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectGenres()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Genres.Count == 0);
            Assert.True(response.Genres.Single() == "");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectAirTime()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.AirTime == "");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectRunTime()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.RunTime == "");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectEpisode()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            // Assert.True(response.Episode == ""); // TODO
        }

        #pragma warning disable 612,618 // Ignore warning about obsolete params
        [Fact]
        public void GetEpisodeInfoDoesNotReturnObseleteValues()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);            
            Assert.True(string.IsNullOrEmpty(response.LatestEpisodeNumber));
            Assert.True(string.IsNullOrEmpty(response.LatestEpisodeTitle));
            Assert.True(string.IsNullOrEmpty(response.LatestEpisodeAirDate));            
        }
        #pragma warning restore 612,618
    }
}
