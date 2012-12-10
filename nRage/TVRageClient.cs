using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using nRage.Contract.TVRage;

namespace nRage {
    public class TVRageClient {

        protected string FormatURLParam(string param) { 
            // TODO: any fancy formatting here (eg replace space with +, remove certain chars
            return param;
        }

        protected string GetSearchByTitleURL(string title ) { 
            return "http://services.tvrage.com/feeds/search.php?show=" + FormatURLParam(title); 
        }

        public ShowSearchResponse SearchByTitle(string title) {            
            var result = new ShowSearchResponse();
            var rawResults = XDocument.Load(GetSearchByTitleURL(title));

            if (rawResults.Root == null || rawResults.Root.Value == "0")
            {

            }

            //foreach(var rawResult in rawResults.
            return result;
        }
    }
}
