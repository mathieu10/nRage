using nRage.Tests.Unit.Properties;

namespace nRage.Tests.Unit.TheTVDB
{
    public class TheTVDBMockRetriever : MockRetriever
    {
        #region URL constants
        public static readonly string MIRRORS = @"show_list.php";
        #endregion

        protected override void FillCache()
        { 
            Cache(MIRRORS, Properties.TheTVDB.RESPONSE_MIRRORS);
        }
     
    }
}