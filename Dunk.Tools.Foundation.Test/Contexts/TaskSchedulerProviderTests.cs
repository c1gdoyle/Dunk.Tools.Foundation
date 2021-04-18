using System;
using Dunk.Tools.Foundation.Contexts;
using Dunk.Tools.Foundation.Test.Stubs;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Contexts
{
    [TestFixture]
    public class TaskSchedulerProviderTests
    {
        [Test]
        public void TaskSchedulerProviderSupportsCustomProvider()
        {
            const int expected = 42;

            var taskSchedulerProvider = new TaskSchedulerProviderStub(expected);
            TaskSchedulerProvider.Current = taskSchedulerProvider;

            Assert.AreEqual(42, TaskSchedulerProvider.Current.TaskScheduler.MaximumConcurrencyLevel);
        }

        [Test]
        public void DefaultTaskSchedulerProviderReturnsScheduler()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = TaskSchedulerProvider.Current.TaskScheduler;
            });
        }

        [Test]
        public void TaskSchedulerProviderThrowsIfCustomProviderIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => TaskSchedulerProvider.Current = null);
        }

        [TearDown]
        public void Cleanup()
        {
            TaskSchedulerProvider.ResetToDefault();
        }
    }
}
