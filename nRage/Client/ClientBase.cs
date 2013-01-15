using System.Xml.Linq;

namespace nRage.Client
{
    public abstract class ClientBase
    {
        public ClientBase() : this(new WebRetriever()){}

        public ClientBase(IRetriever retriever) {
            this.Retriever = retriever;
            Initialise();
        }

        protected virtual void Initialise(){}

        protected IRetriever Retriever {get; set;}
        
        public abstract string ApiRoot{get;}

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