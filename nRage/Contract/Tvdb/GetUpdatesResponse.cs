using System.Collections.Generic;

namespace nRage.Contract.Tvdb
{
    public class GetUpdatesResponse
    {
        public string Time{get;set;}
        public List<string> Series {get;set;}
    }
}