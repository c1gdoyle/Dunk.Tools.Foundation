namespace Dunk.Tools.Foundation.Base
{
    /// <summary>
    /// An interface that describes a lightweight factory class.
    /// </summary>
    /// <typeparam name="T">The type created by this factory.</typeparam>
    /// <remarks>
    /// This is useful for abstracting away dependencies for unit-tests.
    /// </remarks>
    public interface IFactory<out T>
    {
        /// <summary>
        /// Creates/Retrieves an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>
        /// The instance of <typeparamref name="T"/> or null if one could not be created.
        /// </returns>
        T CreateInstance();
    }

    /// <summary>
    /// An interface that describes a lightweight factory class.
    /// </summary>
    /// <typeparam name="T">The type created by this factory.</typeparam>
    /// <typeparam name="TInput">The type of input for this factory.</typeparam>
    /// <remarks>
    /// This is useful for abstracting away dependencies for unit-tests.
    /// </remarks>
    public interface IFactory<out T, in TInput>
    {
        /// <summary>
        /// Creates/Retrieves an instance of <typeparamref name="T"/> using a 
        /// specified <typeparamref name="TInput"/>.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// The instance of <typeparamref name="T"/> or null if one could not be created.
        /// </returns>
        T CreateInstance(TInput input);
    }
}
