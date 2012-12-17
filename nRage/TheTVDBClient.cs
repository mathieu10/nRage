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
using nRage.Contract.TVRage;

namespace nRage {

    public class TheTVDBClient {
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
        #endregion

        #region Public methods        
        #endregion

        #region OXM (Object-XML Mapper) - because the software world needs more acronyms       
        #endregion
                 
    }    
}