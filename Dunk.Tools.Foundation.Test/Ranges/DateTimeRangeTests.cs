using System;
using Dunk.Tools.Foundation.Ranges;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Ranges
{
    [TestFixture]
    public class DateTimeRangeTests
    {
        private readonly DateTime _start = new DateTime(2021, 02, 15);
        private readonly DateTime _end = new DateTime(2021, 02, 20);

        [Test]
        public void DateTimeRangeInitialises()
        {
            var range = new DateTimeRange(_start, _end);
            Assert.IsNotNull(range);
        }

        [Test]
        public void DateTimeRangeThrowsIfStartDateIsAfterEndDate()
        {
            Assert.Throws<ArgumentException>(() =>
                new DateTimeRange(_end, _start));
        }

        [Test]
        public void DateTimeRangeIsWithinReturnsTrueIfDateIncluded()
        {
            DateTime testDate = new DateTime(2021, 02, 16);

            var range = new DateTimeRange(_start, _end);

            Assert.IsTrue(range.IsWithin(testDate));
        }

        [Test]
        public void DateTimeRangeIsWithinReturnsFalseIfDateIsBeforeStart()
        {
            DateTime testDate = new DateTime(2021, 02, 14);

            var range = new DateTimeRange(_start, _end);

            Assert.IsFalse(range.IsWithin(testDate));
        }

        [Test]
        public void DateTimeRangeIsWithinReturnsFalseIfDateIsAfterEnd()
        {
            DateTime testDate = new DateTime(2021, 02, 21);

            var range = new DateTimeRange(_start, _end);

            Assert.IsFalse(range.IsWithin(testDate));
        }

        [Test]
        public void DateTimeRangeIsWithinReturnsTrueIfStartDateAndEndDateIsIncluded()
        {
            var range = new DateTimeRange(_start, _end);

            Assert.IsTrue(range.IsWithin(new DateTimeRange(_start.AddDays(1), _end.AddDays(-1))));
        }

        [Test]
        public void DateTimeRangeIsWithinReturnsFalseIfRangeIsNull()
        {
            var range = new DateTimeRange(_start, _end);

            Assert.IsFalse(range.IsWithin(null as IRange<DateTime>));
        }

        [Test]
        public void DateTimeRangeIsWithinReturnsFalseIfStartDateIsBefore()
        {
            var range = new DateTimeRange(_start, _end);

            Assert.IsFalse(range.IsWithin(new DateTimeRange(_start.AddDays(-1), _end)));
        }

        [Test]
        public void DateTimeRangeIsWithinReturnsFalseIfEndDateIsAfter()
        {
            var range = new DateTimeRange(_start, _end);

            Assert.IsFalse(range.IsWithin(new DateTimeRange(_start, _end.AddDays(1))));
        }
    }
}
