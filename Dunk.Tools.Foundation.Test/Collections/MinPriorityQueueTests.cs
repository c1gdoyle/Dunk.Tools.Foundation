using System;
using System.Collections.Generic;
using System.Linq;
using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class MinPriorityQueueTests
    {
        [Test]
        public void MinPriorityQueueIntialises()
        {
            var priorityQueue = new MinPriorityQueue<string, int>();
            Assert.IsNotNull(priorityQueue);
        }

        [Test]
        public void MinPriorityQueueInitialisesWithSpecifiedInitialQueueSize()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(25);
            Assert.IsNotNull(priorityQueue);
        }

        [Test]
        public void MinPriorityQueueInitialisesWithSpecifiedPriorityComparer()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(Comparer<int>.Default);
            Assert.IsNotNull(priorityQueue);
        }

        [Test]
        public void MinPriorityQueueThrowsIfInitialQueueSizeIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MinPriorityQueue<string, int>(-1));
        }

        [Test]
        public void MinPriorityQueueThrowsIfInitialQueueSizeIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MinPriorityQueue<string, int>(0));
        }

        [Test]
        public void MinPriorityQueueThrowsIfComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new MinPriorityQueue<string, int>(null as IComparer<int>));
        }

        [Test]
        public void MinPriorityQueueInitialisesEmpty()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);
            Assert.IsTrue(priorityQueue.IsEmpty);
        }

        [Test]
        public void MinPriorityQueueInsertsItems()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            Assert.AreEqual(8, priorityQueue.Count);
        }

        [Test]
        public void MinPriorityQueueClearRemovesAllItems()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);
            priorityQueue.Clear();

            Assert.IsTrue(priorityQueue.IsEmpty);
        }

        [Test]
        public void MinPriorityQueueEnqueueThrowsIfPriorityIsNull()
        {
            var priorityQueue = new MinPriorityQueue<string, TestPriority>(50);

            Assert.Throws<ArgumentNullException>(() => priorityQueue.Enqueue("A_1", null as TestPriority));
        }

        [Test]
        public void MinPriorityQueuePeeksReturnsItemWithLowestPriority()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            string item = priorityQueue.Peek();

            Assert.AreEqual("A_3", item);
        }

        [Test]
        public void MinPriorityQueueDequeueReturnsItemWithLowestPriority()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            string item = priorityQueue.Dequeue();

            Assert.AreEqual("A_3", item);
        }

        [Test]
        public void MinPriorityQueuePeekDoesNotRemoveItemFromQueue()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            priorityQueue.Peek();

            Assert.AreEqual(8, priorityQueue.Count);
        }

        [Test]
        public void MinPriorityQueueDequeueDoesRemoveItemFromQueue()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            priorityQueue.Dequeue();

            Assert.AreEqual(7, priorityQueue.Count);
        }

        [Test]
        public void MinPriorityQueueMovesNextLowestPriorityItemToHeadAfterRemoveItem()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            priorityQueue.Dequeue();

            string item = priorityQueue.Peek();

            Assert.AreEqual("A_5", item);
        }

        [Test]
        public void MinPriorityQueueInsertsItemToHeadIfItemIsLowerPriorityThanHead()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            string originalHead = priorityQueue.Peek();

            priorityQueue.Enqueue("A_2", 2);

            string newHead = priorityQueue.Peek();

            Assert.AreEqual("A_3", originalHead);
            Assert.AreEqual("A_2", newHead);
        }

        [Test]
        public void MinPriorityQueueDoesNotInsertItemToHeadIfItemIsHigherPriorityThanHead()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            string originalHead = priorityQueue.Peek();

            priorityQueue.Enqueue("A_4", 4);

            string newHead = priorityQueue.Peek();

            Assert.AreEqual("A_3", originalHead);
            Assert.AreEqual("A_3", newHead);
        }

        [Test]
        public void MinPriorityQueueDoesInsertItemInCollectionAsHeadIfItemIsLowerPriorityThanOriginalHead()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            string originalHead = priorityQueue.Peek();

            List<Tuple<string, int>> newItems = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_2", 2),
                new Tuple<string, int>("A_4", 4),
                new Tuple<string, int>("A_6", 6),
                new Tuple<string, int>("A_8", 8),
                new Tuple<string, int>("A_10", 10),
                new Tuple<string, int>("A_12", 12),
                new Tuple<string, int>("A_14", 14),
                new Tuple<string, int>("A_16", 16),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(newItems);

            string newHead = priorityQueue.Peek();

            Assert.AreEqual("A_3", originalHead);
            Assert.AreEqual("A_2", newHead);
        }

        [Test]
        public void MinPriorityQueueDoesNotInsertItemInCollectionAsHeadIfItemIsHigherPriorityThanOriginalHead()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            string originalHead = priorityQueue.Peek();

            List<Tuple<string, int>> newItems = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_4", 4),
                new Tuple<string, int>("A_6", 6),
                new Tuple<string, int>("A_8", 8),
                new Tuple<string, int>("A_10", 10),
                new Tuple<string, int>("A_12", 12),
                new Tuple<string, int>("A_14", 14),
                new Tuple<string, int>("A_16", 16),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(newItems);

            string newHead = priorityQueue.Peek();

            Assert.AreEqual("A_3", originalHead);
            Assert.AreEqual("A_3", newHead);
        }

        [Test]
        public void MinPriorityQueueEnumerationSupportsEnumeration()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            List<string> list = new List<string>();

            foreach (string s in priorityQueue)
            {
                list.Add(s);
            }

            Assert.AreEqual(8, list.Count);
        }

        [Test]
        public void MinPriorityQueueEnumerationYieldsLowestPriorityAsFirstItem()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            List<string> list = new List<string>();

            foreach (string s in priorityQueue)
            {
                list.Add(s);
            }

            Assert.AreEqual("A_3", list.First());
        }

        [Test]
        public void MinPriorityQueueEnumerationYieldsHighestPriorityAsLastItem()
        {
            var priorityQueue = new MinPriorityQueue<string, int>(50);

            List<Tuple<string, int>> items = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("A_50", 50),
                new Tuple<string, int>("A_41", 41),
                new Tuple<string, int>("A_38", 38),
                new Tuple<string, int>("A_37", 37),
                new Tuple<string, int>("A_23", 23),
                new Tuple<string, int>("A_11", 11),
                new Tuple<string, int>("A_5", 5),
                new Tuple<string, int>("A_3", 3),
            }.Randomize()
            .ToList();
            priorityQueue.EnqueueRange(items);

            List<string> list = new List<string>();

            foreach (string s in priorityQueue)
            {
                list.Add(s);
            }

            Assert.AreEqual("A_50", list.Last());
        }

        private class TestPriority : IComparable<TestPriority>
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S3459:Ignore for test")]
            public int Id { get; }

            public int CompareTo(TestPriority other)
            {
                return Id.CompareTo(other.Id);
            }
        }
    }
}
