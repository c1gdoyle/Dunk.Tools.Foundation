using System;
using System.Linq;
using Dunk.Tools.Foundation.Utilities;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Utilities
{
    [TestFixture]
    public class YearEndExtractorTests
    {
        [Test]
        public void YearEndExtractorGetYearEndsThrowsIfEndDateIsGreaterThanStartDate()
        {
            DateTime start = new DateTime(2018, 11, 27);
            DateTime end = new DateTime(2006, 08, 08);

            Assert.Throws<ArgumentException>(() => YearEndExtractor.GetYearEnds(start, end).ToList());
        }

        [Test]
        public void YearEndExtractorGetYearEndsWeekdaysThrowsIfEndDateIsGreaterThanStartDate()
        {
            DateTime start = new DateTime(2018, 11, 27);
            DateTime end = new DateTime(2006, 08, 08);

            Assert.Throws<ArgumentException>(() => YearEndExtractor.GetWeekdayYearEnds(start, end).ToList());
        }

        [Test]
        public void YearEndExtractorGetYearEndsWeekendsThrowsIfEndDateIsGreaterThanStartDate()
        {
            DateTime start = new DateTime(2018, 11, 27);
            DateTime end = new DateTime(2006, 08, 08);

            Assert.Throws<ArgumentException>(() => YearEndExtractor.GetWeekendsYearEnds(start, end).ToList());
        }

        [Test]
        public void YearEndExtractorGetsYearEnds()
        {
            DateTime start = new DateTime(2008, 08, 08);
            DateTime end = new DateTime(2018, 11, 27);

            var yearEnds = YearEndExtractor.GetYearEnds(start, end).ToList();

            Assert.IsNotNull(yearEnds);
            Assert.AreEqual(10, yearEnds.Count);
        }

        [Test]
        public void YearEndExtractorGetsYearEndOccurringOnStartDate()
        {
            DateTime start = new DateTime(2008, 12, 31);
            DateTime end = new DateTime(2018, 11, 27);

            var yearEnds = YearEndExtractor.GetYearEnds(start, end).ToList();

            Assert.IsTrue(yearEnds.Contains(start));
        }

        [Test]
        public void YearEndExtractorGetsYearEndOccurringOnEndDate()
        {
            DateTime start = new DateTime(2008, 08, 08);
            DateTime end = new DateTime(2018, 12, 31);

            var yearEnds = YearEndExtractor.GetYearEnds(start, end).ToList();

            Assert.IsTrue(yearEnds.Contains(end));
        }

        [Test]
        public void YearEndExtractorGetsWeekdayYearEnds()
        {
            DateTime start = new DateTime(2008, 08, 08);
            DateTime end = new DateTime(2018, 11, 27);

            var yearEnds = YearEndExtractor.GetWeekdayYearEnds(start, end).ToList();

            Assert.IsNotNull(yearEnds);
            Assert.AreEqual(7, yearEnds.Count);
        }

        [Test]
        public void YearEndExtractorGetsWeekendYearEnds()
        {
            DateTime start = new DateTime(2008, 08, 08);
            DateTime end = new DateTime(2018, 11, 27);

            var yearEnds = YearEndExtractor.GetWeekendsYearEnds(start, end).ToList();

            Assert.IsNotNull(yearEnds);
            Assert.AreEqual(3, yearEnds.Count);
        }
    }
}
