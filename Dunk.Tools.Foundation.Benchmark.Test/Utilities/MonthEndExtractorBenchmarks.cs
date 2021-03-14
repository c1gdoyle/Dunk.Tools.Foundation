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
    public class MonthEndExtractorBenchmarks
    {
        [Benchmark]
        public void MonthEndExtractorReturnsMonthEndsForOneYearRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(1);

            var monthEnds = MonthEndExtractor.GetMonthEnds(start, end)
                .ToList();

            Assert.IsNotNull(monthEnds);
        }

        [Benchmark]
        public void MonthEndExtractorReturnsMonthEndsForTenYearRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(10);

            var monthEnds = MonthEndExtractor.GetMonthEnds(start, end)
                .ToList();

            Assert.IsNotNull(monthEnds);
        }

        [Benchmark]
        public void MonthEndExtractorReturnsMonthEndsForOneHundredYearRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(100);

            var monthEnds = MonthEndExtractor.GetMonthEnds(start, end)
                .ToList();

            Assert.IsNotNull(monthEnds);
        }

        [Benchmark]
        public void MonthEndExtractorReturnsMonthEndsForFiveHundredYearRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(500);

            var monthEnds = MonthEndExtractor.GetMonthEnds(start, end)
                .ToList();

            Assert.IsNotNull(monthEnds);
        }

        [Benchmark]
        public void MonthEndExtractorReturnsMonthEndsForOneYearWeekDaysRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(1);

            var monthEnds = MonthEndExtractor.GetWeekdayMonthEnds(start, end)
                .ToList();

            Assert.IsNotNull(monthEnds);
        }

        [Benchmark]
        public void MonthEndExtractorReturnsMonthEndsForTenYearWeekDaysRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(10);

            var monthEnds = MonthEndExtractor.GetWeekdayMonthEnds(start, end)
                .ToList();

            Assert.IsNotNull(monthEnds);
        }

        [Benchmark]
        public void MonthEndExtractorReturnsMonthEndsForOneHundredYearWeekDaysRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(100);

            var monthEnds = MonthEndExtractor.GetWeekdayMonthEnds(start, end)
                .ToList();

            Assert.IsNotNull(monthEnds);
        }

        [Benchmark]
        public void MonthEndExtractorReturnsMonthEndsForFiveHundredYearWeekDaysRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(500);

            var monthEnds = MonthEndExtractor.GetWeekdayMonthEnds(start, end)
                .ToList();

            Assert.IsNotNull(monthEnds);
        }

        [Benchmark]
        public void MonthEndExtractorReturnsMonthEndsForOneYearWeekEndsRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(1);

            var monthEnds = MonthEndExtractor.GetWeekendsMonthEnds(start, end)
                .ToList();

            Assert.IsNotNull(monthEnds);
        }

        [Benchmark]
        public void MonthEndExtractorReturnsMonthEndsForTenYearWeekEndsRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(10);

            var monthEnds = MonthEndExtractor.GetWeekendsMonthEnds(start, end)
                .ToList();

            Assert.IsNotNull(monthEnds);
        }

        [Benchmark]
        public void MonthEndExtractorReturnsMonthEndsForOneHundredYearWeekEndsRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(100);

            var monthEnds = MonthEndExtractor.GetWeekendsMonthEnds(start, end)
                .ToList();

            Assert.IsNotNull(monthEnds);
        }

        [Benchmark]
        public void MonthEndExtractorReturnsMonthEndsForFiveHundredYearWeekEndsRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(500);

            var monthEnds = MonthEndExtractor.GetWeekendsMonthEnds(start, end)
                .ToList();

            Assert.IsNotNull(monthEnds);
        }
    }
}
