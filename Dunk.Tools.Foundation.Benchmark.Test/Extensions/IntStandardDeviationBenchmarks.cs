using System;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class IntStandardDeviationBenchmarks
    {
        private int[] _source;
        private int?[] _nullableSource;

        [Params(1000, 10000, 100000, 500000)]
        public int Number { get; set; }

        [Benchmark]
        public void CalculateStandardDeviationForIntSequence()
        {
            double result = _source.StandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateStandardDeviationForNullableIntSequence()
        {
            double result = _nullableSource.StandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateSampleStandardDeviationForIntSequence()
        {
            double result = _source.SampleStandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateSampleStandardDeviationForNullableIntSequence()
        {
            double result = _nullableSource.SampleStandardDeviation();
            Assert.IsNotNull(result);
        }

        [GlobalSetup]
        public void Setup()
        {
            Random rnd = new Random();
            _source = new int[Number];
            _nullableSource = new int?[Number];

            for (int i = 0; i < Number; i++)
            {
                _source[i] = rnd.Next(1, 1000);
                _nullableSource[i] = rnd.Next(1, 1000);
            }
        }
    }
}
