using System.IO;
using System.Net;
using System.Xml.Linq;

namespace nRage.Interface
{
    // This may eventually support a combination of local cache (in-memory? DB? etc) and web look-up.    

    public interface IRetriever
    {
        Stream Get(string address);
    }

    public class WebRetriever : IRetriever
    {
        public Stream Get(string url) {  
            var web = new WebClient();
            return web.OpenRead(url);
        }
    }    
}