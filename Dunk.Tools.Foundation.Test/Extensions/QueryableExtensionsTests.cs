using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class QueryableExtensionsTests
    {
        [Test]
        public void QueryableBetweenReturnsCollectionWithLowerLimit()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            var between = list.AsQueryable().Between(i => i, 5, 15);

            Assert.AreEqual(5, between.Min());
        }

        [Test]
        public void QueryableBetweenReturnsCollectionWithUpperLimit()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            var between = list.AsQueryable().Between(i => i, 5, 15);

            Assert.AreEqual(15, between.Max());
        }

        [Test]
        public void QueryableBetweenThrowsIfSourceIsNull()
        {
            IQueryable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Between(i => i, 5, 15));
        }

        [Test]
        public void QueryableBetweenThrowsIfKeySelectorIsNull()
        {
            IQueryable<int> source = new List<int>().AsQueryable();
            Assert.Throws<ArgumentNullException>(() => source.Between(null, 5, 15));
        }

        [Test]
        public void QueryableOrderBySortByDescendingUsingSpecifiedPropertyName()
        {
            var list = new List<TestItem>
            {
                new TestItem {Id=1, Name="Item_1" },
                new TestItem {Id=2, Name="Item_2" },
                new TestItem {Id=3, Name="Item_3" },
                new TestItem {Id=4, Name="Item_4" },
                new TestItem {Id=5, Name="Item_5" },
                new TestItem {Id=6, Name="Item_6" },
            }
            .Randomize()
            .ToList();

            var orderedCollection = list.AsQueryable()
                .Orderby(nameof(TestItem.Id), true);

            var firstItem = orderedCollection.First();

            Assert.AreEqual(6, firstItem.Id);
        }

        [Test]
        public void QueryableOrderBySortByAscendingUsingSpecifiedPropertyName()
        {
            var list = new List<TestItem>
            {
                new TestItem {Id=1, Name="Item_1" },
                new TestItem {Id=2, Name="Item_2" },
                new TestItem {Id=3, Name="Item_3" },
                new TestItem {Id=4, Name="Item_4" },
                new TestItem {Id=5, Name="Item_5" },
                new TestItem {Id=6, Name="Item_6" },
            }
            .Randomize()
            .ToList();

            var orderedCollection = list.AsQueryable()
                .Orderby(nameof(TestItem.Id), false);

            var firstItem = orderedCollection.First();

            Assert.AreEqual(1, firstItem.Id);
        }

        [Test]
        public void QueryableOrderByThrowsIfSourceIsNull()
        {
            IQueryable<TestItem> queryable = null;
            Assert.Throws<ArgumentNullException>(() => queryable.Orderby(nameof(TestItem.Id), false));
        }

        [Test]
        public void QueryOrderByThrowsIfPropertyIsNull()
        {
            IQueryable<TestItem> queryable = new List<TestItem>().AsQueryable();
            Assert.Throws<ArgumentNullException>(() => queryable.Orderby(null as PropertyInfo, false));
        }

        private sealed class TestItem
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
