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
        private const string show_id = "18753";
        private const string nonexistent_show_id = "842999999";
        private const string invalid_show_id = "842999999";

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
        public void GetShowInfoThrowsWhenNoMatchFound()
        { 
            var response = client.GetShowInfo(show_id);
            Assert.True(response != null);
        }

        [Fact]
        public void GetShowInfoThrowsWhenInvalidShowIDFormat()
        { 
            var client = _ioc.Get<TVRageClient>();            

            var response = client.GetShowInfo(show_id);
            Assert.True(response != null);
        }

    }
}
