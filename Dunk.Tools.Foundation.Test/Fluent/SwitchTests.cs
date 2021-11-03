using Dunk.Tools.Foundation.Fluent;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Fluent
{
    [TestFixture]
    public class SwitchTests
    {
        [Test]
        public void SwitchInitialises()
        {
            string s = "abc";
            Assert.IsNotNull(Switch<string>.On(s));
        }

        [Test]
        public void SwitchCaseActionIsInvokedIfInputMatches()
        {
            bool value = false;

            string s = "abc";
            Switch<string>.On(s)
                .Case("abc", () => value = true);

            Assert.IsTrue(value);
        }

        [Test]
        public void SwitchCaseActionIsNotInvokedIfInputDoesNotMatches()
        {
            bool value = false;

            string s = "abc";
            Switch<string>.On(s)
                .Case("aaa", () => value = true)
                .Case("bbb", () => value = true)
                .Case("ccc", () => value = true)
                .Case("ddd", () => value = true);

            Assert.IsFalse(value);
        }

        [Test]
        public void SwitchDefaultIsInvokedIfInputDoesNotMatch()
        {
            bool value = false;

            string s = "abc";
            Switch<string>.On(s)
                .Case("aaa", () => value = true)
                .Case("bbb", () => value = true)
                .Case("ccc", () => value = true)
                .Case("ddd", () => value = true)
                .Default(() => value = true);

            Assert.IsTrue(value);
        }

        [Test]
        public void SwitchDefaultIsNotInvokedIfInputDoesMatch()
        {
            bool value = false;

            string s = "abc";
            Switch<string>.On(s)
                .Case("abc", () => value = true)
                .Case("aaa", () => value = true)
                .Case("bbb", () => value = true)
                .Case("ccc", () => value = true)
                .Case("ddd", () => value = true)
                .Default(() => value = false);

            Assert.IsTrue(value);
        }
    }
}
