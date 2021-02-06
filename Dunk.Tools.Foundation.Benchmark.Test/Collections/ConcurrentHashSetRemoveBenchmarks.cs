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
    public class ConcurrentHashSetRemoveBenchmarks
    {
        private string[] _validWords;
        private ConcurrentHashSet<string> _hashSet;

        [Params(1000, 10000, 100000, 250000)]
        public int Number { get; set; }

        [Benchmark]
        public void ConcurrentHashSetRemoveRemovesIfSetContainsItem()
        {
            for (int i = 0; i < _validWords.Length; i++)
            {
                Assert.IsTrue(_hashSet.Remove(_validWords[i]) &&
                    _hashSet.TryAdd(_validWords[i]));
            }
        }

        [Benchmark]
        public void ConcurrentHashSetTryRemoveRemovesIfSetContainsItem()
        {
            for (int i = 0; i < _validWords.Length; i++)
            {
                Assert.IsTrue(_hashSet.Remove(_validWords[i]) &&
                    _hashSet.TryAdd(_validWords[i]));
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
            _hashSet = new ConcurrentHashSet<string>(_validWords);
        }
    }
}
