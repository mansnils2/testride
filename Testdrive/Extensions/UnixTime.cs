using System;

namespace TestRide.Extensions
{
    public static class UnixTime
    {

        public static long ToUnixTime(this DateTime? date) => (date ?? DateTime.Now).ToUnixTime();

        // gets Unixtime from specific date
        public static long ToUnixTime(this DateTime date) =>
            (long) date.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;

        // Get unixtime NOW
        public static long Now() => DateTime.Now.ToUnixTime();

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