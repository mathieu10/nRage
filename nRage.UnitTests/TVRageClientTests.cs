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
        // TODO: is it a Show or a show? Or something else?
        [Fact]
        public void CanSearchShowByTitle() { 
            //http://services.tvrage.com/feeds/search.php?show=buffy
            throw new NotImplementedException();
        }

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
        
       
    }
}
