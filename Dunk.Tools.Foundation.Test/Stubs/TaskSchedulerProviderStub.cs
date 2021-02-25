using System.Collections.Generic;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Contexts;

namespace Dunk.Tools.Foundation.Test.Stubs
{
    public class TaskSchedulerProviderStub : TaskSchedulerProvider
    {
        private readonly TaskScheduler _scheduler;

        public TaskSchedulerProviderStub(int concurrencyLevel)
        {
            _scheduler = new TaskSchedulerStub(concurrencyLevel);
        }

        public override TaskScheduler TaskScheduler
        {
            get { return _scheduler; }
        }
    }

    public class TaskSchedulerStub : TaskScheduler
    {
        private readonly int _concurrencyLevel;

        public TaskSchedulerStub(int concurrencyLevel)
        {
            _concurrencyLevel = concurrencyLevel;
        }

        public override int MaximumConcurrencyLevel
        {
            get { return _concurrencyLevel; }
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return null;
        }

        protected override void QueueTask(Task task)
        {
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }
    }
}
