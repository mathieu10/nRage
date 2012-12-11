using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using nRage.Contract.TVRage;

namespace nRage
{

    public class TVRageClient
    {
        private IRetriever Retriever { get; set; }


        public TVRageClient(IRetriever retriever) { this.Retriever = retriever; }

        protected string FormatURLParam(string param)
        {
            // TODO: any fancy formatting here (eg replace space with +, remove certain chars
            return param;
        }

        protected string GetSearchByTitleURL(string title) { return "http://services.tvrage.com/feeds/search.php?show=" + FormatURLParam(title); }

        public SearchResponse SearchByTitle(string title)
        {
            var result = new SearchResponse() {
                                                  Results = new List<SearchResult>()
                                              };

            var rawResults = XDocument.Load(Retriever.Get(GetSearchByTitleURL(title)));
            if (rawResults.Root == null || rawResults.Root.Value == "0") return result;

            //foreach (var rawResult in x.Results)
            //{
            //    var show = new SearchResult();
            //    show.ShowID = (int) rawResult.Attribute("showid");
            //    show.Name = (string) rawResult.Attribute("name");
            //    show.Link = (string) rawResult.Attribute("");
            //    show.Country = (string) rawResult.Attribute("");
            //    show.Started = (string) rawResult.Attribute("");
            //    show.Ended = (string) rawResult.Attribute("");
            //    show.Seasons = (string) rawResult.Attribute("");
            //    show.Status = (string) rawResult.Attribute("");
            //    show.Classification = (string) rawResult.Attribute("");
            //    show.Genres = new List<string>();
            //    foreach (var genre in rawResult.Descendants("genres"))
            //    {
            //        show.Genres.Add(genre.ToString());
            //    }
            
            return result;
        }
    }
}