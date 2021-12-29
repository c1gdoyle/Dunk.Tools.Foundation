using System.Threading.Tasks;
using Dunk.Tools.Foundation.Base;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Base
{
    [TestFixture]
    public class ComparableBaseTests
    {
        [Test]
        public void SecondGetHashCodeReturnsExpectedHash()
        {
            const int expected = 47;

            Second second = new Second(expected);

            Assert.AreEqual(expected, second.GetHashCode());
        }
        [Test]
        public void SecondEqualsReturnsFalseIfOtherIsNull()
        {
            Second second = new Second(47);
            Second other = null;

            Assert.IsFalse(second.Equals(other));
        }

        [Test]
        public void SecondEqualsReturnsFalseIfOtherIsNotTypeOfSecond()
        {
            Second second = new Second(47);
            Task other = new Task(() => { });

            Assert.IsFalse(second.Equals(other));
        }

        [Test]
        public void SecondEqualsReturnsTrueIfOtherIsSameReference()
        {
            Second second = new Second(47);
            Second other = second;

            Assert.IsTrue(second.Equals(other));
        }

        [Test]
        public void SecondEqualsReturnsTrueIfOtherIsSameValue()
        {
            Second second = new Second(47);
            Second other = new Second(47);

            Assert.IsTrue(second.Equals(other));
        }

        [Test]
        public void SecondEqualsReturnsFalseIfOtherIsDifferentValue()
        {
            Second second = new Second(47);
            Second other = new Second(45);

            Assert.IsFalse(second.Equals(other));
        }
        [Test]
        public void SecondCompareToReturnsOneIfOtherIsNull()
        {
            const int expected = 1;

            Second second = new Second(47);
            Second other = null;

            Assert.AreEqual(expected, second.CompareTo(other));
        }

        [Test]
        public void SecondCompareToReturnsOneIfOtherIsNotTypeOfSecond()
        {
            const int expected = 1;

            Second second = new Second(47);
            Task other = new Task(() => { });

            Assert.AreEqual(expected, second.CompareTo(other));
        }

        [Test]
        public void SecondCompareToReturnsOneIfOtherIsLessThanValue()
        {
            const int expected = 1;

            Second second = new Second(47);
            Second other = new Second(46);

            Assert.AreEqual(expected, second.CompareTo(other));
        }

        [Test]
        public void SecondCompareToReturnsZeroIfOtherIsSameReference()
        {
            const int expected = 0;

            Second second = new Second(47);
            Second other = second;

            Assert.AreEqual(expected, second.CompareTo(other));
        }

        [Test]
        public void SecondCompareToReturnsZeroIfOtherIsSameValue()
        {
            const int expected = 0;

            Second second = new Second(47);
            Second other = new Second(47);

            Assert.AreEqual(expected, second.CompareTo(other));
        }

        [Test]
        public void SecondCompareToReturnsMinusOneIfOtherIsMoreThanValue()
        {
            const int expected = -1;

            Second second = new Second(47);
            Second other = new Second(48);

            Assert.AreEqual(expected, second.CompareTo(other));
        }
        [Test]
        public void SecondEqualsOperatorReturnsTrueIfLeftAndRightAreSameValue()
        {
            Second left = new Second(47);
            Second right = new Second(47);

            Assert.IsTrue(left == right);
        }

        [Test]
        public void SecondEqualsOperatorReturnsTrueIfLeftAndRightAreSameReference()
        {
            Second left = new Second(47);
            Second right = left;

            Assert.IsTrue(left == right);
        }

        [Test]
        public void SecondEqualsOperatorReturnsFalseIfLeftAndRightAreNotSameValue()
        {
            Second left = new Second(47);
            Second right = new Second(46);

            Assert.IsFalse(left == right);
        }

        [Test]
        public void SecondEqualsOperatorReturnsTrueIfLeftAndRightAreNull()
        {
            Second left = null;
            Second right = null;

            Assert.IsTrue(left == right);
        }

        [Test]
        public void SecondEqualsOperatorReturnsFalseIfLeftIsNullAndRightIsNotNull()
        {
            Second left = null;
            Second right = new Second(47);

            Assert.IsFalse(left == right);
        }

        [Test]
        public void SecondEqualsOperatorReturnsFalseIfLeftIsNotNullAndRightIsNull()
        {
            Second left = new Second(47);
            Second right = null;

            Assert.IsFalse(left == right);
        }

        [Test]
        public void SecondNotEqualsOperatorReturnsFalseIfLeftAndRightAreSameValue()
        {
            Second left = new Second(47);
            Second right = new Second(47);

            Assert.IsFalse(left != right);
        }

        [Test]
        public void SecondNotEqualsOperatorReturnsFalseIfLeftAndRightAreSameReference()
        {
            Second left = new Second(47);
            Second right = left;

            Assert.IsFalse(left != right);
        }

        [Test]
        public void SecondNotEqualsOperatorReturnsTrueIfLeftAndRightAreNotSameValue()
        {
            Second left = new Second(47);
            Second right = new Second(46);

            Assert.IsTrue(left != right);
        }

        [Test]
        public void SecondNotEqualsOperatorReturnsFalseIfLeftAndRightAreNull()
        {
            Second left = null;
            Second right = null;

            Assert.IsFalse(left != right);
        }

        [Test]
        public void SecondNotEqualsOperatorReturnsTrueIfLeftIsNullAndRightIsNotNull()
        {
            Second left = null;
            Second right = new Second(47);

            Assert.IsTrue(left != right);
        }

        [Test]
        public void SecondNotEqualsOperatorReturnsTrueIfLeftIsNotNullAndRightIsNull()
        {
            Second left = new Second(47);
            Second right = null;

            Assert.IsTrue(left != right);
        }

        [Test]
        public void SecondLessThanOperatorReturnsFalseIfLeftIsGreaterThanRight()
        {
            Second left = new Second(47);
            Second right = new Second(46);

            Assert.IsFalse(left < right);
        }

        [Test]
        public void SecondLessThanOperatorReturnsFalseIfLeftIsSameValueAsRight()
        {
            Second left = new Second(47);
            Second right = new Second(47);

            Assert.IsFalse(left < right);
        }

        [Test]
        public void SecondLessThanOperatorReturnsFalseIfLeftIsSameReferenceAsRight()
        {
            Second left = new Second(47);
            Second right = left;

            Assert.IsFalse(left < right);
        }

        [Test]
        public void SecondLessThanOperatorReturnsTrueIfLeftIsLessThanRight()
        {
            Second left = new Second(47);
            Second right = new Second(48);

            Assert.IsTrue(left < right);
        }

        [Test]
        public void SecondLessThanOperatorReturnsFalseIfLeftAndRightAreNull()
        {
            Second left = null;
            Second right = null;

            Assert.IsFalse(left < right);
        }

        [Test]
        public void SecondLessThanOperatorReturnsTrueIfLeftIsNullAndRightIsNotNull()
        {
            Second left = null;
            Second right = new Second(46);

            Assert.IsTrue(left < right);
        }

        [Test]
        public void SecondLessThanOperatorReturnsFalseIfLeftIsNotNullAndRightIsNull()
        {
            Second left = new Second(47);
            Second right = null;

            Assert.IsFalse(left < right);
        }

        [Test]
        public void SecondGreaterThanOperatorReturnsTrueIfLeftIsGreaterThanRight()
        {
            Second left = new Second(47);
            Second right = new Second(46);

            Assert.IsTrue(left > right);
        }

        [Test]
        public void SecondGreaterThanOperatorReturnsFalseIfLeftIsSameValueAsRight()
        {
            Second left = new Second(47);
            Second right = new Second(47);

            Assert.IsFalse(left > right);
        }

        [Test]
        public void SecondGreaterThanOperatorReturnsFalseIfLeftIsSameReferenceAsRight()
        {
            Second left = new Second(47);
            Second right = left;

            Assert.IsFalse(left > right);
        }

        [Test]
        public void SecondGreaterThanOperatorReturnsFalseIfLeftIsLessThanRight()
        {
            Second left = new Second(47);
            Second right = new Second(48);

            Assert.IsFalse(left > right);
        }

        [Test]
        public void SecondGreaterThanOperatorReturnsFalseIfLeftAndRightAreNull()
        {
            Second left = null;
            Second right = null;

            Assert.IsFalse(left > right);
        }

        [Test]
        public void SecondGreaterThanOperatorReturnsFalseIfLeftIsNullAndRightIsNotNull()
        {
            Second left = null;
            Second right = new Second(46);

            Assert.IsFalse(left > right);
        }

        [Test]
        public void SecondGreaterThanOperatorReturnsTrueIfLeftIsNotNullAndRightIsNull()
        {
            Second left = new Second(47);
            Second right = null;

            Assert.IsTrue(left > right);
        }

        [Test]
        public void SecondLessThanOrEqualOperatorReturnsFalseIfLeftIsGreaterThanRight()
        {
            Second left = new Second(47);
            Second right = new Second(46);

            Assert.IsFalse(left <= right);
        }

        [Test]
        public void SecondLessThanOrEqualOperatorReturnsTrueIfLeftIsSameValueAsRight()
        {
            Second left = new Second(47);
            Second right = new Second(47);

            Assert.IsTrue(left <= right);
        }

        [Test]
        public void SecondLessThanOrEqualOperatorReturnsTrueIfLeftIsSameReferenceAsRight()
        {
            Second left = new Second(47);
            Second right = left;

            Assert.IsTrue(left <= right);
        }

        [Test]
        public void SecondLessThanOrEqualOperatorReturnsTrueIfLeftIsLessThanRight()
        {
            Second left = new Second(47);
            Second right = new Second(48);

            Assert.IsTrue(left <= right);
        }

        [Test]
        public void SecondLessThanOrEqualOperatorReturnsTrueIfLeftAndRightAreNull()
        {
            Second left = null;
            Second right = null;

            Assert.IsTrue(left <= right);
        }

        [Test]
        public void SecondLessThanOrEqualOperatorReturnsTrueIfLeftIsNullAndRightIsNotNull()
        {
            Second left = null;
            Second right = new Second(46);

            Assert.IsTrue(left <= right);
        }

        [Test]
        public void SecondLessThanOrEqualOperatorReturnsFalseIfLeftIsNotNullAndRightIsNull()
        {
            Second left = new Second(47);
            Second right = null;

            Assert.IsFalse(left <= right);
        }

        [Test]
        public void SecondGreaterThanOrEqualOperatorReturnsTrueIfLeftIsGreaterThanRight()
        {
            Second left = new Second(47);
            Second right = new Second(46);

            Assert.IsTrue(left >= right);
        }

        [Test]
        public void SecondGreaterThanOrEqualOperatorReturnsTrueIfLeftIsSameValueAsRight()
        {
            Second left = new Second(47);
            Second right = new Second(47);

            Assert.IsTrue(left >= right);
        }

        [Test]
        public void SecondGreaterThanOrEqualOperatorReturnsTrueIfLeftIsSameReferenceAsRight()
        {
            Second left = new Second(47);
            Second right = left;

            Assert.IsTrue(left >= right);
        }

        [Test]
        public void SecondGreaterThanOrEqualOperatorReturnsFalseIfLeftIsLessThanRight()
        {
            Second left = new Second(47);
            Second right = new Second(48);

            Assert.IsFalse(left >= right);
        }

        [Test]
        public void SecondGreaterThanOrEqualOperatorReturnsTrueIfLeftAndRightAreNull()
        {
            Second left = null;
            Second right = null;

            Assert.IsTrue(left >= right);
        }

        [Test]
        public void SecondGreaterThanOrEqualOperatorReturnsFalseIfLeftIsNullAndRightIsNotNull()
        {
            Second left = null;
            Second right = new Second(46);

            Assert.IsFalse(left >= right);
        }

        [Test]
        public void SecondGreaterThanOrEqualOperatorReturnsTrueIfLeftIsNotNullAndRightIsNull()
        {
            Second left = new Second(47);
            Second right = null;

            Assert.IsTrue(left >= right);
        }

        private class Second : ComparableBase<Second>
        {
            public Second(int value)
            {
                Value = value;
            }
            public int Value { get; }

            public override int GetHashCode() => Value.GetHashCode();

            public override int CompareTo(Second other)
            {
                if (other == null)
                {
                    return 1;
                }
                return Value.CompareTo(other.Value);
            }
        }
    }
}
