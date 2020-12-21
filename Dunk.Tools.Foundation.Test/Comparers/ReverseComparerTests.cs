using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Comparers;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Comparers
{
    [TestFixture]
    public class ReverseComparerTests
    {
        [Test]
        public void ReverseComparerThrowsIfOriginalComparerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ReverseComparer<int>(null));
        }

        [Test]
        public void ReverseComparerInitialises()
        {
            var comparer = new ReverseComparer<int>(Comparer<int>.Default);
            Assert.IsNotNull(comparer);
        }

        [Test]
        public void ReverseComparerReturnsNegativeOneWhenFirstItemIsGreaterThanSecondItem()
        {
            var comparer = new ReverseComparer<int>(Comparer<int>.Default);

            int first = 2;
            int second = 1;

            int result = comparer.Compare(first, second);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void ReverseComparerReturnsPositiveOneWhenFirstItemIsLessThanSecondItem()
        {
            var comparer = new ReverseComparer<int>(Comparer<int>.Default);

            int first = 1;
            int second = 2;

            int result = comparer.Compare(first, second);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void ReverseComparerReturnsZeroWhenFirstItemEqualsSecondItem()
        {
            var comparer = new ReverseComparer<int>(Comparer<int>.Default);

            int first = 1;
            int second = 1;

            int result = comparer.Compare(first, second);

            Assert.AreEqual(0, result);
        }
    }
}
