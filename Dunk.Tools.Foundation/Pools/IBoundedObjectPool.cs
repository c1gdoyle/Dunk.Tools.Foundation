namespace Dunk.Tools.Foundation.Pools
{
    /// <summary>
    /// An interface that defines the behaviour of an object pool 
    /// with a set minimum and maximum size.
    /// </summary>
    /// <typeparam name="T">The type of object that will be managed by the pool.</typeparam>
    public interface IBoundedObjectPool<T> : IObjectPool<T>
    {
        /// <summary>
        /// Gets the maximum number of objects that could be available in the pool 
        /// at the same time.
        /// </summary>
        int MaximumPoolSize { get; }

        /// <summary>
        /// Gets the minimum number of objects that could be available in the pool 
        /// at the same time.
        /// </summary>
        int MinimumPoolSize { get; }
    }
}
