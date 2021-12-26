using System;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class DecimalWeightedAverageBenchmarks
    {
        private TestItem[] _source = null;

        [Params(1000, 10000, 100000, 500000)]
        public int Number { get; set; }

        [Benchmark]
        public void WeightedAverageForDecimalProperty()
        {
            decimal result = _source.WeightedAverage(i => i.Value, i => i.Value);
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void WeightedAverageForNullableDecimalProperty()
        {
            decimal? result = _source.WeightedAverage(i => i.NullableValue, i => i.NullableValue);
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void SafeWeightedAverageForDecimalProperty()
        {
            double result = _source.SafeWeightedAverage(i => i.Value, i => i.Value);
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void SafeWeightedAverageForNullableDecimalProperty()
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
                _source[i] = new TestItem(new decimal(rnd.NextDouble() * 1000));
            }
        }

        private sealed class TestItem
        {
            public TestItem(decimal value)
            {
                Value = value;
                NullableValue = value;
            }
            public decimal Value { get; }
            public decimal? NullableValue { get; }
        }
    }
}
