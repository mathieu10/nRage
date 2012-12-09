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
        // TODO: is it a series or a show? Or something else?
        [Fact]
        public void CanSearchSeriesByTitle() { 
            //http://services.tvrage.com/feeds/search.php?show=buffy
            throw new NotImplementedException();
        }

        [Fact]
        public void CanFullSearchSeriesByTitle() { 
            //http://services.tvrage.com/feeds/full_search.php?show=buffy
            throw new NotImplementedException();
        }

        [Fact]
        public void CanViewSeriesByShowID() {
            //http://services.tvrage.com/feeds/showinfo.php?sid=2930
            throw new NotImplementedException();
        }

        [Fact]
        public void CanViewEpisodeListBySeriesID() { 
            //http://services.tvrage.com/feeds/episode_list.php?sid=2930
            throw new NotImplementedException();
        }

        [Fact]
        public void CanViewEpisodeByID() { 
            //http://services.tvrage.com/feeds/episodeinfo.php?sid=2930&ep=2x04
            throw new NotImplementedException();
        }

        //http://services.tvrage.com/feeds/full_show_info.php?sid=2930 ??
       
    }
}
