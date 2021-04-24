using System.Collections.Generic;
using System.Linq;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class NumericExtensionsTests
    {
        [Test]
        public void ConvertToEngineeringNotationReturnsExpectedString()
        {
            Dictionary<double, string> dictionary = new Dictionary<double, string>
            {
                {1110d, "1.11k" },
                {1110000d, "1.11M" },
                {1110000000d, "1.11G" },
                {1110000000000d, "1.11T" },
                {1110000000000000d, "1.11P" },
                {1110000000000000000d, "1.11E" },
                {1110000000000000000000d, "1.11Z" },
                {1110000000000000000000000d, "1.11Y" }
            };

            dictionary.ToList().ForEach(kvp =>
            {
                string result = kvp.Key.ConvertToEngineeringNotation();
                Assert.AreEqual(kvp.Value, result);
            });
        }

        [Test]
        public void NearlyEqualsReturnsTrueIfNumbersMatchInPrecision()
        {
            double left = 123.456;
            double right = 123.455;
            int precision = 2;

            Assert.IsTrue(left.NearlyEquals(right, precision));
        }

        [Test]
        public void NearlyEqualsReturnsTrueIfNumbersMatch()
        {
            double left = 123.456;
            double right = 123.456;
            int precision = 10;

            Assert.IsTrue(left.NearlyEquals(right, precision));
        }

        [Test]
        public void NearlyEqualsReturnsFalseIfNumbersDoNotMatchInPrecision()
        {
            double left = 123.456;
            double right = 123.455;
            int precision = 3;

            Assert.IsFalse(left.NearlyEquals(right, precision));
        }

        [Test]
        public void IsOddReturnsTrueForOddNumber()
        {
            int number = 1;

            Assert.IsTrue(number.IsOdd());
        }

        [Test]
        public void IsOddReturnsFalseForEvenNumber()
        {
            int number = 2;

            Assert.IsFalse(number.IsOdd());
        }

        [Test]
        public void IsEvenReturnsTrueForEvenNumber()
        {
            int number = 2;

            Assert.IsTrue(number.IsEven());
        }

        [Test]
        public void IsEvenReturnsFalseForOddNumber()
        {
            int number = 1;

            Assert.IsFalse(number.IsEven());
        }

        [Test]
        public void IsDivisibleByReturnsTrueIfDivisible()
        {
            int number = 25;

            Assert.IsTrue(number.IsDivisibleBy(5));
        }

        [Test]
        public void IsDivisibleByReturnsFalseIfNotDivisible()
        {
            int number = 26;

            Assert.IsFalse(number.IsDivisibleBy(5));
        }
    }
}
