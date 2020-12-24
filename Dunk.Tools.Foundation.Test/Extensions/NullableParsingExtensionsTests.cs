using System;
using System.Globalization;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class NullableParsingExtensionsTests
    {
        [Test]
        public void ParseCharReturnsValueIfStringIsValid()
        {
            string s = "c";
            char? c = s.ParseNullableChar();

            Assert.IsTrue(c.HasValue);
            Assert.AreEqual('c', c.Value);
        }

        [Test]
        public void ParseCharReturnsNoValueIfStringIsInvalid()
        {
            string s = "";
            char? c = s.ParseNullableChar();

            Assert.IsFalse(c.HasValue);
        }

        [Test]
        public void ParseBooleanReturnsValueIfStringIsValid()
        {
            string s = true.ToString();
            bool? b = s.ParseNullableBoolean();

            Assert.IsTrue(b.HasValue);
            Assert.AreEqual(true, b.Value);
        }

        [Test]
        public void ParseBooleanReturnsNoValueIfStringIsInvalid()
        {
            string s = "aardvark";
            bool? b = s.ParseNullableBoolean();

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseByteReturnsValueIfStringIsValid()
        {
            string s = byte.MinValue.ToString();
            byte? b = s.ParseNullableByte();

            Assert.IsTrue(b.HasValue);
            Assert.AreEqual(byte.MinValue, b.Value);
        }

        [Test]
        public void ParseByteReturnsNoValueIfStringIsInvalid()
        {
            string s = "aardvark";
            byte? b = s.ParseNullableByte();

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseShortReturnsValueIfStringIsValid()
        {
            string s = short.MinValue.ToString();
            short? b = s.ParseNullableInt16();

            Assert.IsTrue(b.HasValue);
            Assert.AreEqual(short.MinValue, b.Value);
        }

        [Test]
        public void ParseShortReturnsNoValueIfStringIsInvalid()
        {
            string s = "aardvark";
            short? b = s.ParseNullableInt16();

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseIntReturnsValueIfStringIsValid()
        {
            string s = int.MinValue.ToString();
            int? b = s.ParseNullableInt32();

            Assert.IsTrue(b.HasValue);
            Assert.AreEqual(int.MinValue, b.Value);
        }

        [Test]
        public void ParseIntReturnsNoValueIfStringIsInvalid()
        {
            string s = "aardvark";
            int? b = s.ParseNullableInt32();

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseLongReturnsValueIfStringIsValid()
        {
            string s = long.MaxValue.ToString();
            long? b = s.ParseNullableInt64();

            Assert.IsTrue(b.HasValue);
            Assert.AreEqual(long.MaxValue, b.Value);
        }

        [Test]
        public void ParseLongReturnsNoValueIfStringIsInvalid()
        {
            string s = "aardvark";
            long? b = s.ParseNullableInt64();

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseDecimalReturnsValueIfStringIsValid()
        {
            string s = 300.5m.ToString(CultureInfo.InvariantCulture);
            decimal? b = s.ParseNullableDecimal();

            Assert.IsTrue(b.HasValue);
            Assert.AreEqual(300.5m, b.Value);
        }

        [Test]
        public void ParseDecimalReturnsNoValueIfStringIsInvalid()
        {
            string s = "aardvark";
            decimal? b = s.ParseNullableDecimal();

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseFloatReturnsValueIfStringIsValid()
        {
            string s = 300.5F.ToString(CultureInfo.InvariantCulture);
            float? b = s.ParseNullableFloat();

            Assert.IsTrue(b.HasValue);
            Assert.AreEqual(300.5F, b.Value);
        }

        [Test]
        public void ParseFloatReturnsNoValueIfStringIsInvalid()
        {
            string s = "aardvark";
            float? b = s.ParseNullableFloat();

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseDoubleReturnsValueIfStringIsValid()
        {
            string s = 3.1415926536.ToString(CultureInfo.InvariantCulture);
            double? b = s.ParseNullableDouble();

            Assert.IsTrue(b.HasValue);
            Assert.AreEqual(3.1415926536, b.Value);
        }

        [Test]
        public void ParseDoubleReturnsNoValueIfStringIsInvalid()
        {
            string s = "aardvark";
            double? b = s.ParseNullableDouble();

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseDateTimeReturnsValueIfStringIsValid()
        {
            DateTime dt = new DateTime(2019, 09, 25);

            string s = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime? b = s.ParseNullableDateTime();

            Assert.IsTrue(b.HasValue);
            Assert.AreEqual(dt, b.Value);
        }

        [Test]
        public void ParseDateTimeReturnsNoValueIfStringIsInvalid()
        {
            string s = "aardvark";
            DateTime? b = s.ParseNullableDateTime();

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseExactDateTimeReutnrsValueIfStringIsValid()
        {
            DateTime dt = new DateTime(2019, 09, 25);

            string s = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime? b = s.ParseNullableDateTimeExact("yyyy-MM-dd");

            Assert.IsTrue(b.HasValue);
            Assert.AreEqual(dt, b.Value);
        }

        [Test]
        public void ParseExactDateTimeReturnsNoValueIfStringIsInvalid()
        {
            string s = "aardvark";
            DateTime? b = s.ParseNullableDateTimeExact("yyyy-MM-dd");

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseExactDateTimeReturnsNoValueIfFormatIsInvalid()
        {
            DateTime dt = new DateTime(2019, 09, 25);

            string s = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime? b = s.ParseNullableDateTimeExact("yyyy-dd-MM");

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseExactDateTimeWithSpecifiedFormatProviderReturnsValueIfStringIsValid()
        {
            DateTime dt = new DateTime(2019, 09, 25);

            string s = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime? b = s.ParseNullableDateTimeExact("yyyy-MM-dd", CultureInfo.InvariantCulture);

            Assert.IsTrue(b.HasValue);
            Assert.AreEqual(dt, b.Value);
        }

        [Test]
        public void ParseExactDateTimeWithSpecifiedFormatProviderReturnsNoValueIfStringIsInvalid()
        {
            string s = "aardvark";
            DateTime? b = s.ParseNullableDateTimeExact("yyyy-MM-dd", CultureInfo.InvariantCulture);

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseExactDateTimeWithSpecifiedFormatProviderReturnsNoValueIfFormatIsInvalid()
        {
            DateTime dt = new DateTime(2019, 09, 25);

            string s = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime? b = s.ParseNullableDateTimeExact("yyyy-dd-MM", CultureInfo.InvariantCulture);

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseExactDateTimeWithSpecifiedDateStylesReturnsValueIfStringIsValid()
        {
            DateTime dt = new DateTime(2019, 09, 25);

            string s = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime? b = s.ParseNullableDateTimeExact("yyyy-MM-dd", DateTimeStyles.None);

            Assert.IsTrue(b.HasValue);
            Assert.AreEqual(dt, b.Value);
        }

        [Test]
        public void ParseExactDateTimeWithSpecifiedDateStylesReturnsNoValueIfStringIsInvalid()
        {
            string s = "aardvark";
            DateTime? b = s.ParseNullableDateTimeExact("yyyy-MM-dd", DateTimeStyles.None);

            Assert.IsFalse(b.HasValue);
        }

        [Test]
        public void ParseExactDateTimeWithSpecifiedDateStylesReturnsNoValueIfFormatIsInvalid()
        {
            DateTime dt = new DateTime(2019, 09, 25);

            string s = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime? b = s.ParseNullableDateTimeExact("yyyy-dd-MM", DateTimeStyles.None);

            Assert.IsFalse(b.HasValue);
        }
    }
}