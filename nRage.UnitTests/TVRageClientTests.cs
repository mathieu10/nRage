using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace nRage.UnitTests
{

    public class TVRageClientTests
    {        
        public TVRageClientTests() { 
            // TODO: IOC: register mock retriever
        }

        [Fact]
        public void CanSearchShowByTitle() { 
            var client = new TVRageClient(new MockRetriever());
            var title = "wilfred";

            var response = client.SearchByTitle(title);
            Assert.True(response != null);
            Assert.True(response.Results != null);
        }

        [Fact]
        public void SearchShowByTitleReturnsCorrectInformation()
        {
            var client = new TVRageClient(new MockRetriever());
            var title = "wilfred";

            var response = client.SearchByTitle(title);
            Assert.True(response.Results.Count == 2);
            
            var result = response.Results.First();
            Assert.True(result.ShowID==15352);
            Assert.True(result.Name=="Wilfred");
            Assert.True(result.Link==@"http://www.tvrage.com/shows/id-15352");
            Assert.True(result.Country=="AU");
            Assert.True(result.Started=="Mar/19/2007");
            Assert.True(result.Ended=="0");
            Assert.True(result.Seasons=="2");
            Assert.True(result.Classification=="Scripted");
            Assert.True(result.Genres.Count==2);
            Assert.True(result.Genres.ElementAt(0) == "Comedy");
            Assert.True(result.Genres.ElementAt(1)=="Drama");
        }

        [Fact]
        public void SearchShowByTitleReturnsEmptyResultsWhenNoMatches()
        {
            var client = new TVRageClient(new MockRetriever());
            var title = "wilfferd";

            var response = client.SearchByTitle(title);
            Assert.True(response.Results.Count == 0);
        }
        

        /*
       [Fact]
       public void CanFullSearchShowByTitle() { 
           //http://services.tvrage.com/feeds/full_search.php?show=buffy
           throw new NotImplementedException();
       }
        
        [Fact]
        public void CanGetShowInfoByShowID() {
            //http://services.tvrage.com/feeds/showinfo.php?sid=2930
            throw new NotImplementedException();
        }

        [Fact]
        public void CanGetEpisodeListByShowID() { 
            //http://services.tvrage.com/feeds/episode_list.php?sid=2930
            throw new NotImplementedException();
        }

        [Fact]
        public void CanGetEpisodeByEpisodeID() { 
            //http://services.tvrage.com/feeds/episodeinfo.php?sid=2930&ep=2x04
            throw new NotImplementedException();
        }

        [Fact]
        public void CanGetShowInfoAndEpisodeListByShowID() { 
            //http://services.tvrage.com/feeds/full_show_info.php?sid=2930
            throw new NotImplementedException();
        }
        */
       
    }
}
