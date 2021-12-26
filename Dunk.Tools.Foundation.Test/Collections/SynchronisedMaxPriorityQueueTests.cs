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
    public class SynchronisedMaxPriorityQueueTests
    {
        [Test]
        public void SynchronisedMaxPriorityQueueIntialises()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>();
            Assert.IsNotNull(priorityQueue);
        }

        [Test]
        public void SynchronisedMaxPriorityQueueInitialisesWithSpecifiedInitialQueueSize()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(25);
            Assert.IsNotNull(priorityQueue);
        }

        [Test]
        public void SynchronisedMaxPriorityQueueInitialisesWithSpecifiedPriorityComparer()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(Comparer<int>.Default);
            Assert.IsNotNull(priorityQueue);
        }

        [Test]
        public void SynchronisedMaxPriorityQueueThrowsIfInitialQueueSizeIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SynchronisedMaxPriorityQueue<string, int>(-1));
        }

        [Test]
        public void SynchronisedMaxPriorityQueueThrowsIfInitialQueueSizeIsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SynchronisedMaxPriorityQueue<string, int>(0));
        }

        [Test]
        public void SynchronisedMaxPriorityQueueThrowsIfComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SynchronisedMaxPriorityQueue<string, int>(null as IComparer<int>));
        }

        [Test]
        public void SynchronisedMaxPriorityQueueInitialisesEmpty()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);
            Assert.IsTrue(priorityQueue.IsEmpty);
        }

        [Test]
        public void SynchronisedMaxPriorityQueueInsertsItems()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueueClearRemovesAllItems()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueueEnqueueThrowsIfPriorityIsNull()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, TestPriority>(50);

            Assert.Throws<ArgumentNullException>(() => priorityQueue.Enqueue("A_1", null as TestPriority));
        }

        [Test]
        public void SynchronisedMaxPriorityQueuePeekReturnsItemWithHighestPriority()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueueDequeueReturnsItemWithHighestPriority()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueuePeekDoesNotRemoveItemFromQueue()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueueDequeuDoesRemoveItemFromQueue()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueueMovesNextHighestPriorityItemToHeadAfterDequeueItem()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueueInsertsItemToHeadIfItemIsHigherPriorityThanHead()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueueDoesNotInsertItemToHeadIfItemIsLowerPriorityThanHead()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueueInsertsItemInCollectionAsHeadIfItemIsHigherPriorityThanOriginalHead()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueueDoesNotInsertsItemInCollectionAsHeadIfItemIsLowerPriorityThanOriginalHead()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueueEnumerationSupportsEnumeration()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueueEnumerationYieldsHighestPriorityAsFirstItem()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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
        public void SynchronisedMaxPriorityQueueEnumerationYieldsLowestPriorityAsLastItem()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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

        [Test]
        public void SynchronisedMaxPriorityQueuePeekReturnsItemWithHighestPriorityMultiThread()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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

            Assert.AreEqual("A_50", item);
        }

        [Test]
        public void SynchronisedMaxPriorityQueueDequeueReturnsItemWithHighestPriorityMultiThread()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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

            Assert.AreEqual("A_50", item);
        }

        [Test]
        public void SynchronisedMaxPriorityQueueInsertsItemInCollectionAsHeadIfItemIsHigherPriorityThanOriginalHeadMultiThreaded()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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

            List<Task> newtasks = new List<Task>();
            newItems.ForEach(i => newtasks.Add(Task.Factory.StartNew(() => priorityQueue.Enqueue(i.Item1, i.Item2))));
            Task.WaitAll(newtasks.ToArray());

            string newHead = priorityQueue.Peek();

            Assert.AreEqual("A_50", originalHead);
            Assert.AreEqual("A_51", newHead);
        }

        [Test]
        public void SynchronisedMaxPriorityQueueDoesNotInsertsItemInCollectionAsHeadIfItemIsLowerPriorityThanOriginalHeadMultiThreaded()
        {
            var priorityQueue = new SynchronisedMaxPriorityQueue<string, int>(50);

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

            List<Task> newtasks = new List<Task>();
            newItems.ForEach(i => newtasks.Add(Task.Factory.StartNew(() => priorityQueue.Enqueue(i.Item1, i.Item2))));
            Task.WaitAll(newtasks.ToArray());

            string newHead = priorityQueue.Peek();

            Assert.AreEqual("A_50", originalHead);
            Assert.AreEqual("A_50", newHead);
        }

        private sealed class TestPriority : IComparable<TestPriority>
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
