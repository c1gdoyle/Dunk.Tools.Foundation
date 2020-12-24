using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dunk.Tools.Foundation.Collections;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for <see cref="ThrottledProcessingQueue"/> instances.
    /// </summary>
    public static class ThrottledProcessingQueueExtensions
    {
        /// <summary>
        /// Registers a collection of operations for processing against the current <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="queue">The queue to register the operations against.</param>
        /// <param name="operations">A collection of tasks representing the operations.</param>
        /// <exception cref="ArgumentNullException"><paramref name="operations"/> was null or contained a null entry.</exception>
        /// <exception cref="ArgumentException"><paramref name="operations"/> contained a task that has already been started or completed.</exception>
        public static void RegisterOperations(this ThrottledProcessingQueue queue, IEnumerable<Task> operations)
        {
            RegisterOperations(queue, operations, TaskScheduler.Current);
        }

        /// <summary>
        /// Registers a collection of operations for processing against a specified <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="queue">The queue to register the operations against.</param>
        /// <param name="operations">A collection of tasks representing the operations.</param>
        /// <param name="scheduler">A scheduler.</param>
        /// <exception cref="ArgumentNullException"><paramref name="operations"/> was null or contained a null entry.</exception>
        /// <exception cref="ArgumentException"><paramref name="operations"/> contained a task that has already been started or completed.</exception>
        public static void RegisterOperations(this ThrottledProcessingQueue queue, IEnumerable<Task> operations, TaskScheduler scheduler)
        {
            queue.ThrowIfNull(nameof(queue), $"{nameof(queue)} parameter cannot be null");
            operations.ThrowIfNullOrContainsNull(nameof(operations), $"{nameof(operations)} parameter cannot be null");

            foreach (var operation in operations)
            {
                queue.RegisterOperation(operation, scheduler);
            }
        }

        /// <summary>
        /// Registers a collection of operations for processing against the current <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="queue">The queue to register the operations against.</param>
        /// <param name="operations">A collection of tasks representing the operations.</param>
        /// <exception cref="ArgumentNullException"><paramref name="operations"/> was null or contained a null entry.</exception>
        /// <exception cref="ArgumentException"><paramref name="operations"/> contained a task that has already been started or completed.</exception>
        public static void RegisterOperations(this SmartThrottledProcessingQueue queue, IEnumerable<Task> operations)
        {
            RegisterOperations(queue, operations, TaskScheduler.Current);
        }

        /// <summary>
        /// Registers a collection of operations for processing against a specified <see cref="TaskScheduler"/>.
        /// </summary>
        /// <param name="queue">The queue to register the operations against.</param>
        /// <param name="operations">A collection of tasks representing the operations.</param>
        /// <param name="scheduler">A scheduler.</param>
        /// <exception cref="ArgumentNullException"><paramref name="operations"/> was null or contained a null entry.</exception>
        /// <exception cref="ArgumentException"><paramref name="operations"/> contained a task that has already been started or completed.</exception>
        public static void RegisterOperations(this SmartThrottledProcessingQueue queue, IEnumerable<Task> operations, TaskScheduler scheduler)
        {
            queue.ThrowIfNull(nameof(queue), $"{nameof(queue)} parameter cannot be null");
            operations.ThrowIfNullOrContainsNull(nameof(operations), $"{nameof(operations)} parameter cannot be null");

            foreach (var operation in operations)
            {
                queue.RegisterOperation(operation, scheduler);
            }
        }
    }
}
