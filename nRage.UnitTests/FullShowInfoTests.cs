using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{

    public class FullShowInfoTests : TVRageClientTestBase
    {                
        private const int showId = 0;

        [Fact]
        public void CanGetFullShowInfo()
        { 
            var response = client.GetFullShowInfo(showId);
            Assert.True(response != null);
        }

    }
}
