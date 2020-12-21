namespace Dunk.Tools.Foundation.Pools
{
    /// <summary>
    /// An interface that defines the behaviour of an object stored
    /// in a generic object pool.
    /// </summary>
    public interface IObjectPoolItem
    {
        /// <summary>
        /// Resets the state of the object.
        /// </summary>
        /// <remarks>
        /// This method will be called just before the object has been returned
        /// to the pool.
        /// </remarks>
        void ResetState();

        /// <summary>
        /// Releases the objects' resources.
        /// </summary>
        /// <remarks>
        /// This method will be called when this object is no longer required.
        /// Either the object cannot be returned to the pool, presumably because the pool is
        /// already full, or the pool is being destroyed.
        /// </remarks>
        void ReleaseResources();
    }
}
