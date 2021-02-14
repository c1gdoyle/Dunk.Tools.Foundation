namespace Dunk.Tools.Foundation.Collections
{
    /// <summary>
    /// An interface that defines behaviour of a collection that represents 
    /// a double-ended queue for which elements can be added or removed from either 
    /// the front(head) or back(tail).
    /// </summary>
    /// <typeparam name="T">The type stored in the queue.</typeparam>
    public interface IDeque<T>
    {
        /// <summary>
        /// Enqueues a specified item to the front of the <see cref="IDeque{T}"/>.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        void EnqueueItemToFront(T item);

        /// <summary>
        /// Enqueues a specified item to the back of the <see cref="IDeque{T}"/>.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        void EnqueueItemToBack(T item);

        /// <summary>
        /// Removes and returns the item at the front of the <see cref="IDeque{T}"/>
        /// </summary>
        /// <returns>
        /// The item that is removed from the front of the queue.
        /// </returns>
        T DequeueItemFromFront();

        /// <summary>
        /// Removes and returns the item at the back of the <see cref="IDeque{T}"/>
        /// </summary>
        /// <returns>
        /// The item that is removed from the back of the queue.
        /// </returns>
        T DequeueItemFromBack();

        /// <summary>
        /// Returns an item from the front of the <see cref="IDeque{T}"/> without 
        /// removing it.
        /// </summary>
        /// <returns>
        /// The item at the front of the queue.
        /// </returns>
        T PeekAtItemFromFront();

        /// <summary>
        /// Returns an item from the back of the <see cref="IDeque{T}"/> without 
        /// removing it.
        /// </summary>
        /// <returns>
        /// The item at the back of the queue.
        /// </returns>
        T PeekAtItemFromBack();
    }
}
