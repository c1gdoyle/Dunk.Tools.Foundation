using System;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class EnumExtensionsTests
    {
        private const string TestText = "Something or other";

        [Test]
        public void EnumGetAttributeReturnsAttributeOnEnumField()
        {
            TestEnum value = TestEnum.One;

            TestEnumOneAttribute attribute = value.GetAttribute<TestEnumOneAttribute>();

            Assert.IsNotNull(attribute);
            Assert.AreEqual(TestText, attribute.Text);
        }

        [Test]
        public void EnumGetAttributeReturnsNullIfNoAttributeOnEnumField()
        {
            TestEnum value = TestEnum.Zero;

            TestEnumOneAttribute attribute = value.GetAttribute<TestEnumOneAttribute>();

            Assert.IsNull(attribute);
        }

        [Test]
        public void EnumGetAttributeReturnsNullIfSpecifiedAttributeIsNotOnEnumField()
        {
            TestEnum value = TestEnum.One;

            TestEnumTwoAttribute attribute = value.GetAttribute<TestEnumTwoAttribute>();

            Assert.IsNull(attribute);
        }

        [Test]
        public void EnumGetAttributesReturnsArrayIfAttributeOnEnumField()
        {
            const int expectedLength = 2;

            TestEnum value = TestEnum.Two;

            TestEnumTwoAttribute[] attributes = value.GetAttributes<TestEnumTwoAttribute>();

            Assert.IsNotNull(attributes);
            Assert.AreEqual(expectedLength, attributes.Length);
        }

        [Test]
        public void EnumGetAttributesReturnsEmptyArrayIfNoAttributeOnEnumField()
        {
            TestEnum value = TestEnum.Zero;

            TestEnumTwoAttribute[] attributes = value.GetAttributes<TestEnumTwoAttribute>();

            Assert.IsNotNull(attributes);
            Assert.IsEmpty(attributes);
        }

        [Test]
        public void EnumGetAttributesReturnsEmptyArrayIfSpecifiedAttributeIsNotOnEnumField()
        {
            TestEnum value = TestEnum.One;

            TestEnumTwoAttribute[] attributes = value.GetAttributes<TestEnumTwoAttribute>();

            Assert.IsNotNull(attributes);
            Assert.IsEmpty(attributes);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S1144: Allow constructors for unit-testing")]
        private sealed class TestEnumOneAttribute : Attribute
        {
            public TestEnumOneAttribute(string text)
            {
                Text = text;
            }
            public string Text { get; }
        }

        private class TestEnumTwoAttribute : Attribute
        {
            public TestEnumTwoAttribute()
            {
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S1144: Allow constructors for unit-testing")]
        private class TestEnumThreeAttribute : TestEnumTwoAttribute
        {
            public TestEnumThreeAttribute()
            {
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2344: Allow name for unit-testing")]
        private enum TestEnum
        {
            Zero = 0,

            [TestEnumOne(TestText)]
            One = 1,

            [TestEnumTwo()]
            [TestEnumThree()]
            Two = 2
        }
    }
}
