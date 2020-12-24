using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Collections
{
    [TestFixture]
    public class SynchronisedMinPriorityQueueTests
    {
        [Test]
        public void SynchronisedMinPriorityQueueIntialises()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>();
            Assert.IsNotNull(priorityQueue);
        }

        [Test]
        public void SynchronisedMinPriorityQueueInitialisesWithSpecifiedInitialQueueSize()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(25);
            Assert.IsNotNull(priorityQueue);
        }

        [Test]
        public void SynchronisedMinPriorityQueueInitialisesWithSpecifiedPriorityComparer()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(Comparer<int>.Default);
            Assert.IsNotNull(priorityQueue);
        }

        [Test]
        public void SynchronisedMinPriorityQueueThrowsIfInitialQueueSizeIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SynchronisedMinPriorityQueue<string, int>(-1));
        }

        [Test]
        public void SynchronisedMinPriorityQueueThrowsIfInitialQueueSizeIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SynchronisedMinPriorityQueue<string, int>(0));
        }

        [Test]
        public void SynchronisedMinPriorityQueueThrowsIfComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SynchronisedMinPriorityQueue<string, int>(null as IComparer<int>));
        }

        [Test]
        public void SynchronisedMinPriorityQueueInitialisesEmpty()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);
            Assert.IsTrue(priorityQueue.IsEmpty);
        }

        [Test]
        public void SynchronisedMinPriorityQueueInsertsItems()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueueClearRemovesAllItems()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueueEnqueueThrowsIfPriorityIsNull()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, TestPriority>(50);

            Assert.Throws<ArgumentNullException>(() => priorityQueue.Enqueue("A_1", null as TestPriority));
        }

        [Test]
        public void SynchronisedMinPriorityQueuePeeksReturnsItemWithLowestPriority()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueueDequeueReturnsItemWithLowestPriority()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueuePeekDoesNotRemoveItemFromQueue()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueueDequeueDoesRemoveItemFromQueue()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueueMovesNextLowestPriorityItemToHeadAfterRemoveItem()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueueInsertsItemToHeadIfItemIsLowerPriorityThanHead()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueueDoesNotInsertItemToHeadIfItemIsHigherPriorityThanHead()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueueDoesInsertItemInCollectionAsHeadIfItemIsLowerPriorityThanOriginalHead()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueueDoesNotInsertItemInCollectionAsHeadIfItemIsHigherPriorityThanOriginalHead()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueueEnumerationSupportsEnumeration()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueueEnumerationYieldsLowestPriorityAsFirstItem()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
        public void SynchronisedMinPriorityQueueEnumerationYieldsHighestPriorityAsLastItem()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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


        [Test]
        public void SynchronisedMinPriorityQueuePeekReturnsItemWithLowestPriorityMultiThread()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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

            List<Task> tasks = new List<Task>();
            items.ForEach(i => tasks.Add(Task.Factory.StartNew(() => priorityQueue.Enqueue(i.Item1, i.Item2))));
            Task.WaitAll(tasks.ToArray());

            string item = priorityQueue.Peek();

            Assert.AreEqual("A_3", item);
        }

        [Test]
        public void SynchronisedMinPriorityQueueDequeueReturnsItemWithLowestPriorityMultiThread()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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
            List<Task> tasks = new List<Task>();
            items.ForEach(i => tasks.Add(Task.Factory.StartNew(() => priorityQueue.Enqueue(i.Item1, i.Item2))));
            Task.WaitAll(tasks.ToArray());

            string item = priorityQueue.Dequeue();

            Assert.AreEqual("A_3", item);
        }

        [Test]
        public void SynchronisedMinPriorityQueueInsertsItemInCollectionAsHeadIfItemIsLowerPriorityThanOriginalHeadMultiThreaded()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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

            List<Task> tasks = new List<Task>();
            items.ForEach(i => tasks.Add(Task.Factory.StartNew(() => priorityQueue.Enqueue(i.Item1, i.Item2))));
            Task.WaitAll(tasks.ToArray());

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

            List<Task> newtasks = new List<Task>();
            newItems.ForEach(i => newtasks.Add(Task.Factory.StartNew(() => priorityQueue.Enqueue(i.Item1, i.Item2))));
            Task.WaitAll(newtasks.ToArray());

            string newHead = priorityQueue.Peek();

            Assert.AreEqual("A_3", originalHead);
            Assert.AreEqual("A_2", newHead);
        }

        [Test]
        public void SynchronisedMinPriorityQueueDoesNotInsertsItemInCollectionAsHeadIfItemIsHigherPriorityThanOriginalHeadMultiThreaded()
        {
            var priorityQueue = new SynchronisedMinPriorityQueue<string, int>(50);

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

            List<Task> tasks = new List<Task>();
            items.ForEach(i => tasks.Add(Task.Factory.StartNew(() => priorityQueue.Enqueue(i.Item1, i.Item2))));
            Task.WaitAll(tasks.ToArray());

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

            List<Task> newtasks = new List<Task>();
            newItems.ForEach(i => newtasks.Add(Task.Factory.StartNew(() => priorityQueue.Enqueue(i.Item1, i.Item2))));
            Task.WaitAll(newtasks.ToArray());

            string newHead = priorityQueue.Peek();

            Assert.AreEqual("A_3", originalHead);
            Assert.AreEqual("A_3", newHead);
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
