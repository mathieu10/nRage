using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit.TheTVDB
{
    public class SearchTests : TestBase
    {      
        public SearchTests() : base(){}
          
        [Fact]
        public void CanGetSearch()
        { 
            var response = client.Search("");
            Assert.True(response != null);
        }

        [Fact]
        public void GetSearchCallsCorrectURL()
        { 
            client.Search("");
            Assert.True(MockRetriever.GetLastURLCalled() == TheTVDBMockRetriever.SEARCH);
        }

        [Fact]
        public void GetSearchReturnsCorrectX()
        {
            var response = client.Search("");
            Assert.False(true);
        }

    }
}
