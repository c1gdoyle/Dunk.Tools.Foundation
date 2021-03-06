using System;
using System.Linq;
using Dunk.Tools.Foundation.Utilities;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Utilities
{
    [TestFixture]
    public class DateRangeSplitterTests
    {
        [Test]
        public void SplitsDateRangeThrowIfEndDateIsGreaterThanStartDate()
        {
            DateTime start = new DateTime(2018, 02, 25);
            DateTime end = new DateTime(2018, 01, 01);
            int batchSize = 7;

            Assert.Throws<ArgumentException>(() => DateRangeSplitter.SplitDateRange(start, end, batchSize).ToList());
        }

        [Test]
        public void SplitsDateRangeThrowsIfBatchSizeIsZero()
        {
            DateTime start = new DateTime(2018, 01, 01);
            DateTime end = new DateTime(2018, 02, 25);
            int batchSize = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => DateRangeSplitter.SplitDateRange(start, end, batchSize).ToList());
        }

        [Test]
        public void SplitsDateRangeThrowsIfBatchSizeIsNegative()
        {
            DateTime start = new DateTime(2018, 01, 01);
            DateTime end = new DateTime(2018, 02, 25);
            int batchSize = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => DateRangeSplitter.SplitDateRange(start, end, batchSize).ToList());
        }

        [Test]
        public void SplitDateRangeSplitsDatesIntoBatches()
        {
            DateTime start = new DateTime(2018, 01, 01);
            DateTime end = new DateTime(2018, 02, 25);
            int batchSize = 7;

            var batches = DateRangeSplitter.SplitDateRange(start, end, batchSize).ToList();

            Assert.AreEqual(7, batches.Count);
        }

        [Test]
        public void SplitDateRangeSplitsDateIntoExpectedStartBatch()
        {
            DateTime start = new DateTime(2018, 01, 01);
            DateTime end = new DateTime(2018, 02, 25);
            int batchSize = 7;

            var batches = DateRangeSplitter.SplitDateRange(start, end, batchSize).ToList();

            var firstBatch = batches[0];

            Assert.AreEqual(new DateTime(2018, 01, 01), firstBatch.Item1);
            Assert.AreEqual(new DateTime(2018, 01, 08), firstBatch.Item2);
        }


        [Test]
        public void SplitDateRangeSplitsDateIntoExpectedEndBatch()
        {
            DateTime start = new DateTime(2018, 01, 01);
            DateTime end = new DateTime(2018, 02, 25);
            int batchSize = 7;

            var batches = DateRangeSplitter.SplitDateRange(start, end, batchSize).ToList();

            var lastBatch = batches[batches.Count - 1];

            Assert.AreEqual(new DateTime(2018, 02, 18), lastBatch.Item1);
            Assert.AreEqual(new DateTime(2018, 02, 25), lastBatch.Item2);
        }

        [Test]
        public void SplitDateRangeSplitsDatesIntoExpectedEndBatchIfBatchIsSmallerThanBatchSize()
        {
            DateTime start = new DateTime(2018, 01, 01);
            DateTime end = new DateTime(2018, 02, 26);
            int batchSize = 7;

            var batches = DateRangeSplitter.SplitDateRange(start, end, batchSize).ToList();

            var lastBatch = batches[batches.Count - 1];

            Assert.AreEqual(new DateTime(2018, 02, 26), lastBatch.Item1);
            Assert.AreEqual(new DateTime(2018, 02, 26), lastBatch.Item2);
        }

        [Test]
        public void SplitDateRangeReturnsSingleBatchIfRangeIsLessThanBatchSize()
        {
            DateTime start = new DateTime(2018, 01, 01);
            DateTime end = new DateTime(2018, 01, 05);
            int batchSize = 7;

            var batches = DateRangeSplitter.SplitDateRange(start, end, batchSize).ToList();

            Assert.AreEqual(1, batches.Count);
            Assert.AreEqual(new DateTime(2018, 01, 01), batches[0].Item1);
            Assert.AreEqual(new DateTime(2018, 01, 05), batches[0].Item2);
        }

        [Test]
        public void SplitsDateRangeWeekdaysThrowIfEndDateIsGreaterThanStartDate()
        {
            DateTime start = new DateTime(2018, 02, 25);
            DateTime end = new DateTime(2018, 01, 01);
            int batchSize = 7;

            Assert.Throws<ArgumentException>(() => DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList());
        }

        [Test]
        public void SplitsDateRangeWeekdaysThrowsIfBatchSizeIsZero()
        {
            DateTime start = new DateTime(2018, 01, 01);
            DateTime end = new DateTime(2018, 02, 25);
            int batchSize = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList());
        }

        [Test]
        public void SplitsDateRangeWeekdaysThrowsIfBatchSizeIsNegative()
        {
            DateTime start = new DateTime(2018, 01, 01);
            DateTime end = new DateTime(2018, 02, 25);
            int batchSize = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList());
        }

        [Test]
        public void SplitsDateRangeWeekdaysThrowsIfBatchSizeIsGreaterThanFice()
        {
            DateTime start = new DateTime(2018, 01, 01);
            DateTime end = new DateTime(2018, 02, 25);
            int batchSize = 6;

            Assert.Throws<ArgumentOutOfRangeException>(() => DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList());
        }

        [Test]
        public void SplitsDateRangeWeekdaysSplitsBatchSizeOfFive()
        {
            DateTime start = new DateTime(2018, 10, 29);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            Assert.IsNotNull(batches);
        }

        [Test]
        public void SplitsDateRangeWeekdaysSplitsBatchSizeOfFiveIntoExpectedBatches()
        {
            DateTime start = new DateTime(2018, 10, 29);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            Assert.AreEqual(5, batches.Count);
        }

        [Test]
        public void SplitsDateRangeWeekdaysSplitsBatchSizeOfFiveIntoExpectedFirstBatch()
        {
            DateTime start = new DateTime(2018, 10, 29);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            var firstBatch = batches[0];

            Assert.AreEqual(new DateTime(2018, 10, 29), firstBatch.Item1);
            Assert.AreEqual(new DateTime(2018, 11, 02), firstBatch.Item2);
        }

        [Test]
        public void SplitsDateRangeWeekdaysSplitsBatchSizeOfFiveIntoExpectedLastBatch()
        {
            DateTime start = new DateTime(2018, 10, 29);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            var lastBatch = batches[batches.Count - 1];

            Assert.AreEqual(new DateTime(2018, 11, 26), lastBatch.Item1);
            Assert.AreEqual(new DateTime(2018, 11, 27), lastBatch.Item2);
        }

        [Test]
        public void SplitsDateRangeWeekdaysSplitsBatchSizeOfFiveIntoExpectedFirstBatchIfFirstDayIsTuesday()
        {
            DateTime start = new DateTime(2018, 10, 30);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            var firstBatch = batches[0];

            Assert.AreEqual(new DateTime(2018, 10, 30), firstBatch.Item1);
            Assert.AreEqual(new DateTime(2018, 11, 02), firstBatch.Item2);
        }

        [Test]
        public void SplitsDateRangeWeekdaysSplitsBatchSizeOfFiveIntoExpectedFirstBatchIfFirstDayIsWednesday()
        {
            DateTime start = new DateTime(2018, 10, 31);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            var firstBatch = batches[0];

            Assert.AreEqual(new DateTime(2018, 10, 31), firstBatch.Item1);
            Assert.AreEqual(new DateTime(2018, 11, 02), firstBatch.Item2);
        }

        [Test]
        public void SplitsDateRangeWeekdaysSplitsBatchSizeOfFiveIntoExpectedFirstBatchIfFirstDayIsThursday()
        {
            DateTime start = new DateTime(2018, 11, 01);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            var firstBatch = batches[0];

            Assert.AreEqual(new DateTime(2018, 11, 01), firstBatch.Item1);
            Assert.AreEqual(new DateTime(2018, 11, 02), firstBatch.Item2);
        }

        [Test]
        public void SplitsDateRangeWeekdaysSplitsBatchSizeOfFiveIntoExpectedFirstBatchIfFirstDayIsFriday()
        {
            DateTime start = new DateTime(2018, 11, 02);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            var firstBatch = batches[0];

            Assert.AreEqual(new DateTime(2018, 11, 02), firstBatch.Item1);
            Assert.AreEqual(new DateTime(2018, 11, 02), firstBatch.Item2);
        }

        [Test]
        public void SplitsDateRangeWeekdaysSplitsBatchSizeOfFiveIntoExpectedFirstBatchIfFirstDayIsSaturday()
        {
            DateTime start = new DateTime(2018, 10, 27);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            var firstBatch = batches[0];

            Assert.AreEqual(new DateTime(2018, 10, 29), firstBatch.Item1);
            Assert.AreEqual(new DateTime(2018, 11, 02), firstBatch.Item2);
        }

        [Test]
        public void SplitsDateRangeWeekdaysSplitsBatchSizeOfFiveIntoExpectedFirstBatchIfFirstDayIsSunday()
        {
            DateTime start = new DateTime(2018, 10, 28);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            var firstBatch = batches[0];

            Assert.AreEqual(new DateTime(2018, 10, 29), firstBatch.Item1);
            Assert.AreEqual(new DateTime(2018, 11, 02), firstBatch.Item2);
        }

        [Test]
        public void SplitsDateRangeWeekdaysReturnsSingleBatchIfRangeIsLessThanBatchSize()
        {
            DateTime start = new DateTime(2018, 10, 29);
            DateTime end = new DateTime(2018, 11, 01);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            Assert.AreEqual(1, batches.Count);
            Assert.AreEqual(new DateTime(2018, 10, 29), batches[0].Item1);
            Assert.AreEqual(new DateTime(2018, 11, 01), batches[0].Item2);
        }

        [Test]
        public void SplitDateRangeWeekDaysSplitsBatchForBatchSizeOfOneIntoExpectedNumberOfBatches()
        {
            DateTime start = new DateTime(2018, 10, 29);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 1;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            Assert.IsNotNull(batches);
            Assert.AreEqual(22, batches.Count);
        }

        [Test]
        public void SplitDateRangeWeekDaysSplitsBatchForBatchSizeOfTwoIntoExpectedNumberOfBatches()
        {
            DateTime start = new DateTime(2018, 10, 29);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 2;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            Assert.IsNotNull(batches);
            Assert.AreEqual(13, batches.Count);
        }

        [Test]
        public void SplitDateRangeWeekDaysSplitsBatchForBatchSizeOfThreeIntoExpectedNumberOfBatches()
        {
            DateTime start = new DateTime(2018, 10, 29);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 3;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            Assert.IsNotNull(batches);
            Assert.AreEqual(9, batches.Count);
        }

        [Test]
        public void SplitDateRangeWeekDaysSplitsBatchForBatchSizeOfFourIntoExpectedNumberOfBatches()
        {
            DateTime start = new DateTime(2018, 10, 29);
            DateTime end = new DateTime(2018, 11, 27);
            int batchSize = 4;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            Assert.IsNotNull(batches);
            Assert.AreEqual(9, batches.Count);
        }

        [Test]
        public void SplitDateRangeWeekDaysExcludesStartDateIfStartDateIsWeekend()
        {
            DateTime start = new DateTime(2018, 01, 06);
            DateTime end = new DateTime(2018, 02, 28);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            Assert.IsNotNull(batches);
            Assert.AreEqual(8, batches.Count);
            Assert.AreNotEqual(start, batches[0].Item1);
        }

        [Test]
        public void SplitDateRangeWeekDaysExcludesEndDateIfEndDateIsWeekend()
        {
            DateTime start = new DateTime(2018, 01, 06);
            DateTime end = new DateTime(2018, 02, 25);
            int batchSize = 5;

            var batches = DateRangeSplitter.SplitDateRangeWeekDays(start, end, batchSize).ToList();

            Assert.IsNotNull(batches);
            Assert.AreEqual(7, batches.Count);
            Assert.AreNotEqual(end, batches[batches.Count - 1].Item2);
        }
    }
}
