using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class ToListWithCountBenchmarks
    {
        private IEnumerable<int> _source;

        [Params(1000, 10000, 1000000, 5000000)]
        public int Number { get; set; }

        [Benchmark]
        public void ToListWithCount()
        {
            IList<int> list = _source.ToListWithCount(Number);
            Assert.AreEqual(Number, list.Count);
        }

        [GlobalSetup]
        public void Setup()
        {
            Random rnd = new Random();
            var array = new int[Number];

            for (int i = 0; i < Number; i++)
            {
                array[i] = rnd.Next() * 1000;
            }
            _source = array;
        }
    }
}
