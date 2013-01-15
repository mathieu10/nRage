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
        public string Id{get;set;}
        public string Name{get;set;}
        public List<ExternalId> ExternalIds{get;set;}
    }

    public class ExternalId
    {
        public enum DataSourceEnum{
            Unknown = -1,
            Tvrage = 100,
            Tvdb = 200,
        }

        public DataSourceEnum DataSource{get;set;}
        public string Value{get;set;}
    }

}
