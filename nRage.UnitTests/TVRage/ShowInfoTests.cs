using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit.TVRage
{

    public class ShowInfoTests : TestBase
    {            
        private const int show_id = 18753;
        private const int nonexistent_show_id = 842999999;

        [Fact]
        public void CanGetShowInfoByShowID()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response != null);
        }

        [Fact]
        public void GetShowInfoCallsCorrectURL()
        { 
            client.GetShowInfo(show_id);
            Assert.True(MockRetriever.GetLastURLCalled() == TVRageMockRetriever.SHOWINFO_18753);
        }

        [Fact]
        public void GetShowInfoThrowsWhenInvalidShowID()
        { 
            Assert.Throws<ShowNotFoundException>(()=>{
                client.GetShowInfo(nonexistent_show_id);
            });
        }

        [Fact]
        public void GetShowInfoReturnsCorrectShowID()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.ShowID == 18753);
        }

        [Fact]
        public void GetShowInfoReturnsCorrectShowName()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.ShowName == "The Inbetweeners");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectShowLink()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.ShowLink == "http://tvrage.com/The_Inbetweeners");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectSeasonCount()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.Seasons == "3");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectYearStarted()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.Started == "2008");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectStartDate()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.StartDate == @"May/01/2008");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectYearEnded()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.Ended == "");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectOriginCountry()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.OriginCountry == "UK");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectStatus()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.Status == @"Canceled/Ended");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectClassification()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.Classification == "Scripted");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectGenres()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.Genres.Count == 1);
            Assert.True(response.Genres.Single() == "Comedy");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectRuntime()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.RunTime == "30");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectNetwork()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.Network == "E4");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectAirTime()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.AirTime == "22:00");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectAirDay()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.AirDay == "Thursday");
        }

        [Fact]
        public void GetShowInfoReturnsCorrectTimeZone()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response.TimeZone == @"GMT+0 -DST");
        }

    }
}
