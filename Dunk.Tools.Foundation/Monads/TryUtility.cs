using System;
using Dunk.Tools.Foundation.Extensions;

namespace Dunk.Tools.Foundation.Monads
{
    /// <summary>
    /// A helper class for creating <see cref="ITry{T}"/> instances.
    /// </summary>
    public static class TryUtility
    {
        /// <summary>
        /// For a given value create an <see cref="ITry{T}"/> representing a successful
        /// operation.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// A <see cref="ITry{T}"/> instance containing the <paramref name="value"/>
        /// </returns>
        public static ITry<T> CreateTrySuccessful<T>(T value)
        {
            return new TrySuccessful<T>(value);
        }

        /// <summary>
        /// Creates a <see cref="ITry"/> representing a successful operation.
        /// </summary>
        /// <returns>
        /// A <see cref="ITry"/> instance representing success.
        /// </returns>
        public static ITry CreateTrySuccessful()
        {
            return new TrySuccessful();
        }

        /// <summary>
        /// For a given exception create an <see cref="ITry{T}"/> representing a failed
        /// operation.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="error">The exception.</param>
        /// <returns>
        /// A <see cref="ITry{T}"/> instance containing the <paramref name="error"/>
        /// </returns>
        public static ITry<T> CreateTryFailure<T>(Exception error)
        {
            return new TryFailure<T>(error);
        }

        /// <summary>
        /// Creates a <see cref="ITry"/> representing a failed operation.
        /// </summary>
        /// <returns>
        /// A <see cref="ITry"/> instance representing failure.
        /// </returns>
        public static ITry CreateTryFailure(Exception error)
        {
            return new TryFailure(error);
        }

        /// <summary>
        /// Chains a given <see cref="ITry{T}"/> instance to create a new <see cref="ITry{TOut}"/>
        /// using a specified delegate.
        /// </summary>
        /// <typeparam name="T">The type of value held by the original Try monad.</typeparam>
        /// <typeparam name="TOut">The type of value held by the new Try monad.</typeparam>
        /// <param name="originalTry">The original Try monad.</param>
        /// <param name="chainFunc">The delegate to use to chain the original monad to create the new monad.</param>
        /// <returns>
        /// If the <paramref name="originalTry"/> represented a successful operation returns a new monad containing the 
        /// result of invoking the chain function using the original monad's underlying value.
        /// If the <paramref name="originalTry"/> representing a failed operation returns a new monad containing the 
        /// error held by the original monad.
        /// </returns>
        public static ITry<TOut> Chain<T, TOut>(ITry<T> originalTry, Func<T, TOut> chainFunc)
        {
            return originalTry.IsFaulted ?
                CreateTryFailure<TOut>((originalTry as TryFailure<T>).Error) :
                CreateTrySuccessful<TOut>(chainFunc((originalTry as TrySuccessful<T>).Value));
        }

        /// <summary>
        /// Chains a given <see cref="ITry"/> instance to create a new <see cref="ITry"/>
        /// using a specified delegate.
        /// </summary>
        /// <param name="originalTry">The original try monad.</param>
        /// <param name="chainFunc">The delegate to use to chain the original monad to create the new monad.</param>
        /// <returns>
        /// If the <paramref name="originalTry"/> represented a successful operation returns a new monad from invoking
        /// the chain function.
        /// If the <paramref name="originalTry"/> representing a failed operation returns a new monad containing the 
        /// error held by the original monad.
        /// </returns>
        public static ITry Chain(ITry originalTry, Func<ITry> chainFunc)
        {
            return originalTry.IsFaulted ? CreateTryFailure((originalTry as TryFailure).Error) : chainFunc();
        }

