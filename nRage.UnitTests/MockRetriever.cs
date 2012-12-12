using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Xml.Linq;

namespace nRage.Tests.Unit
{
    public class MockRetriever : IRetriever
    {
        private Dictionary<string, string> _mockResults;

        public MockRetriever()
        {   
            //RESPONSE_FULLSHOWINFO_32517 - episodes (Kerry Packer)

            //TODO: replace this with Moq/RhinoMocks/etc 

            _mockResults = new Dictionary<string, string>();
            _mockResults["search.php?show=wilfred"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCH_WILFRED;
            _mockResults["search.php?show=wilfferxjd"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCH_WILFFERXJD;

            _mockResults["full_search.php?show=breakingbad"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCHFULL_BREAKINGBAD;
            _mockResults["full_search.php?show=bracvnkingbadga"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCHFULL_BRACVNKINGBADGA;

            _mockResults["showinfo.php?sid=18753"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SHOWINFO_18753;

            _mockResults["episode_list.php?sid=15352"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODELIST_15352;
            _mockResults["full_show_info.php?sid=15352"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_FULLSHOWINFO_20260;            
            _mockResults["episodeinfo.php?sid=15352&ep=2x05"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODEINFO_15352_2x05;            
        }

        public Stream Get(string url)
        {
            string key = url.Split('/').Last();
            string value = _mockResults[key];

            byte[] byteArray = Encoding.UTF8.GetBytes(value);
            return new MemoryStream(byteArray);
        }        
    }
}
