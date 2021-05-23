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
    public class TrieLookupBenchmarks
    {
        private string[] _words;
        private ITrie _trie;

        [Params(500, 1000, 10000, 50000)]
        public int Number { get; set; }

        [Benchmark]
        public void HasPrefixLookupBenchmark()
        {
            for(int i = 0; i < _words.Length; i++)
            {
                string prefix = _words[i].DeleteLastCharacter();
                Assert.IsTrue(_trie.HasPrefix(prefix));
            }
        }

        [Benchmark]
        public void HasWordLookupBenchmark()
        {
            for (int i = 0; i < _words.Length; i++)
            {
                Assert.IsTrue(_trie.HasWord(_words[i]));
            }
        }

        [Benchmark]
        public void GetTrieNodeLookupBenchmark()
        {
            for (int i = 0; i < _words.Length; i++)
            {
                string prefix = _words[i].DeleteLastCharacter();
                var node = _trie.GetTrieNode(prefix);
                Assert.IsNotNull(node);
            }
        }

        [GlobalSetup]
        public void Setup()
        {
            _words = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vocabulary.txt"))
                .Take(Number)
                .ToArray();

            _trie = new Trie();
            for(int i = 0; i < _words.Length; i++)
            {
                _trie.AddWord(_words[i]);
            }
            _words = _words
                .Randomize()
                .ToArray();
        }
    }
}
