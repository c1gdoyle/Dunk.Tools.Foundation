namespace Dunk.Tools.Foundation.Pools
{
    /// <summary>
    /// An interface that defines the behaviour of a generic object pool
    /// </summary>
    /// <typeparam name="T">The type of object that will be managed by the pool.</typeparam>
    public interface IObjectPool<T>
    {
        /// <summary>
        /// Gets the count of the number of objects currently in the pool.
        /// </summary>
        int PoolCount { get; }

        /// <summary>
        /// Gets a monitored object from the pool.
        /// </summary>
        /// <returns>
        /// An object from the pool.
        /// </returns>
        T GetObject();

        /// <summary>
        /// Returns an object to the pool.
        /// </summary>
        /// <param name="obj">The object to return to the pool.</param>
        void ReturnObjectToPool(T obj);
    }
}
