using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{

    public class FullSearchTests : TVRageClientTestBase
    {            
        private const string title = "breakingbad";
        private const string incorrect_title = "bracvnkingbadga";

        private TVRageClient client;

        public FullSearchTests()
        {
            client = _ioc.Get<TVRageClient>();
        }

        [Fact]
        public void CanFullSearchByTitle()
        { 
            var response = client.FullSearchByTitle(title);
            Assert.True(response != null);
            Assert.True(response.Results.Count == 1);
        }

        [Fact]
        public void FullSearchByTitleReturnsEmptyResultsWhenNoMatches()
        {
            var response = client.FullSearchByTitle(incorrect_title);
            Assert.True(response.Results.Count == 0);
        }           

        [Fact]
        public void FullSearchByTitleReturnsCorrectShowID()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.ShowID==18164);            
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectName()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Name=="Breaking Bad");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectLink()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Link==@"http://www.tvrage.com/Breaking_Bad");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectCountry()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Country=="US");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectYearStarted()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Started=="Jan/20/2008");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectYearEnded()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Ended=="");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectStatus()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Status == "Final Season");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectSeasonsCount()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Seasons=="5");            
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectClassification()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Classification=="Scripted");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectGenres()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Genres.Count==1);
            Assert.True(result.Genres.Single()=="Drama");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectAirTime()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.AirTime=="22:00");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectAirDay()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.AirDay=="Sunday");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectNetwork()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Network=="AMC");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectRunTime()
        {
            var response = client.FullSearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.RunTime=="60");
        }

        [Fact]
        public void FullSearchByTitleReturnsCorrectAKAs()
        {
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
