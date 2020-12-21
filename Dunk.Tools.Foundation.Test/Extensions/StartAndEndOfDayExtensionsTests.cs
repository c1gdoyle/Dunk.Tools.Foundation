using System;
using System.Runtime.InteropServices;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class StartAndEndOfDayExtensionsTests
    {
        [Test]
        public void StartOfDayReturnsMidNight()
        {
            DateTime dt = new DateTime(2017, 02, 12, 14, 47, 01);
            DateTime expected = new DateTime(2017, 02, 12, 00, 00, 0);

            DateTime startOfDay = dt.GetStartOfDay(GetTestTimeZone());

            Assert.AreEqual(expected, startOfDay);
        }

        [Test]
        public void EndOfDayInSecondsReturnsOneSecondBeforeMidNight()
        {
            DateTime dt = new DateTime(2017, 02, 12, 14, 47, 01);
            DateTime expected = new DateTime(2017, 02, 12, 23, 59, 59);

            DateTime endOfDay = dt.GetEndOfDayInSeconds(GetTestTimeZone());

            Assert.AreEqual(expected, endOfDay);
        }

        [Test]
        public void EndOfDayInMilliSecondsReturnsOneMilliSecondBeforeMidNight()
        {
            DateTime dt = new DateTime(2017, 02, 12, 14, 47, 01);
            DateTime expected = new DateTime(2017, 02, 12, 23, 59, 59, 999);

            DateTime endOfDay = dt.GetEndOfDayInMilliSeconds(GetTestTimeZone());

            Assert.AreEqual(expected, endOfDay);
        }

        [Test]
        public void EndOfDayInTicksReturnsOneTickBeforeMidNight()
        {
            DateTime dt = new DateTime(2017, 02, 12, 14, 47, 01);
            DateTime expected = new DateTime(2017, 02, 12, 23, 59, 59, 999).AddTicks(9999);

            DateTime endOfDay = dt.GetEndOfDayInTicks(GetTestTimeZone());

            Assert.AreEqual(expected, endOfDay);
        }

        private TimeZoneInfo GetTestTimeZone()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
            }
            return null;
        }
    }
}
