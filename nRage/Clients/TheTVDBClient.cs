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
        /// <TODO>
        /// This should - in theory - be configurable to support mirrors. In practice... well... there's never any mirrors.
        /// </TODO>
        private const string API_ROOT = @"http://www.thetvdb.com/api/";
        private readonly string API_KEY = Common.APIKEY_THETVDB;
        
        protected string FormatURLParam(string param) {
            return new string(param.Where(c => char.IsLetterOrDigit(c)).ToArray());
        }

        private string GetURLForMirrors() {
            return String.Format(@"{0}{1}/mirrors.xml", API_ROOT, API_KEY);
        }
        #endregion

        #region Public methods        
        public MirrorsResponse GetMirrors()
        {
            var response = XDocument.Load(Retriever.Get(GetURLForMirrors()));
            return MapXMLToMirrors(response);            
        }
        #endregion

        #region OXM (Object-XML Mapper) - because the software world needs more acronyms
         private MirrorsResponse MapXMLToMirrors(XDocument xml) {
            return new MirrorsResponse {
                Mirrors = xml.Descendants("Mirror").Select(x => new Mirror{
                    ID = (int)x.Element("id"),
                    MirrorPath = (string)x.Element("mirrorpath"),
                    TypeMask = (byte)(int)x.Element("typemask"),
                }).ToList(),
            };
        }
        #endregion
                 
    }

}