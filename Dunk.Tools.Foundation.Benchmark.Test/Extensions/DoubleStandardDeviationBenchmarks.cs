using System;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class DoubleStandardDeviationBenchmarks
    {
        private double[] _source;
        private double?[] _nullableSource;

        [Params(1000, 10000, 100000, 500000)]
        public int Number { get; set; }

        [Benchmark]
        public void CalculateStandardDeviationForDoubleSequence()
        {
            double result = _source.StandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateStandardDeviationForNullableDoubleSequence()
        {
            double result = _nullableSource.StandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateSampleStandardDeviationForDoubleSequence()
        {
            double result = _source.SampleStandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateSampleStandardDeviationForNullableDoubleSequence()
        {
            double result = _nullableSource.SampleStandardDeviation();
            Assert.IsNotNull(result);
        }

        [GlobalSetup]
        public void Setup()
        {
            Random rnd = new Random();
            _source = new double[Number];
            _nullableSource = new double?[Number];

            for (int i = 0; i < Number; i++)
            {
                _source[i] = rnd.NextDouble() * 1000;
                _nullableSource[i] = rnd.NextDouble() * 1000;
            }
        }
    }
}
