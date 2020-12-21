using System;

namespace Dunk.Tools.Foundation.Monads
{
    /// <summary>
    /// An interface that defines the behaviour of a monad
    /// which represents the discriminated union of two possible
    /// types.
    /// </summary>
    /// <typeparam name="TLeft">The type of the Left value.</typeparam>
    /// <typeparam name="TRight">The type of the right value.</typeparam>
    public interface IEither<out TLeft, out TRight>
    {
        /// <summary>
        /// Checks the type of value held by this monad and invokes the matching
        /// handler function.
        /// </summary>
        /// <typeparam name="TOut">The return type of the handler.</typeparam>
        /// <param name="leftHandler">The handler for the left type.</param>
        /// <param name="rightHandler">The handler for the right type.</param>
        /// <returns>
        /// The value returned by the invoked handler function.
        /// </returns>
        TOut Check<TOut>(Func<TLeft, TOut> leftHandler, Func<TRight, TOut> rightHandler);

        /// <summary>
        /// Checks the type of value held by this monad and invokes the matching
        /// handler function.
        /// </summary>
        /// <param name="leftHandler">The handler for the left type.</param>
        /// <param name="rightHandler">The handler for the right type.</param>
        void Check(Action<TLeft> leftHandler, Action<TRight> rightHandler);
    }
}
