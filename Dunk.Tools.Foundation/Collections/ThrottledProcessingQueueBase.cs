using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// An abstract base class for <see cref="IThrottledProcessingQueue"/> implementations.
    /// </summary>
    public abstract class ThrottledProcessingQueueBase : IThrottledProcessingQueue
    {
        /// <summary>
        /// Initialises a new instance of <see cref="ThrottledProcessingQueueBase"/> that supports
        /// a specified number of concurrent operations.
        /// </summary>
        /// <param name="maxOperations">The maximum numer of operations processed by this queue at once.</param>
        protected ThrottledProcessingQueueBase(int maxOperations)
        {
            if (maxOperations <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxOperations),
                    $"Unable to initialise Throttled-Processing queue. {nameof(maxOperations)} must be at least 1 but was {maxOperations}");
            }
            MaxOperations = maxOperations;
        }

        /// <summary>
        /// Gets the operations currently enqueued for later execution.
        /// </summary>
        protected internal ConcurrentQueue<Task> QueuedOperations { get; } = new ConcurrentQueue<Task>();

        #region IThrottledProcessingQueue Members
        /// <inheritdoc />
        public int MaxOperations { get; }

        /// <inheritdoc />
        public long OperationsEnqueued { get { return QueuedOperations.Count; } }

        /// <inheritdoc />
        public abstract long OperationsInProcess { get; }

        /// <inheritdoc />
        public void RegisterOperation(Task operation)
        {
            RegisterOperation(operation, TaskScheduler.Current);
        }

        /// <inheritdoc />
        public abstract void RegisterOperation(Task operation, TaskScheduler scheduler);
        #endregion IThrottledProcessingQueue Members
    }
}
