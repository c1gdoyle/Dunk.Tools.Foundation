using System;

namespace Dunk.Tools.Foundation.Monads
{
    /// <summary>
    /// A Maybe monad intended for dealing with a 'no' value as
    /// an alternative to <c>null</c>.
    /// </summary>
    /// <typeparam name="T">The type of object encapsulated within this monad</typeparam>
    /// <remarks>
    /// See Mikhail Shilkov's series at https://mikhail.io/2016/01/monads-explained-in-csharp/
    /// </remarks>
    public class Maybe<T>
        where T : class
    {
        /// <summary>
        /// Initialises a new instance of <see cref="Maybe{T}"/> with a specified
        /// instance of T.
        /// </summary>
        /// <param name="value">The value of T.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> parameter was null.</exception>
        public Maybe(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"{nameof(value)} parameter cannot be null");
            }
            Value = value;
            HasValue = true;
        }

        private Maybe()
        {
        }

        /// <summary>
        /// Gets or sets the value of this <see cref="Maybe{T}"/> instance.
        /// </summary>
        public T Value
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets whether this <see cref="Maybe{T}"/> instance has a value
        /// or not.
        /// </summary>
        public bool HasValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Chains this <see cref="Maybe{T}"/> instance to create a new <see cref="Maybe{TOut}"/>
        /// using a specified delegate.
        /// </summary>
        /// <typeparam name="TOut">The type of object encapsulated within the new monad.</typeparam>
        /// <param name="chainFunc">The delegate to use to chain this monad to create the new monad.</param>
        /// <returns>
        /// A new monad.
        /// </returns>
        public Maybe<TOut> Chain<TOut>(Func<T, TOut> chainFunc)
            where TOut : class
        {
            return HasValue ? new Maybe<TOut>(chainFunc(Value)) : Maybe<TOut>.None();
        }

        /// <summary>
        /// Represents a 'no value' instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>
        /// An empty instance of <see cref="Maybe{T}"/>.
        /// </returns>
        public static Maybe<T> None()
        {
            return new Maybe<T>();
        }

        /// <summary>
        /// Explcitily converts a given instance of <typeparamref name="T"/> into a <see cref="Maybe{T}"/>
        /// </summary>
        /// <param name="instance">The instance of T.</param>
        /// <returns>
        /// An instance of <see cref="Maybe{T}"/>. If <paramref name="instance"/> was not null the resulting
        /// Monad will contain the value; otherwise it will be the equivalent of a 'no value'.
        /// </returns>
        public static explicit operator Maybe<T>(T instance)
        {
            return instance != null ? new Maybe<T>(instance) : None();
        }
    }
}
