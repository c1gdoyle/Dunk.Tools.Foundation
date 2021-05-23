using System;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using Dunk.Tools.Foundation.Text;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Text
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class TrieAddBenchmarks
    {
        private string[] _words;

        [Params(500, 1000, 10000, 50000)]
        public int Number { get; set; }

        [Benchmark]
        public void TrieAddWordBenchmark()
        {
            var trie = new Trie();
            for(int i = 0; i< _words.Length; i++)
            {
                trie.AddWord(_words[i]);
            }

            Assert.AreEqual(_words.Length, trie.Count);
        }

        [Benchmark]
        public void TrieAddWordsBenchmark()
        {
            var trie = new Trie();
            trie.AddWords(_words);

            Assert.AreEqual(_words.Length, trie.Count);
        }

        [GlobalSetup]
        public void Setup()
        {
            _words = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vocabulary.txt"))
                .Take(Number)
                .Randomize()
                .ToArray();
        }
    }
}
