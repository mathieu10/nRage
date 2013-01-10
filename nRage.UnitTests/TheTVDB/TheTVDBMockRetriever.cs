using nRage.Tests.Unit.Properties;

namespace nRage.Tests.Unit.TheTVDB
{
    public class TheTVDBMockRetriever : MockRetriever
    {
        #region URL constants
        public static readonly string MIRRORS = @"mirrors.xml";
        public static readonly string SERVERTIME = @"Updates.php?type=none";
        public static readonly string EPISODELIST = @"mxml";
        public static readonly string SEARCH = @"mir.xml";
        public static readonly string SERIESINFO = @"ml";
        public static readonly string UPDATES = @"Updates.php?type=all&time=";
        public static readonly string UPDATES_123412341 = @"Updates.php?type=all&time=123412341";
        
        #endregion

        public TheTVDBMockRetriever() : base(){
            
        }
        
        protected override void FillCache()
        { 
            Cache(MIRRORS, Properties.TheTVDB.RESPONSE_MIRRORS);
            Cache(SERVERTIME, Properties.TheTVDB.RESPONSE_UPDATES_NONE);
            Cache(EPISODELIST, Properties.TheTVDB.RESPONSE_EPISODELIST_81189);
            //Cache(SEARCH, Properties.TheTVDB.RESPONSE_SEARCH);
            Cache(SERIESINFO, Properties.TheTVDB.RESPONSE_SERIESINFO_81189);
            Cache(UPDATES_123412341, Properties.TheTVDB.RESPONSE_UPDATES_ALL_123412341);
        }
     
    }
}