using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nRage
{
    public static class Helper
    {
        private static readonly DateTime DATETIME_EPOCH_ORIGIN = new DateTime(1970,1,1,0,0,0,0);

        public static DateTime ToDateTime(int unixTimestamp)
        {
            if(unixTimestamp < 0) 
                throw new ArgumentOutOfRangeException("unixTimestamp",unixTimestamp,"Timestamp must be greater than zero");
            return DATETIME_EPOCH_ORIGIN.AddSeconds(unixTimestamp);
        }

        public static int ToUnixTime(DateTime dateTime)
        {
            return (int)(dateTime - DATETIME_EPOCH_ORIGIN).TotalSeconds;
        }
    }
}
