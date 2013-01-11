using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Xml.Linq;

namespace nRage.Tests.Unit
{    
    public abstract class MockRetriever : IRetriever
    {
        private Dictionary<string, string> _mockResults;               
        private static Stack<string> _urlHistory{get; set;}

        public MockRetriever()
        {               
            _urlHistory = new Stack<string>();
            _mockResults = new Dictionary<string, string>();

            FillCache();
        }

        protected abstract void FillCache();
        protected void Cache(string key,string value){
            _mockResults[key] = value;
        }

        public static string GetLastURLCalled(){
            return _urlHistory.Pop();
        }

        public Stream Get(string url)
        {
            Debug.WriteLine("MockRetriever getting URL: " + url);
            
            _urlHistory.Push(url);

            string value = _mockResults[url];
            byte[] byteArray = Encoding.UTF8.GetBytes(value);
            return new MemoryStream(byteArray);
        }        
    }

}
