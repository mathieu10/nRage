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
            _mockResults = new Dictionary<string, string>();
            _mockResults["search.php?show=wilfred"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCH_WILFRED;
            _mockResults["search.php?show=wilfferxjd"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCH_WILFFERXJD;
            _mockResults[""] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCHFULL_WILFRED;
            _mockResults[""] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SHOWINFO_15352;
            _mockResults[""] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODELIST_15352;
            _mockResults[""] = nRage.Tests.Unit.Properties.Resources.RESPONSE_FULLSHOWINFO_15352;            
            _mockResults[""] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODEINFO_15352_2x05;            
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