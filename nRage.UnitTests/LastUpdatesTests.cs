using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{

    public class LastUpdatesTests : TVRageClientTestBase
    {        
        [Fact]
        public void CanGetLastUpdatesByTimeSpanInHours()
        { 
            var timeSpan = new TimeSpan(0,12,0,0);
            var response = client.LastUpdates(timeSpan);
            Assert.True(response != null);
        }        

        [Fact]
        public void CanGetLastUpdatesByTimeSpanInDays()
        { 
            var timeSpan = new TimeSpan(0,12,0,0);
            var response = client.LastUpdates(timeSpan);
            Assert.True(response != null);
        }

        [Fact]
        public void CanGetLastUpdatesByTimeSpanInDaysAndHours()
        { 
            var timeSpan = new TimeSpan(0,12,0,0);
            var response = client.LastUpdates(timeSpan);
            Assert.True(response != null);
        }

        [Fact]
        public void CanGetLastUpdatesByStartTime()
        { 
            var timeSpan = new TimeSpan(0,12,0,0);
            var response = client.LastUpdates(timeSpan);
            Assert.True(response != null);
        }
    }
}
