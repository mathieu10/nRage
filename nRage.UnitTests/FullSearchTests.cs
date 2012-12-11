using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{

    public class FullSearchTests : TestBase
    {            
        private const string title = "breakingbad";
        private const string incorrect_title = "bracvnkingbadga";

        [Fact]
        public void CanFullSearchByTitle()
        { 
            var client = _ioc.Get<TVRageClient>();            

            var response = client.FullSearchByTitle(title);
            Assert.True(response != null);
            Assert.True(response.Results.Count == 1);
        }

        [Fact]
        public void FullSearchByTitleReturnsEmptyResultsWhenNoMatches()
        {
            var client = _ioc.Get<TVRageClient>();            

            var response = client.FullSearchByTitle(incorrect_title);
            Assert.True(response.Results.Count == 0);
        }           

        [Fact]
        public void FullSearchByTitleReturnsCorrectShowID()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.ShowID==18164);            
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectName()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Name=="Breaking Bad");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectLink()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Link==@"http://www.tvrage.com/Breaking_Bad");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectCountry()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Country=="US");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectYearStarted()
        {
            var client = _ioc.Get<TVRageClient>();         

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Started=="Jan/20/2008");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectYearEnded()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Ended=="");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectStatus()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Status == "Final Season");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectSeasonsCount()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Seasons=="5");            
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectClassification()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Classification=="Scripted");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectGenres()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Genres.Count==1);
            Assert.True(result.Genres.Single()=="Drama");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectAirTime()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.AirTime=="22:00");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectAirDay()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.AirDay=="Sunday");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectNetwork()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Network=="AMC");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectRunTime()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.RunTime=="60");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectAKAs()
        {
            var client = _ioc.Get<TVRageClient>();

            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.AKAs.Count==3);
            Assert.True(result.AKAs.ElementAt(0).Country=="SI");
            Assert.True(result.AKAs.ElementAt(0).Name=="Kriva pota");
            Assert.True(result.AKAs.ElementAt(1).Country=="HU");
            Assert.True(result.AKAs.ElementAt(1).Name=="Totál szívás");
            Assert.True(result.AKAs.ElementAt(2).Country=="BG");
            Assert.True(result.AKAs.ElementAt(2).Name=="В обувките на сатаната");
            
        }

    }
}
