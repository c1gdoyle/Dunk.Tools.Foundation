using Dunk.Tools.Foundation.Comparers;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Comparers
{
    [TestFixture]
    public class KeySelectorComparerTests
    {
        [Test]
        public void KeySelectorComparerInitialises()
        {
            var comparer = new KeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);
            Assert.IsNotNull(comparer);
        }

        [Test]
        public void KeySelectorComparerReturnsPositiveOneWhenFirstKeyIsGreaterThanSecondKey()
        {
            var comparer = new KeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);

            var first = new KeySelectorTestItem { Id = 2 };
            var second = new KeySelectorTestItem { Id = 1 };

            var result = comparer.Compare(first, second);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void KeySelectorComparerReturnsNegativeOneWhenFirstKeyIsLessThanSecondKey()
        {
            var comparer = new KeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);

            var first = new KeySelectorTestItem { Id = 1 };
            var second = new KeySelectorTestItem { Id = 2 };

            var result = comparer.Compare(first, second);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void KeySelectorComparerReturnsZeroWhenFirstKeyIsEqualToSecondKey()
        {
            var comparer = new KeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);

            var first = new KeySelectorTestItem { Id = 1 };
            var second = new KeySelectorTestItem { Id = 1 };

            var result = comparer.Compare(first, second);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void KeySelectorComparerReturnsZeroWhenFirstItemIsNullAndSecondItemIsNull()
        {
            var comparer = new KeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);

            KeySelectorTestItem first = null;
            KeySelectorTestItem second = null;

            var result = comparer.Compare(first, second);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void KeySelectorComparerRetunsNegativeOneWhenFirstItemIsNullAndSecondItemIsNot()
        {
            var comparer = new KeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);

            KeySelectorTestItem first = null;
            KeySelectorTestItem second = new KeySelectorTestItem { Id = 1 };

            var result = comparer.Compare(first, second);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void KeySelectorComparerReturnsPositiveOneWhenFirstItemIsNotNullAndSecondItemIsNull()
        {
            var comparer = new KeySelectorComparer<KeySelectorTestItem, int>(i => i.Id);

            KeySelectorTestItem first = new KeySelectorTestItem { Id = 1 };
            KeySelectorTestItem second = null;

            var result = comparer.Compare(first, second);

            Assert.AreEqual(1, result);
        }

        private class KeySelectorTestItem
        {
            public int Id { get; set; }
        }
    }
}
