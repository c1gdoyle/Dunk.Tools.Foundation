using System.Threading.Tasks;
using Dunk.Tools.Foundation.Contexts;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Contexts
{
    [TestFixture]
    public class DefaultTaskSchedulerContextTests
    {
        [Test]
        public void DefaultTaskSchedulerContextInitialises()
        {
            var context = new DefaultTaskSchedulerContext();

            Assert.IsNotNull(context);
        }

        [Test]
        public void DefaultTaskSchedulerContextReturnsCurrentScheduler()
        {
            var context = new DefaultTaskSchedulerContext();

            Assert.IsNotNull(context.Current);
            Assert.AreEqual(TaskScheduler.Current, context.Current);
        }

        [Test]
        public void DefaultTaskSchedulerContextReturnsDefaultScheduler()
        {
            var context = new DefaultTaskSchedulerContext();

            Assert.IsNotNull(context.Default);
            Assert.AreEqual(TaskScheduler.Default, context.Default);
        }
    }
}