        /// <summary>
        /// An implementation of <see cref="ITry{T}"/> that deals with successful
        /// operations.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        private sealed class TrySuccessful<T> : ITry<T>
        {
            private readonly T _value;

            /// <summary>
            /// Initialises a new instance of <see cref="TrySuccessful{T}"/> with
            /// a specified value.
            /// </summary>
            /// <param name="value">The value from a successful operation.</param>
            public TrySuccessful(T value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets the value held by this <see cref="TrySuccessful{T}"/>.
            /// </summary>
            public T Value
            {
                get { return _value; }
            }

            #region ITry<T> Members
            public bool IsFaulted
            {
                get { return false; }
            }

            public void Check(Action<T> successHandler, Action<Exception> failureHandler)
            {
                successHandler.ThrowIfNull(nameof(successHandler));
                successHandler(Value);
            }

            public TOut Check<TOut>(Func<T, TOut> successHandler, Func<Exception, TOut> failureHandler)
            {
                successHandler.ThrowIfNull(nameof(successHandler));
                return successHandler(Value);
            }
            #endregion ITry<T> Members
        }

        /// <summary>
        /// An implementation of <see cref="ITry"/> that deals with successful
        /// operations.
        /// </summary>
        private sealed class TrySuccessful : ITry
        {
            /// <summary>
            /// Initialises anew default instance of <see cref="TrySuccessful"/>.
            /// </summary>
            public TrySuccessful()
            {

            }

            #region ITry Members
            public bool IsFaulted
            {
                get { return false; }
            }

            public void Check(Action successHandler, Action<Exception> failureHandler)
            {
                successHandler.ThrowIfNull(nameof(successHandler));
                successHandler();
            }

            public TOut Check<TOut>(Func<TOut> successHandler, Func<Exception, TOut> failureHandler)
            {
                successHandler.ThrowIfNull(nameof(successHandler));
                return successHandler();
            }
            #endregion ITry Members
        }

        /// <summary>
        /// An implementation of <see cref="ITry"/> that deals with failed operations.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        private sealed class TryFailure<T> : ITry<T>
        {
            private readonly Exception _error;

            /// <summary>
            /// Initialises a new instance of <see cref="TryFailure{T}"/> with a
            /// specified exception.
            /// </summary>
            /// <param name="error">The exception from a failed operation.</param>
            public TryFailure(Exception error)
            {
                _error = error;
            }

            /// <summary>
            /// Gets the exception held by this <see cref="TryFailure{T}"/>.
            /// </summary>
            public Exception Error
            {
                get { return _error; }
            }

            #region ITry<T> Members

            public bool IsFaulted
            {
                get { return true; }
            }

            public void Check(Action<T> successHandler, Action<Exception> failureHandler)
            {
                failureHandler.ThrowIfNull(nameof(failureHandler));
                failureHandler(Error);
            }

            public TOut Check<TOut>(Func<T, TOut> successHandler, Func<Exception, TOut> failureHandler)
            {
                failureHandler.ThrowIfNull(nameof(failureHandler));
                return failureHandler(Error);
            }
            #endregion ITry<T> Members
        }

        /// <summary>
        /// An implementation of <see cref="ITry"/> that deals with failed
        /// operations.
        /// </summary>
        private sealed class TryFailure : ITry
        {
            private readonly Exception _error;

            /// <summary>
            /// Initialises a new instance of <see cref="TryFailure"/> with a
            /// specified exception.
            /// </summary>
            /// <param name="error">The exception from a failed operation.</param>
            public TryFailure(Exception error)
            {
                _error = error;
            }

            /// <summary>
            /// Gets the exception held by this <see cref="TryFailure"/>.
            /// </summary>
            public Exception Error
            {
                get { return _error; }
            }

            #region ITry<T> Members
            public bool IsFaulted
            {
                get { return true; }
            }

            public void Check(Action successHandler, Action<Exception> failureHandler)
            {
                failureHandler.ThrowIfNull(nameof(failureHandler));
                failureHandler(Error);
            }

            public TOut Check<TOut>(Func<TOut> successHandler, Func<Exception, TOut> failureHandler)
            {
                failureHandler.ThrowIfNull(nameof(failureHandler));
                return failureHandler(Error);
            }
            #endregion ITry<T> Members
        }
    }
}
