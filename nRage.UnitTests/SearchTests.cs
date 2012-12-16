using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{

    public class SearchTests : TVRageClientTestBase
    {                
        private const string title = "wilfred";
        private const string incorrect_title = "wilfferxjd";

        [Fact]
        public void CanSearchByTitle()
        { 
            var response = client.SearchByTitle(title);
            Assert.True(response != null);
            Assert.True(response.Results.Count == 2);
        }

        [Fact]
        public void GetSearchCallsCorrectURL()
        { 
            client.SearchByTitle(title);
            Assert.True(MockRetriever.GetLastURLCalled() == MockRetriever.SEARCH_WILFRED);
        }

        [Fact]
        public void SearchByTitleReturnsEmptyResultsWhenNoMatches()
        {
            var response = client.SearchByTitle(incorrect_title);
            Assert.True(response.Results.Count == 0);
        }           

        [Fact]
        public void SearchByTitleReturnsCorrectShowID()
        {
            var response = client.SearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.ShowID==15352);            
        }

        [Fact]
        public void SearchByTitleReturnsCorrectName()
        {
            var response = client.SearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Name=="Wilfred");
        }

        [Fact]
        public void SearchByTitleReturnsCorrectLink()
        {
            var response = client.SearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Link==@"http://www.tvrage.com/shows/id-15352");
        }

        [Fact]
        public void SearchByTitleReturnsCorrectCountry()
        {
            var response = client.SearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Country=="AU");
        }

        [Fact]
        public void SearchByTitleReturnsCorrectYearStarted()
        {
            var response = client.SearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Started=="2007");
        }

        [Fact]
        public void SearchByTitleReturnsCorrectYearEnded()
        {
            var response = client.SearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Ended=="0");
        }

        [Fact]
        public void SearchByTitleReturnsCorrectStatus()
        {
            var response = client.SearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Status == "Canceled/Ended");
        }

        [Fact]
        public void SearchByTitleReturnsCorrectSeasonsCount()
        {
            var response = client.SearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Seasons=="2");            
        }

        [Fact]
        public void SearchByTitleReturnsCorrectClassification()
        {
            var response = client.SearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Classification=="Scripted");            
        }

        [Fact]
        public void SearchByTitleReturnsCorrectGenres()
        {
            var response = client.SearchByTitle(title);
            var result = response.Results.First();

            Assert.True(result.Genres.Count==2);
            Assert.True(result.Genres.ElementAt(0) == "Comedy");
            Assert.True(result.Genres.ElementAt(1)=="Drama");
        }

    }
}
