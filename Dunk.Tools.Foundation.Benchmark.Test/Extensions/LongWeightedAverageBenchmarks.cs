using System;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class LongWeightedAverageBenchmarks
    {
        private TestItem[] _source = null;

        [Params(1000, 10000, 100000, 500000)]
        public int Number { get; set; }

        [Benchmark]
        public void WeightedAverageForLongProperty()
        {
            double result = _source.WeightedAverage(i => i.Value, i => i.Value);
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void WeightedAverageForNullableLongProperty()
        {
            double? result = _source.WeightedAverage(i => i.NullableValue, i => i.NullableValue);
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void SafeWeightedAverageForLongProperty()
        {
            double result = _source.SafeWeightedAverage(i => i.Value, i => i.Value);
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void SafeWeightedAverageForNullableLongProperty()
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

        private sealed class TestItem
        {
            public TestItem(long value)
            {
                Value = value;
                NullableValue = value;
            }
            public long Value { get; }
            public long? NullableValue { get; }
        }
    }
}
