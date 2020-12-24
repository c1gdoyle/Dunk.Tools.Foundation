using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// A processing queue that manages the number of concurrent operations 
    /// that can be processed at once. When an operation completes it will attempt to
    /// start the next operation int the queue.
    /// </summary>
    public class SmartThrottledProcessingQueue
    {
        private readonly ConcurrentQueue<Task> _queuedOperations = new ConcurrentQueue<Task>();

        private long _operationsInProcess = 0;

        private readonly int _maxOperations;

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
        {
            if (maxOperations <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxOperations),
                    $"Unable to initialise Throttled-Processing queue. {nameof(maxOperations)} must be at least 1 but was {maxOperations}");
            }
            _maxOperations = maxOperations;
        }

        /// <summary>
        /// Gets the maximum number of concurrent operations supported
        /// by this queue.
        /// </summary>
        public int MaxOperations { get { return _maxOperations; } }

        /// <summary>
        /// Gets the number of operations currently being processed.
        /// </summary>
        public long OperationsInProcess { get { return _operationsInProcess; } }

        /// <summary>
        /// Gets the number of operations currently enqueued for later processing.
        /// </summary>
        public long OperationsEnqueued { get { return _queuedOperations.Count; } }

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
        public void RegisterOperation(Task operation)
        {
            RegisterOperation(operation, TaskScheduler.Current);
        }

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
        public void RegisterOperation(Task operation, TaskScheduler scheduler)
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
                _queuedOperations.Enqueue(operation);
            }
            else
            {
                //queue is not full, so start operation and increment number of tasks in process
                Interlocked.Increment(ref _operationsInProcess);
                operation.Start(scheduler);
            }
        }

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
            if (_queuedOperations.TryDequeue(out operation))
            {
                RegisterOperation(operation);
            }
        }
    }
}
