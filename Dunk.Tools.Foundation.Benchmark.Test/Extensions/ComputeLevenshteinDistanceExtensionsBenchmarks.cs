using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Extensions
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class ComputeLevenshteinDistanceExtensionsBenchmarks
    {
        private string[] _words;

        [Params(1000, 10000, 100000, 250000)]
        public int Number { get; set; }

        [Benchmark]
        public void ComputeLevenshteinDistanceForStrings()
        {
            for(int i = 0; i < _words.Length; i++)
            {
                string s = _words[i];
                string neighbour = _words[_words.Length - 1 - i];

                int cost = s.ComputeLevenshteinDistance(neighbour);

                Assert.AreNotEqual(0, cost);
            }
        }

        [GlobalSetup]
        public void Setup()
        {
            _words = new string[Number];

            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "words.txt")))
            {
                int i = 0;
                string word = null;

                while ((word = reader.ReadLine()) != null &&
                    i < _words.Length)
                {
                    _words[i] = word;
                    i++;
                }
            }
        }
    }
}
