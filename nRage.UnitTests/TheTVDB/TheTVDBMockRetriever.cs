using nRage.Tests.Unit.Properties;

namespace nRage.Tests.Unit.TheTVDB
{
    public class TheTVDBMockRetriever : MockRetriever
    {
        #region URL constants
        public static readonly string MIRRORS = @"mirrors.xml";
        public static readonly string SERVERTIME = @"mirrors.xml";
        public static readonly string EPISODELIST = @"mirrors.xml";
        public static readonly string SEARCH = @"mirrors.xml";
        public static readonly string SERIESINFO = @"mirrors.xml";
        public static readonly string UPDATES = @"mirrors.xml";
        #endregion

        public TheTVDBMockRetriever() : base(){
            
        }
        
        protected override void FillCache()
        { 
            Cache(MIRRORS, Properties.TheTVDB.RESPONSE_MIRRORS);
        }
     
    }
}