using System;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class BusinessDateTimeExtensionsBenchmarks
    {
        [Benchmark]
        public void GetNumberOfBusinessDaysForOneYear()
        {
            const int expectedCount = 261;

            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(1);

            int count = start.GetBusinessDays(end);

            Assert.AreEqual(expectedCount, count);
        }

        [Benchmark]
        public void GetNumberOfBusinessDaysForTenYears()
        {
            const int expectedCount = 2610;

            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(10);

            int count = start.GetBusinessDays(end);

            Assert.AreEqual(expectedCount, count);
        }

        [Benchmark]
        public void GetNumberOfBusinessDaysForOneHundredYears()
        {
            const int expectedCount = 26090;

            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(100);

            int count = start.GetBusinessDays(end);

            Assert.AreEqual(expectedCount, count);
        }

        [Benchmark]
        public void GetNumberOfBusinessDaysForFiveHundredYears()
        {
            const int expectedCount = 130445;

            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = start.AddYears(500);

            int count = start.GetBusinessDays(end);

            Assert.AreEqual(expectedCount, count);
        }
    }
}
