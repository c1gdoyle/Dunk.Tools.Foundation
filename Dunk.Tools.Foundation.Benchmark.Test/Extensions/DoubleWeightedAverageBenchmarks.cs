using System;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class DoubleWeightedAverageBenchmarks
    {
        private TestItem[] _source = null;

        [Params(1000, 10000, 100000, 500000)]
        public int Number { get; set; }

        [Benchmark]
        public void WeightedAverageForDoubleProperty()
        {
            double result = _source.WeightedAverage(i => i.Value, i => i.Value);
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void WeightedAverageForNullableDoubleProperty()
        {
            double? result = _source.WeightedAverage(i => i.NullableValue, i => i.NullableValue);
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void SafeWeightedAverageForDoubleProperty()
        {
            double result = _source.SafeWeightedAverage(i => i.Value, i => i.Value);
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void SafeWeightedAverageForNullableDoubleProperty()
        {
            double? result = _source.SafeWeightedAverage(i => i.NullableValue, i => i.NullableValue);
            Assert.IsNotNull(result);
        }


        [GlobalSetup]
        public void Setup()
        {
            Random rnd = new Random();
            _source = new TestItem[Number];

            for (int i = 0; i < Number; i++)
            {
                _source[i] = new TestItem(rnd.NextDouble() * 1000);
            }
        }

        private sealed class TestItem
        {
            public TestItem(double value)
            {
                Value = value;
                NullableValue = value;
            }
            public double Value { get; }
            public double? NullableValue { get; }
        }
    }
}
