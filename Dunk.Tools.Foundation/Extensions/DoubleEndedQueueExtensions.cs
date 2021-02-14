using System.Collections.Generic;
using Dunk.Tools.Foundation.Collections;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for a <see cref="IDeque{T}"/> instance.
    /// </summary>
    public static class DoubleEndedQueueExtensions
    {
        /// <summary>
        /// Enqueues a sequence of items to the front of the <see cref="IDeque{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="deque">The double-ended queue to add the items to.</param>
        /// <param name="items">The items to enqueue.</param>
        public static void EnqueueRangeToFront<T>(this IDeque<T> deque, IEnumerable<T> items)
        {
            deque.ThrowIfNull(nameof(deque));
            items.ThrowIfNull(nameof(items));

            foreach (T item in items)
            {
                deque.EnqueueItemToFront(item);
            }
        }
        /// <summary>
        /// Enqueues a sequence of items to the back of the <see cref="IDeque{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="deque">The double-ended queue to add the items to.</param>
        /// <param name="items">The items to enqueue.</param>
        public static void EnqueueRangeToBack<T>(this IDeque<T> deque, IEnumerable<T> items)
        {
            deque.ThrowIfNull(nameof(deque));
            items.ThrowIfNull(nameof(items));

            foreach (T item in items)
            {
                deque.EnqueueItemToBack(item);
            }
        }
    }
}
