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
        /// <summary>
        /// DISCLAIMER:
        /// There are not really "unit" tests in the pure sense.
        /// If you get your panties in a twist over the distinction between unit
        /// and integration tests, or 'impure' tests which touch physical resources
        /// eg network, feel free to write your own. I honestly don't know a better
        /// way off hand to write meaningful TDD tests against a web service.
        /// </summary>

        [Fact]
        public void CanSearchShowByTitle() { 
            var client = new TVRageClient();
            var title = "wilfred";

            var result = client.SearchByTitle(title);

            Assert.True(result != null);
        }

        //[Fact]
        public void CanFullSearchShowByTitle() { 
            //http://services.tvrage.com/feeds/full_search.php?show=buffy
            throw new NotImplementedException();
        }

        //[Fact]
        public void CanGetShowInfoByShowID() {
            //http://services.tvrage.com/feeds/showinfo.php?sid=2930
            throw new NotImplementedException();
        }

        //[Fact]
        public void CanGetEpisodeListByShowID() { 
            //http://services.tvrage.com/feeds/episode_list.php?sid=2930
            throw new NotImplementedException();
        }

        //[Fact]
        public void CanGetEpisodeByEpisodeID() { 
            //http://services.tvrage.com/feeds/episodeinfo.php?sid=2930&ep=2x04
            throw new NotImplementedException();
        }

        //[Fact]
        public void CanGetShowInfoAndEpisodeListByShowID() { 
            //http://services.tvrage.com/feeds/full_show_info.php?sid=2930
            throw new NotImplementedException();
        }
        
       
    }
}
