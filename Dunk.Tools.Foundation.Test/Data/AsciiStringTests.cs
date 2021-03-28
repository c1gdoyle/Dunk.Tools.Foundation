using System;
using Dunk.Tools.Foundation.Data;
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
            string value = "€"; ;
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
