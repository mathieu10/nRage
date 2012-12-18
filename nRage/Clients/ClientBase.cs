using System.Xml.Linq;

namespace nRage.Clients
{
    public abstract class ClientBase
    {
        protected IRetriever Retriever {get; set;}
        
        public string ApiRoot{get; protected set;}

        protected string GetURL(string format, params object[] args)
        {
            var apiMethod = string.Format(format,args);
            return string.Format(@"{0}/{1}",ApiRoot,apiMethod);
        }

        protected XDocument GetXML(string path)
        {
            return XDocument.Load(Retriever.Get(path));
        }

    }
}