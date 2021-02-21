using System;
using Dunk.Tools.Foundation.Ranges;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Ranges
{
    [TestFixture]
    public class GenericRangeTests
    {
        private readonly int _start = 10;
        private readonly int _end = 15;

        [Test]
        public void GenericRangeInitialises()
        {
            var range = new GenericRange<int>(_start, _end);
            Assert.IsNotNull(range);
        }

        [Test]
        public void GenericRangeThrowsIfStartIsAfterEndDate()
        {
            Assert.Throws<ArgumentException>(() =>
                new GenericRange<int>(_end, _start));
        }

        [Test]
        public void GenericRangeIsWithinReturnsTrueIfDateIncluded()
        {
            int testValue = 14;

            var range = new GenericRange<int>(_start, _end);

            Assert.IsTrue(range.IsWithin(testValue));
        }

        [Test]
        public void GenericRangeIsWithinReturnsFalseIfDateIsBeforeStart()
        {
            int testValue = 9;

            var range = new GenericRange<int>(_start, _end);

            Assert.IsFalse(range.IsWithin(testValue));
        }

        [Test]
        public void GenericRangeIsWithinReturnsFalseIfDateIsAfterEnd()
        {
            int testValue = 16;

            var range = new GenericRange<int>(_start, _end);

            Assert.IsFalse(range.IsWithin(testValue));
        }

        [Test]
        public void GenericRangeIsWithinReturnsTrueIfStartDateAndEndDateIsIncluded()
        {
            var range = new GenericRange<int>(_start, _end);

            Assert.IsTrue(range.IsWithin(new GenericRange<int>(_start + 1, _end - 1)));
        }

        [Test]
        public void GenericRangeIsWithinReturnsFalseIfRangeIsNull()
        {
            var range = new GenericRange<int>(_start, _end);

            Assert.IsFalse(range.IsWithin(null as IRange<int>));
        }

        [Test]
        public void GenericRangeIsWithinReturnsFalseIfStartDateIsBefore()
        {
            var range = new GenericRange<int>(_start, _end);

            Assert.IsFalse(range.IsWithin(new GenericRange<int>(_start -1, _end)));
        }

        [Test]
        public void GenericRangeIsWithinReturnsFalseIfEndDateIsAfter()
        {
            var range = new GenericRange<int>(_start, _end);

            Assert.IsFalse(range.IsWithin(new GenericRange<int>(_start, _end + 1)));
        }
    }
}
