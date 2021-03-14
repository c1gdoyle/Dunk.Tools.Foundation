using System;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class LongStandardDeviationBenchmarks
    {
        private long[] _source;
        private long?[] _nullableSource;

        [Params(1000, 10000, 100000, 500000)]
        public int Number { get; set; }

        [Benchmark]
        public void CalculateStandardDeviationForLongSequence()
        {
            double result = _source.StandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateStandardDeviationForNullableLongSequence()
        {
            double result = _nullableSource.StandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateSampleStandardDeviationForLongSequence()
        {
            double result = _source.SampleStandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateSampleStandardDeviationForNullableLongSequence()
        {
            double result = _nullableSource.SampleStandardDeviation();
            Assert.IsNotNull(result);
        }

        [GlobalSetup]
        public void Setup()
        {
            Random rnd = new Random();
            _source = new long[Number];
            _nullableSource = new long?[Number];

            for (int i = 0; i < Number; i++)
            {
                _source[i] = rnd.Next(1, 1000);
                _nullableSource[i] = rnd.Next(1, 1000);
            }
        }
    }
}
