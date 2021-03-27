using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class CollectionExtensionsTests
    {
        [Test]
        public void AddRangeItemsToCollection()
        {
            ICollection<int> sequence = new HashSet<int> { 1, 2, 3 };
            int[] itemsToAdd = { 4, 5, 6 };

            sequence.AddRange(itemsToAdd);

            Assert.AreEqual(6, sequence.Count);
        }

        [Test]
        public void AddRangeAddsItemsToList()
        {
            ICollection<int> sequence = new List<int> { 1, 2, 3 };
            int[] itemsToAdd = { 4, 5, 6 };

            sequence.AddRange(itemsToAdd);

            Assert.AreEqual(6, sequence.Count);
        }

        [Test]
        public void AddRangeThrowsIfCollectionToAddIsNull()
        {
            ICollection<int> sequence = new List<int> { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => sequence.AddRange(null as IEnumerable<int>));
        }
    }
}
