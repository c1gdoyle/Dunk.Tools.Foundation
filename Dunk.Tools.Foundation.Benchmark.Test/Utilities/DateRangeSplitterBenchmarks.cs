using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Utilities;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Utilities
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class DateRangeSplitterBenchmarks
    {
        [Benchmark]
        public void DateRangeSplitterSplitsYearRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(1);

            var range = DateRangeSplitter.SplitDateRange(start, end, 5)
                .ToList();

            Assert.IsNotEmpty(range);
        }

        [Benchmark]
        public void DateRangeSplitterSplitsTenYearRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(10);

            var range = DateRangeSplitter.SplitDateRange(start, end, 5)
                .ToList();

            Assert.IsNotEmpty(range);
        }

        [Benchmark]
        public void DateRangeSplitterSplitsOneHundredYearRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(100);

            var range = DateRangeSplitter.SplitDateRange(start, end, 5)
                .ToList();

            Assert.IsNotEmpty(range);
        }

        [Benchmark]
        public void DateRangeSplitterSplitsFiveHundredYearRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(500);

            var range = DateRangeSplitter.SplitDateRange(start, end, 5)
                .ToList();

            Assert.IsNotEmpty(range);
        }

        [Benchmark]
        public void DateRangeSplitterSplitsYearWeekDayRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(1);

            var range = DateRangeSplitter.SplitDateRangeWeekDays(start, end, 5)
                .ToList();

            Assert.IsNotEmpty(range);
        }

        [Benchmark]
        public void DateRangeSplitterSplitsTenYearWeekDayRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(10);

            var range = DateRangeSplitter.SplitDateRangeWeekDays(start, end, 5)
                .ToList();

            Assert.IsNotEmpty(range);
        }

        [Benchmark]
        public void DateRangeSplitterSplitsOneHundredYearWeekDayRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(100);

            var range = DateRangeSplitter.SplitDateRangeWeekDays(start, end, 5)
                .ToList();

            Assert.IsNotEmpty(range);
        }

        [Benchmark]
        public void DateRangeSplitterSplitsFiveHundredYearWeekDayRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(500);

            var range = DateRangeSplitter.SplitDateRangeWeekDays(start, end, 5)
                .ToList();

            Assert.IsNotEmpty(range);
        }
    }
}
