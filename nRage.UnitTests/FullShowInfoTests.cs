using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{

    public class FullFullShowInfoTests : TVRageClientTestBase
    {                
        private const int show_id = 32517;
        private const int nonexistent_show_id = 999999999;

        [Fact]
        public void CanGetFullShowInfo()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response != null);
        }

        [Fact]
        public void GetFullShowInfoCallsCorrectURL()
        { 
            client.GetFullShowInfo(show_id);
            Assert.True(MockRetriever.GetLastURLCalled() == MockRetriever.FULLSHOWINFO_32517);
        }

        [Fact]
        public void GetFullShowInfoThrowsWhenInvalidShowID()
        { 
            Assert.Throws<ShowNotFoundException>(()=>{
                client.GetFullShowInfo(nonexistent_show_id);
            });
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectShowID()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.ShowID == 32517);
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectShowName()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.Name == "Howzat! Kerry Packer's War");
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectShowLink()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.ShowLink == "http://tvrage.com/shows/id-32517");
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectSeasonCount()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.TotalSeasons == "1");
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectDateStarted()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.Started == "Aug/19/2012");
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectDateEnded()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.Ended == "");
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectOriginCountry()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.OriginCountry == "AU");
        }

        // TODO image // http://images.tvrage.com/shows/33/32517.jpg

        [Fact]
        public void GetFullShowInfoReturnsCorrectStatus()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.Status == "New Series");
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectClassification()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.Classification == "Mini-Series");
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectGenres()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.Genres.Count == 2);
            Assert.True(response.Genres.ElementAt(0) == "Drama");
            Assert.True(response.Genres.ElementAt(1) == "Sports");
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectRuntime()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.RunTime == "120");
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectNetwork()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.Network == "Nine");
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectAirTime()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.AirTime == "20:30");
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectAirDay()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.AirDay == "Sunday");
        }

        [Fact]
        public void GetFullShowInfoReturnsCorrectTimeZone()
        { 
            var response = client.GetFullShowInfo(show_id);
            Assert.True(response.TimeZone == @"GMT+10 -DST");
        }

    }
}
