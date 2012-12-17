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
        private readonly TimeSpan span_4hours = new TimeSpan(0,4,0,0);
        private readonly TimeSpan span_1day = new TimeSpan(1,0,0,0);
        private readonly TimeSpan span_41days_15hours = new TimeSpan(41,15,0,0);
        private readonly TimeSpan span_999hours = new TimeSpan(0,999,0,0);

        [Fact]
        public void CanGetLastUpdates()
        {
            var response = client.LastUpdates(span_4hours);
            Assert.True(response != null);
        }

        [Fact]
        public void GetLastUpdatesCallsCorrectURL()
        { 
            client.LastUpdates();
            Assert.True(MockRetriever.GetLastURLCalled() == MockRetriever.LASTUPDATES);
        }

        [Fact]
        public void GetLastUpdatesByTimespanInHoursCallsCorrectURL()
        { 
            client.LastUpdates(span_4hours);
            Assert.True(MockRetriever.GetLastURLCalled() == MockRetriever.LASTUPDATES_4);
        }

        [Fact]
        public void GetLastUpdatesByTimespanInDaysCallsCorrectURL()
        { 
            client.LastUpdates(span_1day);
            Assert.True(MockRetriever.GetLastURLCalled() == MockRetriever.LASTUPDATES_24);
        }

        [Fact]
        public void GetLastUpdatesByTimespanInDaysAndHoursCallsCorrectURL()
        { 
            client.LastUpdates(span_41days_15hours);
            Assert.True(MockRetriever.GetLastURLCalled() == MockRetriever.LASTUPDATES_999);
        }

        [Fact]
        public void GetLastUpdatesByTimespanInMoreThan24HoursCallsCorrectURL()
        { 
            client.LastUpdates(span_999hours);
            Assert.True(MockRetriever.GetLastURLCalled() == MockRetriever.LASTUPDATES_999);
        }

        [Fact]
        public void GetLastUpdatesReturnsCorrectTimestamp()
        { 
            var response = client.LastUpdates(span_4hours);
            Assert.True(response.Timestamp == "1355720878");
        }

        [Fact]
        public void GetLastUpdatesReturnsCorrectUpdatesCount()
        { 
            var response = client.LastUpdates(span_4hours);
            Assert.True(response.UpdatesCount == "26");
        }

        [Fact]
        public void GetLastUpdatesReturnsCorrectSorting()
        { 
            var response = client.LastUpdates(span_4hours);
            Assert.True(response.Sorting == "latest_updates");
        }

        [Fact]
        public void GetLastUpdatesReturnsCorrectShowingPeriod()
        { 
            var response = client.LastUpdates(span_4hours);
            Assert.True(response.ShowingPeriod == "Last 4H");
        }

        [Fact]
        public void GetLastUpdatesReturnsCorrectShowID()
        { 
            var response = client.LastUpdates(span_4hours);
            Assert.True(response.Shows.ElementAt(0).ShowID == 31);
        }

        [Fact]
        public void GetLastUpdatesReturnsCorrectShowLast()
        { 
            var response = client.LastUpdates(span_4hours);
            Assert.True(response.Shows.ElementAt(0).Last == "-622");
        }

        [Fact]
        public void GetLastUpdatesReturnsCorrectShowLastEpisode()
        { 
            var response = client.LastUpdates(span_4hours);
            Assert.True(response.Shows.ElementAt(0).LatestEpisode == "950340");
        }


    }
}
