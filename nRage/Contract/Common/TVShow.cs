using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nRage.Contract.Common {
    
    /// <summary>
    /// NOTE: This is not intended for use yet, just here to track ideas
    /// </summary>
    public class TVShow
    {
        public string ID{get;set;}
        public string Name{get;set;}
        public List<ExternalID> ExternalIDs{get;set;}
    }

    public class ExternalID
    {
        public enum DataSourceEnum{
            Unknown = -1,
            TVRage = 100,
            TheTVDB = 200,
        }

        public DataSourceEnum DataSource{get;set;}
        public string Value{get;set;}
    }

}
