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

    public class TheTVDBClient : ClientBase
    {
        public TheTVDBClient(IRetriever retriever) : base(retriever) { }

        #region URL generation                        
        public override string ApiRoot { get { return @"http://www.thetvdb.com/api"; } }
        private const string API_KEY = @"2A7162D6C1E477B0";

        private string GetURLForMirrors() { return GetURL(@"{0}/mirrors.xml", API_KEY); }
        #endregion

        #region Public methods        
        public MirrorsResponse GetMirrors()
        {
            var response = GetXML(GetURLForMirrors());
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