using System;
using System.Linq;
using Dunk.Tools.Foundation.Utilities;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Utilities
{
    [TestFixture]
    public class MonthEndExtractorTests
    {
        [Test]
        public void MonthEndExtractorGetsMonthEndsThrowsIfStartDateIsGreaterThanEndDate()
        {
            DateTime start = new DateTime(2018, 11, 27);
            DateTime end = new DateTime(2018, 08, 08);

            Assert.Throws<ArgumentException>(() => MonthEndExtractor.GetMonthEnds(start, end).ToList());
        }

        [Test]
        public void MonthEndExtractorGetsMonthEndsWeekdaysThrowsIfStartDateIsGreaterThanEndDate()
        {
            DateTime start = new DateTime(2018, 11, 27);
            DateTime end = new DateTime(2018, 08, 08);

            Assert.Throws<ArgumentException>(() => MonthEndExtractor.GetWeekdayMonthEnds(start, end).ToList());
        }

        [Test]
        public void MonthEndExtractorGetsMonthEndsWeekendsThrowsIfStartDateIsGreaterThanEndDate()
        {
            DateTime start = new DateTime(2018, 11, 27);
            DateTime end = new DateTime(2018, 08, 08);

            Assert.Throws<ArgumentException>(() => MonthEndExtractor.GetWeekendsMonthEnds(start, end).ToList());
        }

        [Test]
        public void MonthEndExtractorGetsMonthEnds()
        {
            DateTime start = new DateTime(2018, 08, 08);
            DateTime end = new DateTime(2018, 11, 27);

            var monthEnds = MonthEndExtractor.GetMonthEnds(start, end).ToList();

            Assert.IsNotNull(monthEnds);
            Assert.AreEqual(3, monthEnds.Count);
        }

        [Test]
        public void MonthEndExtractorGetsExpectedMonthEnds()
        {
            DateTime start = new DateTime(2018, 08, 08);
            DateTime end = new DateTime(2018, 11, 27);

            var monthEnds = MonthEndExtractor.GetMonthEnds(start, end).ToList();

            Assert.AreEqual(new DateTime(2018, 08, 31), monthEnds[0]);
            Assert.AreEqual(new DateTime(2018, 09, 30), monthEnds[1]);
            Assert.AreEqual(new DateTime(2018, 10, 31), monthEnds[2]);
        }

        [Test]
        public void MonthEndExtractorGetsMonthEndOccurringOnStartDate()
        {
            DateTime start = new DateTime(2018, 08, 31);
            DateTime end = new DateTime(2018, 11, 27);

            var monthEnds = MonthEndExtractor.GetMonthEnds(start, end).ToList();

            Assert.IsTrue(monthEnds.Contains(start));
        }

        [Test]
        public void MonthEndExtractorGetsMonthEndOccurringOnEndDate()
        {
            DateTime start = new DateTime(2018, 08, 08);
            DateTime end = new DateTime(2018, 11, 30);

            var monthEnds = MonthEndExtractor.GetMonthEnds(start, end).ToList();

            Assert.IsTrue(monthEnds.Contains(end));
        }

        [Test]
        public void MonthEndExtractorGetsMonthEndWeekdays()
        {
            DateTime start = new DateTime(2018, 08, 08);
            DateTime end = new DateTime(2018, 11, 27);

            var monthEnds = MonthEndExtractor.GetWeekdayMonthEnds(start, end).ToList();

            Assert.IsNotNull(monthEnds);
            Assert.AreEqual(2, monthEnds.Count);
        }

        [Test]
        public void MonthEndExtractorGetsExpectedMonthEndWeekdays()
        {
            DateTime start = new DateTime(2018, 08, 08);
            DateTime end = new DateTime(2018, 11, 27);

            var monthEnds = MonthEndExtractor.GetWeekdayMonthEnds(start, end).ToList();

            Assert.AreEqual(new DateTime(2018, 08, 31), monthEnds[0]);
            Assert.AreEqual(new DateTime(2018, 10, 31), monthEnds[1]);
        }


        [Test]
        public void MonthEndExtractorGetsMonthEndWeekends()
        {
            DateTime start = new DateTime(2018, 08, 08);
            DateTime end = new DateTime(2018, 11, 27);

            var monthEnds = MonthEndExtractor.GetWeekendsMonthEnds(start, end).ToList();

            Assert.IsNotNull(monthEnds);
            Assert.AreEqual(1, monthEnds.Count);
        }

        [Test]
        public void MonthEndExtractorGetsExpectedMonthEndWeekends()
        {
            DateTime start = new DateTime(2018, 08, 08);
            DateTime end = new DateTime(2018, 11, 27);

            var monthEnds = MonthEndExtractor.GetWeekendsMonthEnds(start, end).ToList();

            Assert.AreEqual(new DateTime(2018, 09, 30), monthEnds[0]);
        }
    }
}
