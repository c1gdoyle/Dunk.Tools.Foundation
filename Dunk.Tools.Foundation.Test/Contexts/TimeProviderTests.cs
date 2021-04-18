using System;
using Dunk.Tools.Foundation.Contexts;
using Dunk.Tools.Foundation.Test.Stubs;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Contexts
{
    [TestFixture]
    public class TimeProviderTests
    {
        [Test]
        public void TimeProviderSupportsSettingCustomProvider()
        {
            var testDateTimeNow = new DateTime(2019, 10, 15, 10, 00, 00);

            var timeProvider = new TimeProviderStub(testDateTimeNow);
            TimeProvider.Current = timeProvider;

            Assert.AreEqual(testDateTimeNow, TimeProvider.Current.UtcNow);
        }

        [Test]
        public void DefaultTimeProviderReturnsUtcDateTime()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = TimeProvider.Current.UtcNow;
            });
        }

        [Test]
        public void TimeProviderThrowsIfCustomProviderIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => TimeProvider.Current = null);
        }

        [TearDown]
        public void Cleanup()
        {
            TimeProvider.ResetToDefault();
        }
    }
}
