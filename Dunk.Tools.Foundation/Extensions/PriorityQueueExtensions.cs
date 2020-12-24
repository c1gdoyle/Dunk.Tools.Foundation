using System;
using System.Collections.Generic;
using Dunk.Tools.Foundation.Collections;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for a <see cref="IPriorityQueue{TItem, TPriority}"/>
    /// </summary>
    public static class PriorityQueueExtensions
    {
        /// <summary>
        /// Enqueues a range of items to the priority queue with specified priorities.
        /// </summary>
        /// <typeparam name="TItem">The type of items stored in the queue.</typeparam>
        /// <typeparam name="TPriority">The type used to determine the priority in the queue,</typeparam>
        /// <param name="queue">The priority-queue.</param>
        /// <param name="items">The items to add and their associated priority.</param>
        public static void EnqueueRange<TItem, TPriority>(this IPriorityQueue<TItem, TPriority> queue, IEnumerable<Tuple<TItem, TPriority>> items)
            where TPriority : IComparable<TPriority>
        {
            queue.ThrowIfNull(nameof(queue));
            items.ThrowIfNull(nameof(items));

            foreach (var item in items)
            {
                queue.Enqueue(item.Item1, item.Item2);
            }
        }
    }
}
