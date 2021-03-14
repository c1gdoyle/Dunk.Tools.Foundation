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
    public class YearEndExtractorBenchmarks
    {
        [Benchmark]
        public void YearEndExtractorReturnsYearEndsForOneYearRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(1);

            var YearEnds = YearEndExtractor.GetYearEnds(start, end)
                .ToList();

            Assert.IsNotNull(YearEnds);
        }

        [Benchmark]
        public void YearEndExtractorReturnsYearEndsForTenYearRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(10);

            var YearEnds = YearEndExtractor.GetYearEnds(start, end)
                .ToList();

            Assert.IsNotNull(YearEnds);
        }

        [Benchmark]
        public void YearEndExtractorReturnsYearEndsForOneHundredYearRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(100);

            var YearEnds = YearEndExtractor.GetYearEnds(start, end)
                .ToList();

            Assert.IsNotNull(YearEnds);
        }

        [Benchmark]
        public void YearEndExtractorReturnsYearEndsForFiveHundredYearRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(500);

            var YearEnds = YearEndExtractor.GetYearEnds(start, end)
                .ToList();

            Assert.IsNotNull(YearEnds);
        }

        [Benchmark]
        public void YearEndExtractorReturnsYearEndsForOneYearWeekDaysRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(1);

            var YearEnds = YearEndExtractor.GetWeekdayYearEnds(start, end)
                .ToList();

            Assert.IsNotNull(YearEnds);
        }

        [Benchmark]
        public void YearEndExtractorReturnsYearEndsForTenYearWeekDaysRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(10);

            var YearEnds = YearEndExtractor.GetWeekdayYearEnds(start, end)
                .ToList();

            Assert.IsNotNull(YearEnds);
        }

        [Benchmark]
        public void YearEndExtractorReturnsYearEndsForOneHundredYearWeekDaysRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(100);

            var YearEnds = YearEndExtractor.GetWeekdayYearEnds(start, end)
                .ToList();

            Assert.IsNotNull(YearEnds);
        }

        [Benchmark]
        public void YearEndExtractorReturnsYearEndsForFiveHundredYearWeekDaysRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(500);

            var YearEnds = YearEndExtractor.GetWeekdayYearEnds(start, end)
                .ToList();

            Assert.IsNotNull(YearEnds);
        }

        [Benchmark]
        public void YearEndExtractorReturnsYearEndsForOneYearWeekEndsRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(1);

            var YearEnds = YearEndExtractor.GetWeekendsYearEnds(start, end)
                .ToList();

            Assert.IsNotNull(YearEnds);
        }

        [Benchmark]
        public void YearEndExtractorReturnsYearEndsForTenYearWeekEndsRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(10);

            var YearEnds = YearEndExtractor.GetWeekendsYearEnds(start, end)
                .ToList();

            Assert.IsNotNull(YearEnds);
        }

        [Benchmark]
        public void YearEndExtractorReturnsYearEndsForOneHundredYearWeekEndsRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(100);

            var YearEnds = YearEndExtractor.GetWeekendsYearEnds(start, end)
                .ToList();

            Assert.IsNotNull(YearEnds);
        }

        [Benchmark]
        public void YearEndExtractorReturnsYearEndsForFiveHundredYearWeekEndsRange()
        {
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(500);

            var YearEnds = YearEndExtractor.GetWeekendsYearEnds(start, end)
                .ToList();

            Assert.IsNotNull(YearEnds);
        }
    }
}
