using System;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class SubtractBusinessDayExtensionsBenchmarks
    {
        [Params(1000, 10000, 100000, 250000)]
        public int Number { get; set; }

        [Benchmark]
        public void SubtractBusinessDaysWhenStartDateIsSaturday()
        {
            var start = new DateTime(2000, 1, 1);
            var end = start.SubtractBusinessDays(Number);

            Assert.AreNotEqual(start, end);
        }

        [Benchmark]
        public void SubtractBusinessDaysWhenStartDateIsSunday()
        {
            var start = new DateTime(2000, 1, 2);
            var end = start.SubtractBusinessDays(Number);

            Assert.AreNotEqual(start, end);
        }

        [Benchmark]
        public void SubtractBusinessDaysWhenStartDateIsWeekDay()
        {
            var start = new DateTime(2000, 1, 3);
            var end = start.SubtractBusinessDays(Number);

            Assert.AreNotEqual(start, end);
        }
    }
}
