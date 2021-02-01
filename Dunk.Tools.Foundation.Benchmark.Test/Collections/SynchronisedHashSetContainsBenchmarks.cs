using System;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Collections;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Collections
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    [SimpleJob(targetCount: 100)]
    public class SynchronisedHashSetContainsBenchmarks
    {
        private string[] _validWords = null;
        private SynchronisedHashSet<string> _hashSet;

        [Params(1000, 10000, 100000, 250000)]
        public int Number { get; set; }

        [Benchmark]
        public void SynchronisedHashSetContainsReturnsTrueIfSetContainsItem()
        {
            for (int i = 0; i < _validWords.Length; i++)
            {
                Assert.IsTrue(_hashSet.Contains(_validWords[i]));
            }
        }

        [GlobalSetup]
        public void Setup()
        {
            _validWords = new string[Number];

            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "words.txt")))
            {
                int i = 0;
                string word = null;

                while ((word = reader.ReadLine()) != null &&
                    i < Number)
                {
                    _validWords[i] = (word);
                    i++;
                }
            }
        }

        [IterationSetup]
        public void IterationSetup()
        {
            _hashSet = new SynchronisedHashSet<string>(_validWords);
        }
    }
}
