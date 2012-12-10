using System.IO;

namespace nRage
{
    // This may eventually support a combination of local cache (in-memory? DB? etc) and web look-up.    

    public interface IRetriever
    {
        Stream Get(string address);
    }

    public class WebRetriever : IRetriever
    {
        public Stream Get(string url) { throw new System.NotImplementedException(); }
    }    
}