using System;

namespace Dunk.Tools.Foundation.Monads
{
    /// <summary>
    /// An interface that defines the behaviour of a monad which
    /// represents the discriminated union of a successful operation
    /// and a failed operation.
    /// </summary>
    /// <typeparam name="T">The output type of a successful operation.</typeparam>
    public interface ITry<out T>
    {
        /// <summary>
        /// Gets whether or not this <see cref="ITry{T}"/> instance
        /// represents a failure or success.
        /// </summary>
        bool IsFaulted { get; }

        /// <summary>
        /// Checks the type of state of this monad and invokes the matching
        /// handler function.
        /// </summary>
        /// <typeparam name="TOut">The return type of the handler.</typeparam>
        /// <param name="successHandler">The handler for a successful opeartion.</param>
        /// <param name="failureHandler">The handler for a failed operation.</param>
        /// <returns>
        /// The value returned by the invokved handler function.
        /// </returns>
        TOut Check<TOut>(Func<T, TOut> successHandler, Func<Exception, TOut> failureHandler);

        /// <summary>
        /// Checks the type of state of this monad and invokes the matching
        /// handler function.
        /// </summary>
        /// <param name="successHandler">The handler for a successful opeartion.</param>
        /// <param name="failureHandler">The handler for a failed operation.</param>
        void Check(Action<T> successHandler, Action<Exception> failureHandler);
    }

    /// <summary>
    /// An interface that defines the behaviour of a monad which
    /// represents the discriminated union of a successful operation
    /// and a failed operation.
    /// </summary>
    /// <remarks>
    /// This differs from <see cref="ITry{T}"/> in that the successful operation
    /// does not have any output.
    /// </remarks>
    public interface ITry
    {
        /// <summary>
        /// Gets whether or not this <see cref="ITry{T}"/> instance
        /// represents a failure or success.
        /// </summary>
        bool IsFaulted { get; }

        /// <summary>
        /// Checks the type of state of this monad and invokes the matching
        /// handler function.
        /// </summary>
        /// <typeparam name="TOut">The return type of the handler.</typeparam>
        /// <param name="successHandler">The handler for a successful opeartion.</param>
        /// <param name="failureHandler">The handler for a failed operation.</param>
        /// <returns>
        /// The value returned by the invokved handler function.
        /// </returns>
        TOut Check<TOut>(Func<TOut> successHandler, Func<Exception, TOut> failureHandler);

        /// <summary>
        /// Checks the type of state of this monad and invokes the matching
        /// handler function.
        /// </summary>
        /// <param name="successHandler">The handler for a successful opeartion.</param>
        /// <param name="failureHandler">The handler for a failed operation.</param>
        void Check(Action successHandler, Action<Exception> failureHandler);
    }
}
