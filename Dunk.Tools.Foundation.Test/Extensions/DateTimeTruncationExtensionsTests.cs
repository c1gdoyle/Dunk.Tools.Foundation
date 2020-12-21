using System;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class DateTimeTruncationExtensionsTests
    {
        [Test]
        public void DateTimeTruncatesToDay()
        {
            DateTime expected = new DateTime(2018, 01, 01, 00, 00, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 01, 12, 23, DateTimeKind.Utc);

            DateTime result = dt.TruncateToDay();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeTruncateToDayPreservesDateTimeKind()
        {
            DateTime dt = new DateTime(2018, 01, 01, 01, 12, 23, DateTimeKind.Utc);

            DateTime result = dt.TruncateToDay();

            Assert.AreEqual(DateTimeKind.Utc, result.Kind);
        }

        [Test]
        public void DateTimeTruncatesToHour()
        {
            DateTime expected = new DateTime(2018, 01, 01, 01, 00, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 01, 12, 23, DateTimeKind.Utc);

            DateTime result = dt.TruncateToHour();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeTruncateToHourPreservesDateTimeKind()
        {
            DateTime dt = new DateTime(2018, 01, 01, 01, 12, 23, DateTimeKind.Utc);

            DateTime result = dt.TruncateToHour();

            Assert.AreEqual(DateTimeKind.Utc, result.Kind);
        }

        [Test]
        public void DateTimeTruncatesToMinute()
        {
            DateTime expected = new DateTime(2018, 01, 01, 01, 12, 00, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 01, 12, 23, DateTimeKind.Utc);

            DateTime result = dt.TruncateToMinute();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeTruncateToMinutePreservesDateTimeKind()
        {
            DateTime dt = new DateTime(2018, 01, 01, 01, 12, 23, DateTimeKind.Utc);

            DateTime result = dt.TruncateToMinute();

            Assert.AreEqual(DateTimeKind.Utc, result.Kind);
        }

        [Test]
        public void DateTimeTruncatesToSecond()
        {
            DateTime expected = new DateTime(2018, 01, 01, 01, 12, 23, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 01, 12, 23, DateTimeKind.Utc);

            DateTime result = dt.TruncateToSecond();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeTruncateToSecondPreservesDateTimeKind()
        {
            DateTime dt = new DateTime(2018, 01, 01, 01, 12, 23, DateTimeKind.Utc);

            DateTime result = dt.TruncateToSecond();

            Assert.AreEqual(DateTimeKind.Utc, result.Kind);
        }

        [Test]
        public void DateTimeTruncatesToMilliSecond()
        {
            DateTime expected = new DateTime(2018, 01, 01, 01, 12, 23, 22, DateTimeKind.Utc);

            DateTime dt = new DateTime(2018, 01, 01, 01, 12, 23, 22, DateTimeKind.Utc);

            DateTime result = dt.TruncateToMilliSecond();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DateTimeTruncateToMilliSecondPreservesDateTimeKind()
        {
            DateTime dt = new DateTime(2018, 01, 01, 01, 12, 23, 22, DateTimeKind.Utc);

            DateTime result = dt.TruncateToMilliSecond();

            Assert.AreEqual(DateTimeKind.Utc, result.Kind);
        }

        [Test]
        public void DateTimeTruncateReturnsOriginalDateTimeIfTimeSpanIsZero()
        {
            DateTime dt = new DateTime(2018, 01, 01, 01, 12, 23, 22, DateTimeKind.Utc);

            DateTime result = dt.Truncate(TimeSpan.Zero);

            Assert.AreEqual(dt, result);
        }
    }
}
