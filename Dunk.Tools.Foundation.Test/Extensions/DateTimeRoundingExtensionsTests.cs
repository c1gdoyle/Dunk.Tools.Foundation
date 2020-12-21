using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class DateTimeRoundingExtensionsTests
    {
        [Test]
        public void DateTimeRoundsDownToNearestDay()
        {
            DateTime expected = new DateTime(2018, 01, 01, 00, 00, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 59, 59, DateTimeKind.Utc);

            DateTime result = dt.RoundToNearestDay();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsUpToNearestDay()
        {
            DateTime expected = new DateTime(2018, 01, 02, 00, 00, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 12, 00, 01, DateTimeKind.Utc);

            DateTime result = dt.RoundToNearestDay();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsUpToNearestDayOnMidpoint()
        {
            DateTime expected = new DateTime(2018, 01, 02, 00, 00, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 12, 00, 00, DateTimeKind.Utc);

            DateTime result = dt.RoundToNearestDay();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsDownToNearestHour()
        {
            DateTime expected = new DateTime(2018, 01, 01, 11, 00, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 29, 59, DateTimeKind.Utc);

            DateTime result = dt.RoundToNearestHour();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsUpToNearestHour()
        {
            DateTime expected = new DateTime(2018, 01, 01, 12, 00, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 30, 01, DateTimeKind.Utc);

            DateTime result = dt.RoundToNearestHour();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsUpToNearestHourOnMidpoint()
        {
            DateTime expected = new DateTime(2018, 01, 01, 12, 00, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 30, 00, DateTimeKind.Utc);

            DateTime result = dt.RoundToNearestHour();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsDownToNearestMinute()
        {
            DateTime expected = new DateTime(2018, 01, 01, 11, 00, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 00, 29, DateTimeKind.Utc);

            DateTime result = dt.RoundToNearestMinute();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsUpToNearestMinute()
        {
            DateTime expected = new DateTime(2018, 01, 01, 11, 01, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 00, 31, DateTimeKind.Utc);

            DateTime result = dt.RoundToNearestMinute();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsUpToNearestMinuteOnMidpoint()
        {
            DateTime expected = new DateTime(2018, 01, 01, 11, 01, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 00, 30, DateTimeKind.Utc);

            DateTime result = dt.RoundToNearestMinute();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsDownToNearestSecond()
        {
            DateTime expected = new DateTime(2018, 01, 01, 11, 01, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 01, 00, DateTimeKind.Utc).AddMilliseconds(499);

            DateTime result = dt.RoundToNearestSecond();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsUpToNearestSecond()
        {
            DateTime expected = new DateTime(2018, 01, 01, 11, 01, 01, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 01, 00, DateTimeKind.Utc).AddMilliseconds(501);

            DateTime result = dt.RoundToNearestSecond();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsUpToNearestSecondOnMidpoint()
        {
            DateTime expected = new DateTime(2018, 01, 01, 11, 01, 01, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 01, 00, DateTimeKind.Utc).AddMilliseconds(500);

            DateTime result = dt.RoundToNearestSecond();

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void DateTimeRoundsDownToNearestMilliSecond()
        {
            DateTime expected = new DateTime(2018, 01, 01, 11, 01, 01, 01, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 01, 01, 01, DateTimeKind.Utc).AddTicks(4998);

            DateTime result = dt.RoundToNearestMilliSecond();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsUpToNearestMilliSecond()
        {
            DateTime expected = new DateTime(2018, 01, 01, 11, 01, 01, 02, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 01, 01, 01, DateTimeKind.Utc).AddTicks(5001);

            DateTime result = dt.RoundToNearestMilliSecond();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundsUpToNearestMilliSecondOnMidpoint()
        {
            DateTime expected = new DateTime(2018, 01, 01, 11, 01, 01, 02, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 11, 01, 01, 01, DateTimeKind.Utc).AddTicks(5000);

            DateTime result = dt.RoundToNearestMilliSecond();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeRoundReturnsOriginalDateTimeIfTimeSpanIsZero()
        {
            DateTime dt = new DateTime(2018, 01, 01, 01, 12, 23, 22, DateTimeKind.Utc).AddTicks(123);

            DateTime result = dt.Round(TimeSpan.Zero);

            Assert.AreEqual(dt, result);
        }
    }
}