using System;
using System.Collections.Generic;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// Defines the behaviour of a priroity-queue that supports generics.
    /// </summary>
    /// <typeparam name="TItem">The type of items stored in the queue.</typeparam>
    /// <typeparam name="TPriority">The type used to determine priority in the queue.</typeparam>
    public interface IPriorityQueue<TItem, in TPriority> : IEnumerable<TItem>
        where TPriority : IComparable<TPriority>
    {
        /// <summary>
        /// Gets the number of items actually contained in the priority-queue.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Getes whether or not the priority-queue contains no items.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Removes all items from the priority-queue.
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns the first item at the head of the queue, without removing it.
        /// </summary>
        /// <returns>
        /// The item at the head of the queue.
        /// </returns>
        TItem Peek();

        /// <summary>
        /// Enqueues an item to the priority-queue with a specified priority. Lower values are placed at the front.
        /// </summary>
        /// <param name="item">The item to add to the queue.</param>
        /// <param name="priority">The priority associated with the item.</param>
        void Enqueue(TItem item, TPriority priority);

        /// <summary>
        /// Returns the first item at the head of the queue and removes it.
        /// </summary>
        /// <returns>
        /// The item at the head of the queue.
        /// </returns>
        TItem Dequeue();
    }
}
