using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// A <see cref="IThrottledProcessingQueue"/> implementation that manages the number 
    /// of concurrent operations that can be processed at once. When an operation 
    /// completes it will attempt to start the next operation int the queue.
    /// </summary>
    public class SmartThrottledProcessingQueue : ThrottledProcessingQueueBase
    {
        private long _operationsInProcess = 0;

        /// <summary>
        /// Initialises a new default instance of <see cref="SmartThrottledProcessingQueue"/> that
        /// supports up to 50 concurrent operations.
        /// </summary>
        public SmartThrottledProcessingQueue()
            : this(50)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="SmartThrottledProcessingQueue"/> that supports
        /// a specified number of concurrent operations.
        /// </summary>
        /// <param name="maxOperations">The maximum numer of operations processed by this queue at once.</param>
        public SmartThrottledProcessingQueue(int maxOperations)
            :base(maxOperations)
        {
        }

        #region ThrottledProcessingQueueBase Overrides
        /// <inheritdoc />
        public override long OperationsInProcess { get { return _operationsInProcess; } }

        /// <inheritdoc />
        public override void RegisterOperation(Task operation, TaskScheduler scheduler)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation), $"{nameof(operation)} parameter cannot be null.");
            }
            if (scheduler == null)
            {
                throw new ArgumentNullException(nameof(scheduler), $"{nameof(scheduler)} parameter cannot be null.");
            }
            if (operation.Status != TaskStatus.Created)
            {
                throw new ArgumentException(
                    $"{nameof(operation)} has already been started and cannot be registerd in Processing Queue. Expected Task status is {TaskStatus.Created} but was {operation.Status}",
                    nameof(operation));
            }

            //once operation completes update the processing queue
            operation.ContinueWith(t => UpdateProcessingQueue());

            if (Interlocked.Read(ref _operationsInProcess) >= MaxOperations)
            {
                //processing queue is currently full, so enqueue operation for later processing
                QueuedOperations.Enqueue(operation);
            }
            else
            {
                //queue is not full, so start operation and increment number of tasks in process
                Interlocked.Increment(ref _operationsInProcess);
                operation.Start(scheduler);
            }
        }
        #endregion ThrottledProcessingQueueBase Overrides

        /// <summary>
        /// Updates the processing queue after an operation finishes (either due to success or failure)
        /// and attempts to process the next enqueued operation.
        /// </summary>
        private void UpdateProcessingQueue()
        {
            //decrement number of tasks in process
            Interlocked.Decrement(ref _operationsInProcess);
            //ensure in process never drops below 0
            Interlocked.CompareExchange(ref _operationsInProcess, 0, -1);

            //Attempt to remove and register the next enqueued operation
            Task operation;
            if (QueuedOperations.TryDequeue(out operation))
            {
                RegisterOperation(operation);
            }
        }
    }
}
