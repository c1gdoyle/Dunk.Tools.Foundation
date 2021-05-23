using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Text;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Text
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class TrieGetWordsLookupBenchmarks
    {

        private ITrie _trie;

        private ILookup<char, string> _wordGroups;

        private readonly string[] _prefixes =
        {
            "ABC",
            "K",
            "HELLO",
            "WORLD",
            "PR",
            "AB",
            "LO",
            "ST",
            "TOM",
            "TR",
            "MOR",
            "X",
            "TRE",
            "SE",
            "GO",
            "VI",
            "GRE",
            "POL",
            "KIR",
            "VE"
        };

        [Benchmark]
        public void TrieLookupBenchmark()
        {
            var words = new List<string>();

            for(int i = 0; i < _prefixes.Length; i++)
            {
                words.AddRange(_trie.GetWords(_prefixes[i]));
            }

            Assert.IsNotEmpty(words);
        }

        [Benchmark]
        public void LinqLookupBenchmark()
        {
            var words = new List<string>();

            for (int i = 0; i < _prefixes.Length; i++)
            {
                string prefix = _prefixes[i];
                char firstLetter = prefix[0];

                words.AddRange(_wordGroups[firstLetter]
                    .Where(w => w.StartsWith(prefix)));
            }

            Assert.IsNotEmpty(words);
        }

        [GlobalSetup]
        public void Setup()
        {
            var words = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vocabulary.txt"));
            _trie = new Trie();
            for (int i = 0; i < words.Length; i++)
            {
                _trie.AddWord(words[i]);
            }
            _wordGroups = words
                .ToLookup(w => w[0]);
        }
    }
}
