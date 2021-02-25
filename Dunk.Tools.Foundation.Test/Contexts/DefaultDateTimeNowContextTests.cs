using Dunk.Tools.Foundation.Contexts;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Contexts
{
    [TestFixture]
    public class DefaultDateTimeNowContextTests
    {
        [Test]
        public void DefaultDateTimeNowContextInitialises()
        {
            var context = new DefaultDateTimeNowContext();

            Assert.IsNotNull(context);
        }

        [Test]
        public void DefaultDateTimeNowContextNowReturns()
        {
            var context = new DefaultDateTimeNowContext();
            Assert.DoesNotThrow(() =>
            {
                var dt = context.Now;
            });
        }

        [Test]
        public void DefaultDateTimeNowContextTodayReturns()
        {
            var context = new DefaultDateTimeNowContext();
            Assert.DoesNotThrow(() =>
            {
                var dt = context.Today;
            });
        }

        [Test]
        public void DefaultDateTimeNowContextUtcNowReturns()
        {
            var context = new DefaultDateTimeNowContext();
            Assert.DoesNotThrow(() =>
            {
                var dt = context.UtcNow;
            });
        }
    }
}
