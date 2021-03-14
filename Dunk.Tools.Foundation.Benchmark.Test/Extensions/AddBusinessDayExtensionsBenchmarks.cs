using System;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class AddBusinessDayExtensionsBenchmarks
    {
        [Params(1000, 10000, 100000, 250000)]
        public int Number { get; set; }

        [Benchmark]
        public void AddBusinessDaysWhenStartDateIsSaturday()
        {
            var start = new DateTime(2000, 1, 1);
            var end = start.AddBusinessDays(Number);

            Assert.AreNotEqual(start, end);
        }

        [Benchmark]
        public void AddBusinessDaysWhenStartDateIsSunday()
        {
            var start = new DateTime(2000, 1, 2);
            var end = start.AddBusinessDays(Number);

            Assert.AreNotEqual(start, end);
        }

        [Benchmark]
        public void AddBusinessDaysWhenStartDateIsWeekDay()
        {
            var start = new DateTime(2000, 1, 3);
            var end = start.AddBusinessDays(Number);

            Assert.AreNotEqual(start, end);
        }
    }
}
