using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Xml.Linq;

namespace nRage.Tests.Unit.TVRageClient
{    
    public class MockRetriever : IRetriever
    {
        private Dictionary<string, string> _mockResults;               
        private static Stack<string> _urlHistory{get; set;}

        #region URL constants
        public const string SHOWLIST = @"show_list.php";

        public const string LASTUPDATES = @"last_updates.php?hours=0";
        public const string LASTUPDATES_4 = @"last_updates.php?hours=4";
        public const string LASTUPDATES_24 = @"last_updates.php?hours=24";
        public const string LASTUPDATES_999 = @"last_updates.php?hours=999";

        public const string SEARCH_WILFRED = @"search.php?show=wilfred";
        public const string SEARCH_WILFFERXJD = @"search.php?show=wilfferxjd";

        public const string SEARCHFULL_BREAKINGBAD = @"full_search.php?show=breakingbad";
        public const string SEARCHFULL_BRACVNKINGBADGA = @"full_search.php?show=bracvnkingbadga";

        public const string SHOWINFO_18753 = @"showinfo.php?sid=18753";
        public const string SHOWINFO_842999999 = @"showinfo.php?sid=842999999";

        public const string EPISODEINFO_5481_2x13 = @"episodeinfo.php?sid=5481&ep=02x13";
        public const string EPISODEINFO_5481_99x99 = @"episodeinfo.php?sid=5481&ep=99x99";
        public const string EPISODEINFO_999999999_99x99 = @"episodeinfo.php?sid=999999999&ep=99x99";

        public const string EPISODELIST_15352 = @"episode_list.php?sid=15352";
        public const string EPISODELIST_20260 = @"episode_list.php?sid=20260";

        public const string FULLSHOWINFO_32517 = @"full_show_info.php?sid=32517";
        public const string FULLSHOWINFO_999999999 = @"full_show_info.php?sid=999999999";
        #endregion

        public MockRetriever()
        {               
            _urlHistory = new Stack<string>();
            _mockResults = new Dictionary<string, string>();

            _mockResults[SHOWLIST] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SHOWLIST;

            _mockResults[LASTUPDATES] = nRage.Tests.Unit.Properties.Resources.RESPONSE_LASTUPDATES;
            _mockResults[LASTUPDATES_4] = nRage.Tests.Unit.Properties.Resources.RESPONSE_LASTUPDATES_4;
            _mockResults[LASTUPDATES_24] = nRage.Tests.Unit.Properties.Resources.RESPONSE_LASTUPDATES; // Defaults to 24 hours when none specified
            _mockResults[LASTUPDATES_999] = nRage.Tests.Unit.Properties.Resources.RESPONSE_LASTUPDATES_999;

            _mockResults[SEARCH_WILFRED] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCH_WILFRED;
            _mockResults[SEARCH_WILFFERXJD] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCH_WILFFERXJD;

            _mockResults[SEARCHFULL_BREAKINGBAD] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCHFULL_BREAKINGBAD;
            _mockResults[SEARCHFULL_BRACVNKINGBADGA] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SEARCHFULL_BRACVNKINGBADGA;

            _mockResults[SHOWINFO_18753] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SHOWINFO_18753;
            _mockResults[SHOWINFO_842999999] = nRage.Tests.Unit.Properties.Resources.RESPONSE_SHOWINFO_842999999;

            _mockResults[EPISODEINFO_5481_2x13] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODEINFO_5481_2x13;
            _mockResults[EPISODEINFO_5481_99x99] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODEINFO_5481_99x99;
            _mockResults[EPISODEINFO_999999999_99x99] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODEINFO_999999999_99x99;

            _mockResults[EPISODELIST_15352] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODELIST_15352;
            _mockResults[EPISODELIST_20260] = nRage.Tests.Unit.Properties.Resources.RESPONSE_EPISODELIST_20260;

            _mockResults[FULLSHOWINFO_32517] = nRage.Tests.Unit.Properties.Resources.RESPONSE_FULLSHOWINFO_32517;                        
            _mockResults[FULLSHOWINFO_999999999] = nRage.Tests.Unit.Properties.Resources.RESPONSE_FULLSHOWINFO_999999999;
        }

        public static string GetLastURLCalled(){
            return _urlHistory.Pop();
        }

        public Stream Get(string url)
        {
            Debug.WriteLine("MockRetriever getting URL: " + url);

            string key = url.Split('/').Last();
            _urlHistory.Push(key);            

            string value = _mockResults[key];                       
            byte[] byteArray = Encoding.UTF8.GetBytes(value);
            return new MemoryStream(byteArray);
        }        
    }
}
