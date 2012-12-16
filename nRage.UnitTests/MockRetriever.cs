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
        private static Stack<string> _urlHistory{get; set;}

        public MockRetriever()
        {   
            //RESPONSE_FULLSHOWINFO_32517 - episodes (Kerry Packer)

            //TODO: replace this with Moq/RhinoMocks/etc 

            _urlHistory = new Stack<string>();

            _mockResults = new Dictionary<string, string>();

            _mockResults["show_list.php"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SHOWLIST;

            _mockResults["search.php?show=wilfred"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCH_WILFRED;
            _mockResults["search.php?show=wilfferxjd"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCH_WILFFERXJD;

            _mockResults["full_search.php?show=breakingbad"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCHFULL_BREAKINGBAD;
            _mockResults["full_search.php?show=bracvnkingbadga"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCHFULL_BRACVNKINGBADGA;

            _mockResults["showinfo.php?sid=18753"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SHOWINFO_18753;
            _mockResults["showinfo.php?sid=842999999"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SHOWINFO_842999999;

            _mockResults["episodeinfo.php?sid=5481&ep=02x13"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODEINFO_5481_2x13;
            _mockResults["episodeinfo.php?sid=5481&ep=99x99"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODEINFO_5481_99x99;
            _mockResults["episodeinfo.php?sid=999999999&ep=99x99"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODEINFO_999999999;

            _mockResults["episode_list.php?sid=15352"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODELIST_15352;
            _mockResults["episode_list.php?sid=20260"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODELIST_20260;

            _mockResults["full_show_info.php?sid=32517"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_FULLSHOWINFO_32517;                        
            _mockResults["full_show_info.php?sid=999999999"] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODEINFO_999999999;
        }

        public static string GetLastURLCalled(){
            return _urlHistory.Pop();
        }

        public Stream Get(string url)
        {
            string key = url.Split('/').Last();
            _urlHistory.Push(key);

            string value = _mockResults[key];                       
            byte[] byteArray = Encoding.UTF8.GetBytes(value);
            return new MemoryStream(byteArray);
        }        
    }
}
