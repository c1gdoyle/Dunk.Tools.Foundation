using System;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class FloatStandardDeviationBenchmarks
    {
        private float[] _source;
        private float?[] _nullableSource;

        [Params(1000, 10000, 100000, 500000)]
        public int Number { get; set; }

        [Benchmark]
        public void CalculateStandardDeviationForFloatSequence()
        {
            double result = _source.StandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateStandardDeviationForNullableFloatSequence()
        {
            double result = _nullableSource.StandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateSampleStandardDeviationForFloatSequence()
        {
            double result = _source.SampleStandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateSampleStandardDeviationForNullableFloatSequence()
        {
            double result = _nullableSource.SampleStandardDeviation();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateVarianceForFloatSequence()
        {
            double result = _source.Variance();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void CalculateVarianceForNullableFloatSequence()
        {
            double result = _nullableSource.Variance();
            Assert.IsNotNull(result);
        }

        [GlobalSetup]
        public void Setup()
        {
            Random rnd = new Random();
            _source = new float[Number];
            _nullableSource = new float?[Number];

            for (int i = 0; i < Number; i++)
            {
                _source[i] = Convert.ToSingle(rnd.NextDouble() * 1000);
                _nullableSource[i] = Convert.ToSingle(rnd.NextDouble() * 1000);
            }
        }
    }
}
