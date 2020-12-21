using System;

namespace Dunk.Tools.Foundation.Monads
{
    /// <summary>
    /// A helper class for creating <see cref="IEither{TLeft, TRight}"/> instances.
    /// </summary>
    public static class EitherUtility
    {
        /// <summary>
        /// For a given Left value create an <see cref="IEither{TLeft, TRight}"/>.
        /// </summary>
        /// <typeparam name="TLeft">The type of the Left value.</typeparam>
        /// <typeparam name="TRight">The type of the Right value.</typeparam>
        /// <param name="value">The Left value.</param>
        /// <returns>
        /// An <see cref="IEither{TLeft, TRight}"/> instance containing the <paramref name="value"/>.
        /// </returns>
        public static IEither<TLeft, TRight> CreateLeft<TLeft, TRight>(TLeft value)
        {
            return new LeftEither<TLeft, TRight>(value);
        }

        /// <summary>
        /// For a given Right value create an <see cref="IEither{TLeft, TRight}"/>.
        /// </summary>
        /// <typeparam name="TLeft">The type of the Left value.</typeparam>
        /// <typeparam name="TRight">The type of the Right value.</typeparam>
        /// <param name="value">The Right value.</param>
        /// <returns>
        /// An <see cref="IEither{TLeft, TRight}"/> instance containing the <paramref name="value"/>.
        /// </returns>
        public static IEither<TLeft, TRight> CreateRight<TLeft, TRight>(TRight value)
        {
            return new RightEither<TLeft, TRight>(value);
        }

        /// <summary>
        /// An implementation of <see cref="IEither{TLeft, TRight}"/> that deals
        /// with Left values.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left value.</typeparam>
        /// <typeparam name="TRight">The type of the right value.</typeparam>
        private sealed class LeftEither<TLeft, TRight> : IEither<TLeft, TRight>
        {
            private readonly TLeft _value;

            /// <summary>
            /// Initialises a new instance of <see cref="LeftEither{TLeft, TRight}"/> with
            /// a specified Left value.
            /// </summary>
            /// <param name="value">The Left value.</param>
            public LeftEither(TLeft value)
            {
                _value = value;
            }

            #region IEither<TLeft, TRight> Members
            /// <summary>
            /// Checks the type of value held by this monad and invokes the left
            /// handler function.
            /// </summary>
            /// <param name="leftHandler">The handler for the left type.</param>
            /// <param name="rightHandler">The handler for the right type.</param>
            public void Check(Action<TLeft> leftHandler, Action<TRight> rightHandler)
            {
                leftHandler(_value);
            }

            /// <summary>
            /// Checks the type of value held by this monad and invokes the left
            /// handler function.
            /// </summary>
            /// <typeparam name="TOut">The return type of the handler.</typeparam>
            /// <param name="leftHandler">The handler for the left type.</param>
            /// <param name="rightHandler">The handler for the right type.</param>
            /// <returns>
            /// The value returned by the invoked left handler function.
            /// </returns>
            public TOut Check<TOut>(Func<TLeft, TOut> leftHandler, Func<TRight, TOut> rightHandler)
            {
                return leftHandler(_value);
            }
            #endregion IEither<TLeft, TRight> Members
        }


        /// <summary>
        /// An implementation of <see cref="IEither{TLeft, TRight}"/> that deals
        /// with Right values.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left value.</typeparam>
        /// <typeparam name="TRight">The type of the right value.</typeparam>
        private sealed class RightEither<TLeft, TRight> : IEither<TLeft, TRight>
        {
            private readonly TRight _value;

            /// <summary>
            /// Initialises a new instance of <see cref="RightEither{TLeft, TRight}"/> with
            /// a specified Right value.
            /// </summary>
            /// <param name="value">The Right value.</param>
            public RightEither(TRight value)
            {
                _value = value;
            }

            #region IEither<TLeft, TRight> Members
            /// <summary>
            /// Checks the type of value held by this monad and invokes the right
            /// handler function.
            /// </summary>
            /// <param name="leftHandler">The handler for the left type.</param>
            /// <param name="rightHandler">The handler for the right type.</param>
            public void Check(Action<TLeft> leftHandler, Action<TRight> rightHandler)
            {
                rightHandler(_value);
            }

            /// <summary>
            /// Checks the type of value held by this monad and invokes the right
            /// handler function.
            /// </summary>
            /// <typeparam name="TOut">The return type of the handler.</typeparam>
            /// <param name="leftHandler">The handler for the left type.</param>
            /// <param name="rightHandler">The handler for the right type.</param>
            /// <returns>
            /// The value returned by the invoked left handler function.
            /// </returns>
            public TOut Check<TOut>(Func<TLeft, TOut> leftHandler, Func<TRight, TOut> rightHandler)
            {
                return rightHandler(_value);
            }
            #endregion IEither<TLeft, TRight> Members
        }
    }
}
