using System;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class IntWeightedAverageBenchmarks
    {
        private TestItem[] _source = null;

        [Params(1000, 10000, 100000, 500000)]
        public int Number { get; set; }

        [Benchmark]
        public void WeightedAverageForIntProperty()
        {
            double result = _source.WeightedAverage(i => i.Value, i => i.Value);
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void WeightedAverageForNullableIntProperty()
        {
            double? result = _source.WeightedAverage(i => i.NullableValue, i => i.NullableValue);
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void SafeWeightedAverageForIntProperty()
        {
            double result = _source.SafeWeightedAverage(i => i.Value, i => i.Value);
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void SafeWeightedAverageForNullableIntProperty()
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
                _source[i] = new TestItem(rnd.Next(1, 1000));
            }
        }

        private class TestItem
        {
            public TestItem(int value)
            {
                Value = value;
                NullableValue = value;
            }
            public int Value { get; }
            public int? NullableValue { get; }
        }
    }
}
