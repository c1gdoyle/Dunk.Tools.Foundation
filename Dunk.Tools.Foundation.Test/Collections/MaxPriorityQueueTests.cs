using System;
using System.Collections.Generic;
using System.Linq;
using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class MaxPriorityQueueTests
    {
        [Test]
        public void MaxPriorityQueueIntialises()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>();
            Assert.IsNotNull(priorityQueue);
        }

        [Test]
        public void MaxPriorityQueueInitialisesWithSpecifiedInitialQueueSize()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(25);
            Assert.IsNotNull(priorityQueue);
        }

        [Test]
        public void MaxPriorityQueueInitialisesWithSpecifiedPriorityComparer()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(Comparer<int>.Default);
            Assert.IsNotNull(priorityQueue);
        }

        [Test]
        public void MaxPriorityQueueThrowsIfInitialQueueSizeIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MaxPriorityQueue<string, int>(-1));
        }

        [Test]
        public void MaxPriorityQueueThrowsIfInitialQueueSizeIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MaxPriorityQueue<string, int>(0));
        }

        [Test]
        public void MaxPriorityQueueThrowsIfComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new MaxPriorityQueue<string, int>(null as IComparer<int>));
        }

        [Test]
        public void MaxPriorityQueueInitialisesEmpty()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);
            Assert.IsTrue(priorityQueue.IsEmpty);
        }

        [Test]
        public void MaxPriorityQueueInsertsItems()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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
        public void MaxPriorityQueueClearRemovesAllItems()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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
        public void MaxPriorityQueueEnqueueThrowsIfPriorityIsNull()
        {
            var priorityQueue = new MaxPriorityQueue<string, TestPriority>(50);

            Assert.Throws<ArgumentNullException>(() => priorityQueue.Enqueue("A_1", null as TestPriority));
        }

        [Test]
        public void MaxPriorityQueuePeekReturnsItemWithHighestPriority()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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

            Assert.AreEqual("A_50", item);
        }

        [Test]
        public void MaxPriorityQueueDequeueReturnsItemWithHighestPriority()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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

            Assert.AreEqual("A_50", item);
        }

        [Test]
        public void MaxPriorityQueuePeekDoesNotRemoveItemFromQueue()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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
        public void MaxPriorityQueueDequeuDoesRemoveItemFromQueue()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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

            Assert.AreEqual(7, priorityQueue.Count);
        }

        [Test]
        public void MaxPriorityQueueMovesNextHighestPriorityItemToHeadAfterDequeueItem()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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

            Assert.AreEqual("A_41", item);
        }

        [Test]
        public void MaxPriorityQueueInsertsItemToHeadIfItemIsHigherPriorityThanHead()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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

            priorityQueue.Enqueue("A_51", 51);

            string newHead = priorityQueue.Peek();

            Assert.AreEqual("A_50", originalHead);
            Assert.AreEqual("A_51", newHead);
        }

        [Test]
        public void MaxPriorityQueueDoesNotInsertItemToHeadIfItemIsLowerPriorityThanHead()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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

            priorityQueue.Enqueue("A_49", 49);

            string newHead = priorityQueue.Peek();

            Assert.AreEqual("A_50", originalHead);
            Assert.AreEqual("A_50", newHead);
        }

        [Test]
        public void MaxPriorityQueueInsertsItemInCollectionAsHeadIfItemIsHigherPriorityThanOriginalHead()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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
                new Tuple<string, int>("A_51", 51),
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

            Assert.AreEqual("A_50", originalHead);
            Assert.AreEqual("A_51", newHead);
        }

        [Test]
        public void MaxPriorityQueueDoesNotInsertsItemInCollectionAsHeadIfItemIsLowerPriorityThanOriginalHead()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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
                new Tuple<string, int>("A_49", 49),
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

            Assert.AreEqual("A_50", originalHead);
            Assert.AreEqual("A_50", newHead);
        }

        [Test]
        public void MaxPriorityQueueEnumerationSupportsEnumeration()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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
        public void MaxPriorityQueueEnumerationYieldsHighestPriorityAsFirstItem()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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

            Assert.AreEqual("A_50", list.First());
        }

        [Test]
        public void MaxPriorityQueueEnumerationYieldsLowestPriorityAsLastItem()
        {
            var priorityQueue = new MaxPriorityQueue<string, int>(50);

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

            Assert.AreEqual("A_3", list.Last());

        }

        private class TestPriority : IComparable<TestPriority>
        {
            public int Id { get; set; }

            public int CompareTo(TestPriority other)
            {
                return Id.CompareTo(other.Id);
            }
        }
    }
}
