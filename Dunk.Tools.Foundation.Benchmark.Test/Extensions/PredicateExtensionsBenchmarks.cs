using System;
using System.Linq.Expressions;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class PredicateExtensionsBenchmarks
    {
        private Expression<Func<int, bool>>[] _expressions;

        [Params(100, 200, 500, 1000, 10000)]
        public int Number { get; set; }

        [Benchmark]
        public void ComposeAndAlsoFromIndividualExpressions()
        {
            var result = _expressions[0];
            for(int i = 1; i < _expressions.Length; i++)
            {
                result = result.And(_expressions[i]);
            }
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void ComposeAndAlsoFromEnumerableOfExpressions()
        {
            var result = _expressions.And();
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void ComposeOrElseFromIndividualExpressions()
        {
            var result = _expressions[0];
            for (int i = 1; i < _expressions.Length; i++)
            {
                result = result.Or(_expressions[i]);
            }
            Assert.IsNotNull(result);
        }

        [Benchmark]
        public void ComposeOrElseFromEnumerableOfExpressions()
        {
            var result = _expressions.Or();
            Assert.IsNotNull(result);
        }

        [GlobalSetup]
        public void Setup()
        {
            var expressions = new Expression<Func<int, bool>> []
            {
                i => i > 0,
                i => i < 5,
                i => i > -1,
                i => i < 6
            };
            _expressions = new Expression<Func<int, bool>>[Number];

            for(int i = 0; i < _expressions.Length; i++)
            {
                _expressions[i] = expressions[i % 4];
            }
        }
    }
}
