using System;
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

            DateTime startOfDay = dt.GetStartOfDay(TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

            Assert.AreEqual(expected, startOfDay);
        }

        [Test]
        public void EndOfDayInSecondsReturnsOneSecondBeforeMidNight()
        {
            DateTime dt = new DateTime(2017, 02, 12, 14, 47, 01);
            DateTime expected = new DateTime(2017, 02, 12, 23, 59, 59);

            DateTime endOfDay = dt.GetEndOfDayInSeconds(TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

            Assert.AreEqual(expected, endOfDay);
        }

        [Test]
        public void EndOfDayInMilliSecondsReturnsOneMilliSecondBeforeMidNight()
        {
            DateTime dt = new DateTime(2017, 02, 12, 14, 47, 01);
            DateTime expected = new DateTime(2017, 02, 12, 23, 59, 59, 999);

            DateTime endOfDay = dt.GetEndOfDayInMilliSeconds(TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

            Assert.AreEqual(expected, endOfDay);
        }

        [Test]
        public void EndOfDayInTicksReturnsOneTickBeforeMidNight()
        {
            DateTime dt = new DateTime(2017, 02, 12, 14, 47, 01);
            DateTime expected = new DateTime(2017, 02, 12, 23, 59, 59, 999).AddTicks(9999);

            DateTime endOfDay = dt.GetEndOfDayInTicks(TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

            Assert.AreEqual(expected, endOfDay);
        }
    }
}
