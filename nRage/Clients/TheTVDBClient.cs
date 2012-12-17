using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using nRage.Contract.TheTVDB;

namespace nRage.Clients {

    public class TheTVDBClient
    {
        private const string API_KEY = "2A7162D6C1E477B0";

        private IRetriever Retriever {get;set;}

        public TheTVDBClient() {
            this.Retriever = new WebRetriever();
        }

        public TheTVDBClient(IRetriever retriever) {
            this.Retriever = retriever;
        }

        // API Key
        // Mirror

        #region URL generation                
        //http://www.thetvdb.com/api/<apikey>/mirrors.xml. 
        #endregion

        #region Public methods        
        public List<Mirror> GetMirrors()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region OXM (Object-XML Mapper) - because the software world needs more acronyms       
        #endregion
                 
    }

}