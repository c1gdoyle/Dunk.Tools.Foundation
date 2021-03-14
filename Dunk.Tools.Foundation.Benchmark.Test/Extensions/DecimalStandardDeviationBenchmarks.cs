using System;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class DecimalStandardDeviationBenchmarks
    {
        private decimal[] _source;
        private decimal?[] _nullableSource;

        [Params(1000, 10000, 100000, 500000)]
        public int Number { get; set; }

        [Benchmark]
        public void CalculateStandardDeviationForDecimalSequence()
        {
            double result = _source.StandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateStandardDeviationForNullableDecimalSequence()
        {
            double result = _nullableSource.StandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateSampleStandardDeviationForDecimalSequence()
        {
            double result = _source.SampleStandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateSampleStandardDeviationForNullableDecimalSequence()
        {
            double result = _nullableSource.SampleStandardDeviation();
            Assert.IsNotNull(result);
        }

        [GlobalSetup]
        public void Setup()
        {
            Random rnd = new Random();
            _source = new decimal[Number];
            _nullableSource = new decimal?[Number];

            for(int i = 0; i < Number; i++)
            {
                _source[i] = new decimal(rnd.NextDouble() * 1000);
                _nullableSource[i] = new decimal(rnd.NextDouble() * 1000);
            }
        }
    }
}
