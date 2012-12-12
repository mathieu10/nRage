using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{

    public class ShowInfoTests : TestBase
    {            
        private const int show_id = 18753;
        private const int nonexistent_show_id = 842999999;

        private TVRageClient client;

        public ShowInfoTests()
        {
            client = _ioc.Get<TVRageClient>();
        }

        [Fact]
        public void CanGetShowInfoByShowID()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response != null);
        }

        [Fact]
        public void GetShowInfoThrowsWhenInvalidShowID()
        { 
            var response = client.GetShowInfo(nonexistent_show_id);
            Assert.True(response != null);
        }

    }
}
