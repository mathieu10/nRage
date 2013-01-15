using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit.TVRage
{

    public class ShowListTests : TestBase
    {                
        [Fact]
        public void CanGetShowList()
        { 
            var response = client.GetShowList();
            Assert.True(response != null);
            Assert.True(response.Results.Count > 0);
        }

        [Fact]
        public void GetShowListCallsCorrectURL()
        { 
            client.GetShowList();
            Assert.True(MockRetriever.GetLastURLCalled() == TVRageMockRetriever.SHOWLIST);
        }

        [Fact]
        public void ShowListReturnsCorrectId()
        { 
            var response = client.GetShowList();
            Assert.True(response.Results.First().Id==1);
        }

        [Fact]
        public void ShowListReturnsCorrectName()
        { 
            var response = client.GetShowList();
            var result = response.Results.Where(x=>x.Id==2).Single();
            Assert.True(result.Name=="America 2Night");
        }

        [Fact]
        public void ShowListReturnsCorrectCountry()
        { 
            var response = client.GetShowList();
            var result = response.Results.Where(x=>x.Id==31).Single();
            Assert.True(result.Country=="AJ");
        }

        [Fact]
        public void ShowListReturnsCorrectShowName()
        { 
            var response = client.GetShowList();
            var result = response.Results.Where(x=>x.Id==23).Single();
            Assert.True(result.Status=="2");
        }

    }
}
