using System;
using Dunk.Tools.Foundation.Comparers;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Comparers
{
    [TestFixture]
    public class NonNullKeySelectorComparerTests
    {
        [Test]
        public void NonNullKeySelectorComparerInitialises()
        {
            var comparer = new NonNullKeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);
            Assert.IsNotNull(comparer);
        }

        [Test]
        public void NonNullKeySelectorComparerReturnsPositiveOneWhenFirstKeyIsGreaterThanSecondKey()
        {
            var comparer = new NonNullKeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);

            var first = new KeySelectorTestItem { Id = 2 };
            var second = new KeySelectorTestItem { Id = 1 };

            var result = comparer.Compare(first, second);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void NonNullKeySelectorComparerReturnsNegativeOneWhenFirstKeyIsLessThanSecondKey()
        {
            var comparer = new NonNullKeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);

            var first = new KeySelectorTestItem { Id = 1 };
            var second = new KeySelectorTestItem { Id = 2 };

            var result = comparer.Compare(first, second);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void NonNullKeySelectorComparerReturnsZeroWhenFirstKeyIsEqualToSecondKey()
        {
            var comparer = new NonNullKeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);

            var first = new KeySelectorTestItem { Id = 1 };
            var second = new KeySelectorTestItem { Id = 1 };

            var result = comparer.Compare(first, second);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void NonNullKeySelectorComparerThrowsWhenFirstItemIsNullAndSecondItemIsNull()
        {
            var comparer = new NonNullKeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);

            KeySelectorTestItem first = null;
            KeySelectorTestItem second = null;

            Assert.Throws<ArgumentNullException>(() => comparer.Compare(first, second));
        }

        [Test]
        public void NonNullKeySelectorComparerThrowsWhenFirstItemIsNullAndSecondItemIsNot()
        {
            var comparer = new NonNullKeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);

            KeySelectorTestItem first = null;
            KeySelectorTestItem second = new KeySelectorTestItem { Id = 1 };

            Assert.Throws<ArgumentNullException>(() => comparer.Compare(first, second));
        }

        [Test]
        public void NonNullKeySelectorComparerThrowsPositiveOneWhenFirstItemIsNotNullAndSecondItemIsNull()
        {
            var comparer = new NonNullKeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);

            KeySelectorTestItem first = new KeySelectorTestItem { Id = 1 };
            KeySelectorTestItem second = null;

            Assert.Throws<ArgumentNullException>(() => comparer.Compare(first, second));
        }

        private sealed class KeySelectorTestItem
        {
            public int Id { get; set; }
        }
    }
}
