using nRage.Tests.Unit.Properties;

namespace nRage.Tests.Unit.TVRage
{
    public class TvrageMockRetriever : MockRetriever
    {
        public TvrageMockRetriever() : base(){}

        #region URL constants
        private static readonly string APIKEY = @"http://services.tvrage.com/feeds/";
        public static readonly string SHOWLIST = APIKEY + @"show_list.php";

        public static readonly string LASTUPDATES = APIKEY + @"last_updates.php?hours=0";
        public static readonly string LASTUPDATES_4 = APIKEY + @"last_updates.php?hours=4";
        public static readonly string LASTUPDATES_24 = APIKEY + @"last_updates.php?hours=24";
        public static readonly string LASTUPDATES_999 = APIKEY + @"last_updates.php?hours=999";

        public static readonly string SEARCH_WILFRED = APIKEY + @"search.php?show=wilfred";
        public static readonly string SEARCH_WILFFERXJD = APIKEY + @"search.php?show=wilfferxjd";

        public static readonly string SEARCHFULL_BREAKINGBAD = APIKEY + @"full_search.php?show=breakingbad";
        public static readonly string SEARCHFULL_BRACVNKINGBADGA = APIKEY + @"full_search.php?show=bracvnkingbadga";

        public static readonly string SHOWINFO_18753 = APIKEY + @"showinfo.php?sid=18753";
        public static readonly string SHOWINFO_842999999 = APIKEY + @"showinfo.php?sid=842999999";

        public static readonly string EPISODEINFO_5481_2x13 = APIKEY + @"episodeinfo.php?sid=5481&ep=02x13";
        public static readonly string EPISODEINFO_5481_99x99 = APIKEY + @"episodeinfo.php?sid=5481&ep=99x99";
        public static readonly string EPISODEINFO_999999999_99x99 = APIKEY + @"episodeinfo.php?sid=999999999&ep=99x99";

        public static readonly string EPISODELIST_15352 = APIKEY + @"episode_list.php?sid=15352";
        public static readonly string EPISODELIST_20260 = APIKEY + @"episode_list.php?sid=20260";

        public static readonly string FULLSHOWINFO_32517 = APIKEY + @"full_show_info.php?sid=32517";
        public static readonly string FULLSHOWINFO_999999999 = APIKEY + @"full_show_info.php?sid=999999999";
        #endregion

        protected override void FillCache()
        { 
            Cache(SHOWLIST, Properties.TVRage.RESPONSE_SHOWLIST);

            Cache(LASTUPDATES, Properties.TVRage.RESPONSE_LASTUPDATES);
            Cache(LASTUPDATES_4, Properties.TVRage.RESPONSE_LASTUPDATES_4);
            Cache(LASTUPDATES_24, Properties.TVRage.RESPONSE_LASTUPDATES); // Defaults to 24 hours when none specified
            Cache(LASTUPDATES_999, Properties.TVRage.RESPONSE_LASTUPDATES_999);

            Cache(SEARCH_WILFRED, Properties.TVRage.RESPONSE_SEARCH_WILFRED);
            Cache(SEARCH_WILFFERXJD, Properties.TVRage.RESPONSE_SEARCH_WILFFERXJD);

            Cache(SEARCHFULL_BREAKINGBAD, Properties.TVRage.RESPONSE_SEARCHFULL_BREAKINGBAD);
            Cache(SEARCHFULL_BRACVNKINGBADGA, Properties.TVRage.RESPONSE_SEARCHFULL_BRACVNKINGBADGA);

            Cache(SHOWINFO_18753, Properties.TVRage.RESPONSE_SHOWINFO_18753);
            Cache(SHOWINFO_842999999, Properties.TVRage.RESPONSE_SHOWINFO_842999999);

            Cache(EPISODEINFO_5481_2x13, Properties.TVRage.RESPONSE_EPISODEINFO_5481_2x13);
            Cache(EPISODEINFO_5481_99x99, Properties.TVRage.RESPONSE_EPISODEINFO_5481_99x99);
            Cache(EPISODEINFO_999999999_99x99, Properties.TVRage.RESPONSE_EPISODEINFO_999999999_99x99);

            Cache(EPISODELIST_15352, Properties.TVRage.RESPONSE_EPISODELIST_15352);
            Cache(EPISODELIST_20260, Properties.TVRage.RESPONSE_EPISODELIST_20260);

            Cache(FULLSHOWINFO_32517, Properties.TVRage.RESPONSE_FULLSHOWINFO_32517);
            Cache(FULLSHOWINFO_999999999, Properties.TVRage.RESPONSE_FULLSHOWINFO_999999999);
        }
     
    }
}