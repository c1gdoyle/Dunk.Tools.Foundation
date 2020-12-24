using System;
using System.Threading.Tasks;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// An interface that defines the behaviour of a processing queue that 
    /// manages the number of concurrent operations that can be processed at once.
    /// </summary>
    public interface IThrottledProcessingQueue
    {
        /// <summary>
        /// Gets the maximum number of concurrent operations supported
        /// by this queue.
        /// </summary>
        int MaxOperations { get; }

        /// <summary>
        /// Gets the number of operations currently enqueued for later processing.
        /// </summary>
        long OperationsEnqueued { get; }

        /// <summary>
        /// Gets the number of operations currently being processed.
        /// </summary>
        long OperationsInProcess { get; }

        /// <summary>
        /// Registers an operation for processing against the current <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="operation">A task representing the operation.</param>
        /// <remarks>
        /// If the number of operations currently in process is less than the <see cref="MaxOperations"/>
        /// the operation will be started immediately; otherwise the operation will be enqueued for later processing.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="operation"/> was null.</exception>
        /// <exception cref="ArgumentException"><paramref name="operation"/> was already started or been completed.</exception>
        void RegisterOperation(Task operation);

        /// <summary>
        /// Registers an operation for processing against a specified <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="operation">A task representing the operation.</param>
        /// <param name="scheduler">The scheduler.</param>
        /// <remarks>
        /// If the number of operations currently in process is less than the <see cref="MaxOperations"/>
        /// the operation will be started immediately; otherwise the operation will be enqueued for later processing.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="operation"/> or <paramref name="scheduler"/> was null.</exception>
        /// <exception cref="ArgumentException"><paramref name="operation"/> was already started or been completed.</exception>
        void RegisterOperation(Task operation, TaskScheduler scheduler);
    }
}
