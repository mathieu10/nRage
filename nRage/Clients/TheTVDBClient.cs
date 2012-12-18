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
        /// <TODO>
        /// This should - in theory - be configurable to support mirrors. In practice... well... there's never any mirrors.
        /// </TODO>
        public override string ApiRoot {
            get { return @"http://www.thetvdb.com/api"; }
        }

        #region URL generation                        
        private const string API_KEY = @"2A7162D6C1E477B0";

        private string GetURLForMirrors() {
            return GetURL(@"{1}/mirrors.xml", API_KEY);
        }
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