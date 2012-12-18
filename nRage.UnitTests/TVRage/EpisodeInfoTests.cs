using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit.TVRage
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
        public void GetCallsEpisodeInfoCorrectURL()
        { 
            client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(MockRetriever.GetLastURLCalled() == TVRageMockRetriever.EPISODEINFO_5481_2x13);
        }
        
        [Fact]
        public void GetEpisodeInfoBySeasonAndNumberCallsCorrectURL()
        { 
            client.GetEpisodeInfo(showId,seasonNumber,episodeNumber);
            Assert.True(MockRetriever.GetLastURLCalled() == TVRageMockRetriever.EPISODEINFO_5481_2x13);
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
            Assert.True(response.Name == "Teenage Mutant Ninja Turtles (1987)");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectLink()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Link == "http://www.tvrage.com/Teenage_Mutant_Ninja_Turtles_1987");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectStarted()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Started == "1988-10-01");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectEnded()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Ended == "1996-11-00");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectCountry()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Country == "USA");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectStatus()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Status == "Canceled/Ended");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectClassification()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Classification == "Animation");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectGenres()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Genres.Count == 3);
            Assert.True(response.Genres.ElementAt(0) == "Animation General");
            Assert.True(response.Genres.ElementAt(1) == "Action");
            Assert.True(response.Genres.ElementAt(2) == "Adventure");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectAirTime()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.AirTime == "Saturday");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectRunTime()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.RunTime == "30");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectEpisodeNumber()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Episode.Number == "02x13");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectEpisodeTitle()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Episode.Title == "Return of the Technodrome");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectEpisodeAirDate()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Episode.AirDate == "1988-12-03");
        }

        [Fact]
        public void GetEpisodeInfoReturnsCorrectEpisodeURL()
        { 
            var response = client.GetEpisodeInfo(showId,episodeLabel);
            Assert.True(response.Episode.URL == "http://www.tvrage.com/Teenage_Mutant_Ninja_Turtles_1987/episodes/169211");
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
