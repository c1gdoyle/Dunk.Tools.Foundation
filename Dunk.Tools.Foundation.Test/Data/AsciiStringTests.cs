using System;
using System.Linq;
using Dunk.Tools.Foundation.Data;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Data
{
    [TestFixture]
    public class AsciiStringTests
    {
        [Test]
        public void AsciiStringInitialisesWithValidAsciiInput()
        {
            string value = "9quali52ty3";
            var ascii = new AsciiString(value);

            Assert.IsNotNull(ascii);
        }

        [Test]
        public void AsciiStringThrowsIfInvalidAsciiInput()
        {
            string value = "€";
            Assert.Throws<ArgumentException>(() => new AsciiString(value));
        }

        [Test]
        public void AsciiStringIsSameLengthAsInputString()
        {
            string value = "9quali52ty3";
            var ascii = new AsciiString(value);

            Assert.AreEqual(value.Length, ascii.Length);
        }

        [Test]
        public void AsciiStringIsNullReturnsFalseIfDataIsNotNull()
        {
            string value = "9quali52ty3";
            var ascii = new AsciiString(value);

            Assert.IsFalse(ascii.IsNull);
        }

        [Test]
        public void AsciiStringLookupByIndexReturnsExpectedCharacter()
        {
            const char expected = 'u';

            string value = "9quali52ty3";
            var ascii = new AsciiString(value);

            Assert.AreEqual(expected, ascii[2]);
        }

        [Test]
        public void AsciiStringSubStringThrowsIfStartIndexIsNegative()
        {
            string value = "9quali52ty3";
            var ascii = new AsciiString(value);

            Assert.Throws<ArgumentOutOfRangeException>(() => ascii.SubString(-1, 1));
        }

        [Test]
        public void AsciiStringSubStringThrowsIfStartIndexIsOutOfRange()
        {
            string value = "9quali52ty3";
            var ascii = new AsciiString(value);

            Assert.Throws<ArgumentOutOfRangeException>(() => ascii.SubString(value.Length, 1));
        }

        [Test]
        public void AsciiStringSubStringThrowsIfStartIndexPlusLengthIsOutOfRange()
        {
            string value = "9quali52ty3";
            var ascii = new AsciiString(value);

            Assert.Throws<ArgumentOutOfRangeException>(() => ascii.SubString(0, value.Length + 1));
        }

        [Test]
        public void AsciiStringSubStringReturnsExpectedSubString()
        {
            string value = "9quali52ty3";
            string expected = value.Substring(0, value.Length - 1);

            var ascii = new AsciiString(value);

            var subString = ascii.SubString(0, value.Length - 1);

            Assert.AreEqual(expected, subString.ToString());
        }

        [Test]
        public void AsciiStringSubStringReturnsExpectedFullSubString()
        {
            string value = "9quali52ty3";
            string expected = value.Substring(0, value.Length);

            var ascii = new AsciiString(value);

            var subString = ascii.SubString(0, value.Length);

            Assert.AreEqual(expected, subString.ToString());
        }

        [Test]
        public void AsciiStringObjectEqualsReturnsFalseIfObjectIsNull()
        {
            string value = "9quali52ty3";
            var ascii = new AsciiString(value);

            Assert.IsFalse(ascii.Equals(null));
        }

        [Test]
        public void AsciiStringObjectEqualsReturnsFalseIfObjectIsNotAsciiString()
        {
            string value = "9quali52ty3";
            var ascii = new AsciiString(value);

            Assert.IsFalse(ascii.Equals(value));
        }


        [Test]
        public void AsciiStringObjectEqualsReturnsTrueIfObjectIsEqual()
        {
            string value = "9quali52ty3";
            var ascii = new AsciiString(value);

            Assert.IsTrue(ascii.Equals((object)new AsciiString(value)));
        }

        [Test]
        public void AsciiStringGetHashCodeReturnsSameCodeIfAsciiStringsAreEqual()
        {
            string value = "9quali52ty3";

            AsciiString asciiString1 = new AsciiString(value);
            AsciiString asciiString2 = new AsciiString(value);

            Assert.AreEqual(asciiString1.GetHashCode(), asciiString2.GetHashCode());
        }

        [Test]
        public void AsciiStringGetHashCodeReturnsDifferentCodeIfAsciiStringsAreNotEqual()
        {
            string value = "9quali52ty3";

            AsciiString asciiString1 = new AsciiString(value);
            AsciiString asciiString2 = new AsciiString(value.Reverse());

            Assert.AreNotEqual(asciiString1.GetHashCode(), asciiString2.GetHashCode());
        }

        [Test]
        public void AsciiStringsOfSameInputStringAreEqual()
        {
            string value = "9quali52ty3";
            var ascii1 = new AsciiString(value);
            var ascii2 = new AsciiString(value);

            Assert.AreEqual(ascii1, ascii2);
        }

        [Test]
        public void AsciiStringsOfDifferentInputStringAreNotEqual()
        {
            string value1 = "9quali52ty3";
            string value2 = "3yt25ilauq9";

            var ascii1 = new AsciiString(value1);
            var ascii2 = new AsciiString(value2);

            Assert.AreNotEqual(ascii1, ascii2);
        }

        [Test]
        public void AsciiStringsOfSameInputEqualsOperatorReturnsTrue()
        {
            string value = "9quali52ty3";
            var ascii1 = new AsciiString(value);
            var ascii2 = new AsciiString(value);

            Assert.IsTrue(ascii1 == ascii2);
        }

        [Test]
        public void AsciiStringsOfDifferentInputEqualsOperatorReturnsFalse()
        {
            string value1 = "9quali52ty3";
            string value2 = "3yt25ilauq9";

            var ascii1 = new AsciiString(value1);
            var ascii2 = new AsciiString(value2);

            Assert.IsFalse(ascii1 == ascii2);
        }


        [Test]
        public void AsciiStringsOfSameInputNotEqualsOperatorReturnsFalse()
        {
            string value = "9quali52ty3";
            var ascii1 = new AsciiString(value);
            var ascii2 = new AsciiString(value);

            Assert.IsFalse(ascii1 != ascii2);
        }

        [Test]
        public void AsciiStringsOfDifferentInputNotEqualsOperatorReturnsTrue()
        {
            string value1 = "9quali52ty3";
            string value2 = "3yt25ilauq9";

            var ascii1 = new AsciiString(value1);
            var ascii2 = new AsciiString(value2);

            Assert.IsTrue(ascii1 != ascii2);
        }
    }
}
