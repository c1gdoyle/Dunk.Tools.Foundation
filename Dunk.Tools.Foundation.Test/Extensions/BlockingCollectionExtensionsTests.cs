using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class BlockingCollectionExtensionsTests
    {
        [Test]
        public void BlockingCollectionAddRangeThrowsIfCollectionIsNull()
        {
            BlockingCollection<int> collection = null;
            IEnumerable<int> sequence = new List<int> { 1, 2, 3, 4, 5 };

            Assert.Throws<ArgumentNullException>(() => collection.AddRange(sequence));
        }

        [Test]
        public void BlockingCollectionAddRangeThrowsIfSequenceIsNull()
        {
            BlockingCollection<int> collection = new BlockingCollection<int>(new ConcurrentQueue<int>());
            IEnumerable<int> sequence = null;

            Assert.Throws<ArgumentNullException>(() => collection.AddRange(sequence));
        }

        [Test]
        public void BlockingCollectionAddRangeAddsCollections()
        {
            BlockingCollection<int> collection = new BlockingCollection<int>(new ConcurrentQueue<int>());
            IEnumerable<int> sequence = new List<int> { 1, 2, 3, 4, 5 };

            collection.AddRange(sequence);

            Assert.AreEqual(5, collection.Count);
        }

        [Test]
        public void BlockingCollectionAddRangeAddsCollectionsWithNullElements()
        {
            BlockingCollection<string> collection = new BlockingCollection<string>(new ConcurrentQueue<string>());
            IEnumerable<string> sequence = new List<string> { "Tom", "Dick", "Harry", null };

            collection.AddRange(sequence);

            Assert.AreEqual(4, collection.Count);
        }

        [Test]
        public void BlockingCollectionAddRangeWithCancellationTokenThrowsIfCollectionIsNull()
        {
            BlockingCollection<int> collection = null;
            IEnumerable<int> sequence = new List<int> { 1, 2, 3, 4, 5 };

            Assert.Throws<ArgumentNullException>(() => collection.AddRange(sequence, new CancellationToken()));
        }

        [Test]
        public void BlockingCollectionAddRangeWithCancellationTokenThrowsIfSequenceIsNull()
        {
            BlockingCollection<int> collection = new BlockingCollection<int>(new ConcurrentQueue<int>());
            IEnumerable<int> sequence = null;

            Assert.Throws<ArgumentNullException>(() => collection.AddRange(sequence, new CancellationToken()));
        }

        [Test]
        public void BlockingCollectionAddRangeWithCancellationTokenAddsCollections()
        {
            BlockingCollection<int> collection = new BlockingCollection<int>(new ConcurrentQueue<int>());
            IEnumerable<int> sequence = new List<int> { 1, 2, 3, 4, 5 };

            collection.AddRange(sequence, new CancellationToken());

            Assert.AreEqual(5, collection.Count);
        }

        [Test]
        public void BlockingCollectionAddRangeWithCancellationTokenAddsCollectionsWithNullElements()
        {
            BlockingCollection<string> collection = new BlockingCollection<string>(new ConcurrentQueue<string>());
            IEnumerable<string> sequence = new List<string> { "Tom", "Dick", "Harry", null };

            collection.AddRange(sequence, new CancellationToken());

            Assert.AreEqual(4, collection.Count);
        }
    }
}
