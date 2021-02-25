using System.Threading.Tasks;

namespace Dunk.Tools.Foundation.Contexts
{
    /// <summary>
    /// A default implementation of <see cref="ITaskSchedulerContext"/>.
    /// </summary>
    public sealed class DefaultTaskSchedulerContext : ITaskSchedulerContext
    {
        #region ITaskSchedulerContext Members
        /// <inheritdoc />
        public TaskScheduler Current
        {
            get { return TaskScheduler.Current; }
        }

        /// <inheritdoc />
        public TaskScheduler Default
        {
            get { return TaskScheduler.Default; }
        }
        #endregion ITaskSchedulerContext Members
    }
}
