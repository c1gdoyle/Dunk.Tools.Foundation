using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Comparers;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Comparers
{
    [TestFixture]
    public class ChainedComparerTests
    {
        [Test]
        public void ComparerThrowsIfPrimaryComparerIsNull()
        {
            IComparer<ChainedComparerTestItem> primary = null;
            IComparer<ChainedComparerTestItem> secondary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.B);

            Assert.Throws<ArgumentNullException>(() => new ChainedComparer<ChainedComparerTestItem>(primary, secondary));
        }

        [Test]
        public void ComparerThrowsIfSecondaryComparerIsNull()
        {
            IComparer<ChainedComparerTestItem> primary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.A);
            IComparer<ChainedComparerTestItem> secondary = null;

            Assert.Throws<ArgumentNullException>(() => new ChainedComparer<ChainedComparerTestItem>(primary, secondary));
        }

        [Test]
        public void ComparerInitialises()
        {
            IComparer<ChainedComparerTestItem> primary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.A);
            IComparer<ChainedComparerTestItem> secondary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.B);

            var comparer = new ChainedComparer<ChainedComparerTestItem>(primary, secondary);

            Assert.IsNotNull(comparer);
        }

        [Test]
        public void ComparerReturnsPositiveOneWhenFirstItemIsGreaterThanSecondItemOnPrimaryComparer()
        {
            IComparer<ChainedComparerTestItem> primary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.A);
            IComparer<ChainedComparerTestItem> secondary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.B);

            var comparer = new ChainedComparer<ChainedComparerTestItem>(primary, secondary);

            var first = new ChainedComparerTestItem { A = 2 };
            var second = new ChainedComparerTestItem { A = 1 };

            int result = comparer.Compare(first, second);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void ComparerReturnsNegativeOneWhenFirstItemIsLessThanSecondItemOnPrimaryComparer()
        {
            IComparer<ChainedComparerTestItem> primary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.A);
            IComparer<ChainedComparerTestItem> secondary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.B);

            var comparer = new ChainedComparer<ChainedComparerTestItem>(primary, secondary);

            var first = new ChainedComparerTestItem { A = 1 };
            var second = new ChainedComparerTestItem { A = 2 };

            int result = comparer.Compare(first, second);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void ComparerReturnsPositiveOneWhenFirstItemIsGreaterThanSecondItemOnSecondaryComparer()
        {
            IComparer<ChainedComparerTestItem> primary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.A);
            IComparer<ChainedComparerTestItem> secondary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.B);

            var comparer = new ChainedComparer<ChainedComparerTestItem>(primary, secondary);

            var first = new ChainedComparerTestItem { A = 1, B = 2 };
            var second = new ChainedComparerTestItem { A = 1, B = 1 };

            int result = comparer.Compare(first, second);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void ComparerReturnsNegativeOneWhenFirstItemIsLessThanSecondItemOnSecondaryComparer()
        {
            IComparer<ChainedComparerTestItem> primary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.A);
            IComparer<ChainedComparerTestItem> secondary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.B);

            var comparer = new ChainedComparer<ChainedComparerTestItem>(primary, secondary);

            var first = new ChainedComparerTestItem { A = 1, B = 1 };
            var second = new ChainedComparerTestItem { A = 1, B = 2 };

            int result = comparer.Compare(first, second);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void ComparerReturnsZeroWhenFirstItemIsEqualToSecondItemOnBothPrimaryAndSecondaryComparers()
        {
            IComparer<ChainedComparerTestItem> primary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.A);
            IComparer<ChainedComparerTestItem> secondary = new KeySelectorComparer<ChainedComparerTestItem, int>(i => i.B);

            var comparer = new ChainedComparer<ChainedComparerTestItem>(primary, secondary);

            var first = new ChainedComparerTestItem { A = 1, B = 1 };
            var second = new ChainedComparerTestItem { A = 1, B = 1 };

            int result = comparer.Compare(first, second);

            Assert.AreEqual(0, result);
        }

        private sealed class ChainedComparerTestItem
        {
            public int A { get; set; }

            public int B { get; set; }
        }
    }
}
