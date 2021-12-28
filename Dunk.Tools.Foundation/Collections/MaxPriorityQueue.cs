using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// A basic implementation of <see cref="IPriorityQueue{TItem, TPriority}"/> that provides functionality 
    /// for a maximum Priority-Queue whereby the item with the highest priority is at the head of the queue and 
    /// supportrs generic-types for both queue items and priority
    /// </summary>
    /// <typeparam name="TItem">The type of items stored in the queue.</typeparam>
    /// <typeparam name="TPriority">The type used to determine priority in the queue.</typeparam>
    [DebuggerDisplay("Count = {Count}")]
    public class MaxPriorityQueue<TItem, TPriority> : IPriorityQueue<TItem, TPriority>
        where TPriority : IComparable<TPriority>
    {
        private readonly IComparer<MaxPriorityQueueNode> _comparer;
        private readonly MaxDHeap<MaxPriorityQueueNode> _maxHeap;

        private const int DefaultInitialQueueSize = 10;

        /// <summary>
        /// Initialises a new instance of <see cref="MaxPriorityQueue{TItem, TPriority}"/> with default
        /// queue size and priority comparer.
        /// </summary>
        public MaxPriorityQueue()
            : this(DefaultInitialQueueSize)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="MaxPriorityQueue{TItem, TPriority}"/> with a specified
        /// queue size and default priority comparer.
        /// </summary>
        /// <param name="initialQueueSize">The initial size of the queue.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="initialQueueSize"/> was less than 1.</exception>
        public MaxPriorityQueue(int initialQueueSize)
            : this(Comparer<TPriority>.Default, initialQueueSize)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="MaxPriorityQueue{TItem, TPriority}"/> with default
        /// queue size and specified priority comparer.
        /// </summary>
        /// <param name="priorityComparer">The <see cref="IComparer{T}"/> to use when comparing 2 priorities.</param>
        /// <exception cref="ArgumentNullException"><paramref name="priorityComparer"/> was null.</exception>
        public MaxPriorityQueue(IComparer<TPriority> priorityComparer)
            : this(priorityComparer, DefaultInitialQueueSize)
        {
        }

        /// <summary>
        /// Initialises a new instance of <see cref="MaxPriorityQueue{TItem, TPriority}"/> with specified
        /// queue size and specified priority comparer.
        /// </summary>
        /// <param name="priorityComparer">The <see cref="IComparer{T}"/> to use when comparing 2 priorities.</param>
        /// <param name="initialQueueSize">The initial size of the queue.</param>
        /// <exception cref="ArgumentNullException"><paramref name="priorityComparer"/> was null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="initialQueueSize"/> was less than 1.</exception>
        public MaxPriorityQueue(IComparer<TPriority> priorityComparer, int initialQueueSize)
        {
            if (priorityComparer == null)
            {
                throw new ArgumentNullException(nameof(priorityComparer),
                    $"Unable to initialise Maximum Priority-Queue. {nameof(priorityComparer)} cannot be null.");
            }
            if (initialQueueSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialQueueSize),
                    $"Unable to initialise Maximum Priority-Queue. {nameof(initialQueueSize)} must be greater than zero.");
            }
            _comparer = new Comparers.NonNullKeySelectorComparer<MaxPriorityQueueNode, TPriority>(x => x.Value, priorityComparer);
            _maxHeap = new MaxDHeap<MaxPriorityQueueNode>(2, initialQueueSize, _comparer);
        }

        #region IPriorityQueue<TItem, TPriority> Members
        /// <summary>
        /// Gets the number of items actually contained in the priority-queue.
        /// </summary>
        public int Count { get { return _maxHeap.Count; } }

        /// <summary>
        /// Getes whether or not the priority-queue contains no items.
        /// </summary>
        public bool IsEmpty { get { return _maxHeap.IsEmpty; } }

        /// <summary>
        /// Removes all items from the priority-queue.
        /// </summary>
        public void Clear()
        {
            _maxHeap.Clear();
        }

        /// <summary>
        /// Returns the first item at the head of the queue, without removing it.
        /// </summary>
        /// <returns>
        /// The item at the head of the queue.
        /// </returns>
        public TItem Peek()
        {
            return _maxHeap.Peek().Data;
        }

        /// <summary>
        /// Enqueues an item to the priority-queue with a specified priority. Lower values are placed at the front.
        /// </summary>
        /// <param name="item">The item to add to the queue.</param>
        /// <param name="priority">The priority associated with the item.</param>
        public void Enqueue(TItem item, TPriority priority)
        {
            if (ReferenceEquals(priority, null))
            {
                throw new ArgumentNullException(nameof(priority),
                    $"Unable to enqueue item into Maximum Priority-Queue. {nameof(priority)} cannot be null.");
            }

            _maxHeap.Insert(new MaxPriorityQueueNode(item, priority));
        }

        /// <summary>
        /// Returns the first item at the head of the queue and removes it.
        /// </summary>
        /// <returns>
        /// The item at the head of the queue.
        /// </returns>
        public TItem Dequeue()
        {
            return _maxHeap.RemoveRoot().Data;
        }
        #endregion IPriorityQueue<TItem, TPriority> Members

        #region IEnumerable<TItem> Members
        public IEnumerator<TItem> GetEnumerator()
        {
            return ((IEnumerable<TItem>)ToArray()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion IEnumerable<TItem> Members

        private TItem[] ToArray()
        {
            var cloneHeap = new MaxDHeap<MaxPriorityQueueNode>(2, _maxHeap.Items, _comparer);
            var result = new TItem[cloneHeap.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = cloneHeap.RemoveRoot().Data;
            }
            return result;
        }

        private sealed class MaxPriorityQueueNode : Base.ComparableBase<TPriority>
        {
            public MaxPriorityQueueNode(TItem data, TPriority priority)
                : base(priority)
            {
                Data = data;
            }

            public TItem Data { get; }
        }
    }
}
