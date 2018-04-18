using System;

namespace TestRide.Extensions
{
    public static class UnixTime
    {

        public static long ToUnixTime(this DateTime? date) => (date ?? DateTime.Now).ToUnixTime();

        // gets Unixtime from specific date
        public static long ToUnixTime(this DateTime date)
        {
            var unixTimestamp = (long)date.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            return unixTimestamp;
        }

        // Get unixtime NOW
        public static long Now()
        {
            return DateTime.Now.ToUnixTime();
        }

        // Gets today unixtime
        public static long Today()
        {
            return DateTime.Today.ToUnixTime();
        }

        // Gets the date from unixtime
        public static DateTime ToDate(this long? unixTime) => unixTime?.ToDate() ?? DateTime.Now;

        // Gets the date from unixtime
        public static DateTime ToDate(this long unixTime)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(unixTime);
        }
    }
}