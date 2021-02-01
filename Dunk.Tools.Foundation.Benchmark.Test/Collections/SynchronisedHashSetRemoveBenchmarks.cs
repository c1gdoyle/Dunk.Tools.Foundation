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
    [SimpleJob(targetCount:100)]
    public class SynchronisedHashSetRemoveBenchmarks
    {
        private string[] _validWords;
        private SynchronisedHashSet<string> _hashSet;

        [Params(1000, 10000, 100000, 250000)]
        public int Number { get; set; }

        [Benchmark()]
        public void SynchronisedHashSetRemoveReturnsTrueIfSetContainsItem()
        {
            for (int i = 0; i < _validWords.Length; i++)
            {
                _hashSet.Remove(_validWords[i]);
            }

            Assert.AreEqual(0, _hashSet.Count);
        }

        [Benchmark]
        public void SynchronisedHashSetTryRemoveReturnsTrueIfSetContainsItem()
        {
            _hashSet = new SynchronisedHashSet<string>(_validWords);

            for (int i = 0; i < _validWords.Length; i++)
            {
                _hashSet.TryRemove(_validWords[i]);
            }

            Assert.AreEqual(0, _hashSet.Count);
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
