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
    public class TrieRemoveBenchmarks
    {
        private string[] _words;
        private ITrie _trie;

        [Params(500, 1000, 10000, 50000)]
        public int Number { get; set; }

        [Benchmark]
        public void TrieRemoveByWordBenchmark()
        {
            for(int i = 0; i< _words.Length; i++)
            {
                _trie.RemoveWord(_words[i]);
            }
            Assert.AreEqual(0, _trie.Count);
        }

        [Benchmark]
        public void TrieRemoveByPrefixBenchmark()
        {
            for (int i = 0; i < _words.Length; i++)
            {
                _trie.RemovePrefix(_words[i].DeleteLastCharacter());
            }
            Assert.AreEqual(0, _trie.Count);
        }

        [GlobalSetup]
        public void Setup()
        {
            _words = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vocabulary.txt"))
                .Take(Number)
                .ToArray();

            _trie = new Trie();
            for (int i = 0; i < _words.Length; i++)
            {
                _trie.AddWord(_words[i]);
            }
            _words = _words
                .Randomize()
                .ToArray();
        }
    }
}
