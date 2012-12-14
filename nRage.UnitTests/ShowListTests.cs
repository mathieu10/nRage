using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{

    public class ShowListTests : TVRageClientTestBase
    {                
        [Fact]
        public void CanGetShowList()
        { 
            var response = client.GetShowList();
            Assert.True(response != null);
            Assert.True(response.Results.Count > 0);
        }

        [Fact]
        public void ShowListReturnsCorrectID()
        { 
            var response = client.GetShowList();
            Assert.True(response.Results.First().ID==1);
        }

        [Fact]
        public void ShowListReturnsCorrectName()
        { 
            var response = client.GetShowList();
            var result = response.Results.Where(x=>x.ID==2).Single();
            Assert.True(result.Name=="America 2Night");
        }

        [Fact]
        public void ShowListReturnsCorrectCountry()
        { 
            var response = client.GetShowList();
            var result = response.Results.Where(x=>x.ID==31).Single();
            Assert.True(result.Country=="AJ");
        }

        [Fact]
        public void ShowListReturnsCorrectShowName()
        { 
            var response = client.GetShowList();
            var result = response.Results.Where(x=>x.ID==23).Single();
            Assert.True(result.Status=="2");
        }

    }
}
