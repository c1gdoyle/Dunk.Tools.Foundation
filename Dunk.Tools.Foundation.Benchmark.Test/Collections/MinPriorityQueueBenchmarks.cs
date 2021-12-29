﻿using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Benchmark.Test.Collections
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class MinPriorityQueueBenchmarks
    {
        private Tuple<string, int>[] _array;

        [Params(1000, 10000, 100000, 250000)]
        public int Number { get; set; }

        [Benchmark]
        public void MinQueueAddItem()
        {
            var queue = new MinPriorityQueue<string, int>();
            
            for(int i = 0; i < _array.Length; i++)
            {
                queue.Enqueue(_array[i].Item1, _array[i].Item2);
            }

            Assert.AreEqual(Number, queue.Count);
        }

        [Benchmark]
        public void MinQueueAddItemWithSize()
        {
            var queue = new MinPriorityQueue<string, int>(Number);

            for (int i = 0; i < _array.Length; i++)
            {
                queue.Enqueue(_array[i].Item1, _array[i].Item2);
            }

            Assert.AreEqual(Number, queue.Count);
        }

        [Benchmark]
        public void MinQueueAddItems()
        {
            var queue = new MinPriorityQueue<string, int>();

            queue.EnqueueRange(_array);

            Assert.AreEqual(Number, queue.Count);
        }

        [Benchmark]
        public void MinQueueAddItemsWithSize()
        {
            var queue = new MinPriorityQueue<string, int>(Number);

            queue.EnqueueRange(_array);

            Assert.AreEqual(Number, queue.Count);
        }

        [GlobalSetup]
        public void Setup()
        {
            _array = new Tuple<string, int>[Number];
            for(int i =0; i < Number; i++)
            {
                _array[i] = new Tuple<string, int>(i.ToString(), i);
            }
            _array = _array.Randomize()
                .ToArray();
        }
    }
}
