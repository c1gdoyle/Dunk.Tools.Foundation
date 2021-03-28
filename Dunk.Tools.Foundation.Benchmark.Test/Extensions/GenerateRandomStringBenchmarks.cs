using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class GenerateRandomStringBenchmarks
    {
        [Params(1000, 10000, 1000000, 5000000, 10000000)]
        public int Number { get; set; }

        [Benchmark]
        public void GenerateRandomString()
        {
            string s = StringExtensions.GenerateRandomString(Number);
            Assert.AreEqual(Number, s.Length);
        }

        [Benchmark]
        public void GenerateAsciiString()
        {
            string s = StringExtensions.GenerateRandomAsciiString(Number);
            Assert.AreEqual(Number, s.Length);
        }
    }
}
