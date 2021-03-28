using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Data;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Data
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class AsciiStringBenchmarks
    {
        private string _input;

        [Params(1000, 10000, 100000, 250000)]
        public int Number { get; set; }

        [Benchmark]
        public void AsciiStringCreation()
        {
            var asciiString = new AsciiString(_input);

            Assert.AreEqual(Number, asciiString.Length);
        }

        [Test]
        public void AsciiStringSubString()
        {
            var asciiString = new AsciiString(_input);
            var newAsciiString = asciiString.SubString(0, Number);

            Assert.AreEqual(Number, newAsciiString.Length);
        }

        [GlobalSetup]
        public void Setup()
        {
            _input = StringExtensions.GenerateRandomAsciiString(Number);
        }
    }
}
