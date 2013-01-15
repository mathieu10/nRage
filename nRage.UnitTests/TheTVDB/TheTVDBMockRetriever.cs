using nRage.Tests.Unit.Properties;

namespace nRage.Tests.Unit.TheTVDB
{
    public class TheTVDBMockRetriever : MockRetriever
    {
        #region URL constants
        public static readonly string MIRRORS = @"http://www.thetvdb.com/api/2A7162D6C1E477B0/mirrors.xml";
        public static readonly string SERVERTIME = @"http://www.thetvdb.com/api/Updates.php?type=none";
        public static readonly string EPISODELIST_81189 = @"http://www.thetvdb.com/api/2A7162D6C1E477B0/series/81189/all";
        public static readonly string EPISODELIST_1 = @"http://www.thetvdb.com/api/2A7162D6C1E477B0/series/1/all";
        public static readonly string GETSERIES_THEOFFICE = @"http://www.thetvdb.com/api/GetSeries.php?seriesname=the+Office";
        public static readonly string GETSERIES_SROTIJSRTRH = @"http://www.thetvdb.com/api/GetSeries.php?seriesname=SROTIJSRTRH";
        public static readonly string GETSERIESBYID_TT029097 = @"http://www.thetvdb.com/api/GetSeriesByRemoteId.php?imdbid=tt0290978";
        public static readonly string GETSERIESBYID_1 = @"http://www.thetvdb.com/api/GetSeriesByRemoteId.php?imdbid=1";
        public static readonly string SERIESINFO_81189 = @"http://www.thetvdb.com/api/2A7162D6C1E477B0/series/81189";
        public static readonly string SERIESINFO_1 = @"http://www.thetvdb.com/api/2A7162D6C1E477B0/series/1";
        public static readonly string UPDATES = @"http://www.thetvdb.com/api/Updates.php?type=all&time=";
        public static readonly string UPDATES_1355812429 = @"http://www.thetvdb.com/api/Updates.php?type=all&time=1355812429";        
        #endregion

        public TheTVDBMockRetriever() : base(){ }
        
        protected override void FillCache()
        { 
            Cache(MIRRORS, Properties.TheTVDB.RESPONSE_MIRRORS);
            Cache(SERVERTIME, Properties.TheTVDB.RESPONSE_UPDATES_NONE);
            Cache(EPISODELIST_81189, Properties.TheTVDB.RESPONSE_EPISODELIST_81189);
            Cache(EPISODELIST_1, Properties.TheTVDB.RESPONSE_EPISODELIST_1);
            Cache(GETSERIES_THEOFFICE, Properties.TheTVDB.RESPONSE_GETSERIES_THEOFFICE);
            Cache(GETSERIES_SROTIJSRTRH, Properties.TheTVDB.RESPONSE_GETSERIES_SROTIJSRTRH);
            Cache(GETSERIESBYID_1, Properties.TheTVDB.RESPONSE_GETSERIESBYID_1);
            Cache(GETSERIESBYID_TT029097, Properties.TheTVDB.RESPONSE_GETSERIESBYID_TT0290978);
            Cache(SERIESINFO_81189, Properties.TheTVDB.RESPONSE_SERIESINFO_81189);
            Cache(SERIESINFO_1, Properties.TheTVDB.RESPONSE_SERIESINFO_1);
            Cache(UPDATES_1355812429, Properties.TheTVDB.RESPONSE_UPDATES_ALL_1355812429);
        }
     
    }
}