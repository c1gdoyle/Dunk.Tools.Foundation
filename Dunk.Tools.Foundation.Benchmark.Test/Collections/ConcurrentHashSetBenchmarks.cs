using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Collections;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Collections
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class ConcurrentHashSetBenchmarks
    {
        private string[] _words;

        [Params(1000, 10000, 100000, 250000)]
        public int Number { get; set; }

        [Benchmark]
        public void ConcurrentHashSetAddsUniqueWordToSet()
        {
            var set = new ConcurrentHashSet<string>();
            for(int i = 0; i < _words.Length; i++)
            {
                set.Add(_words[i]);
            }

            Assert.AreEqual(Number, set.Count);
        }

        [Benchmark]
        public void ConcurrentHashSetTryAddUniqueWordToSet()
        {
            var set = new ConcurrentHashSet<string>();
            for (int i = 0; i < _words.Length; i++)
            {
                set.TryAdd(_words[i]);
            }

            Assert.AreEqual(Number, set.Count);
        }

        [GlobalSetup]
        public void Setup()
        {
            _words = new string[Number];

            using(var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "words.txt")))
            {
                int i = 0;
                string word = null;

                while((word = reader.ReadLine()) != null &&
                    i < _words.Length)
                {
                    _words[i] = word;
                    i++;
                }
            }
        }
    }
}
