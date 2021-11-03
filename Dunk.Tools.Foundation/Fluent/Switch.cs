using System;

namespace Dunk.Tools.Foundation.Fluent
{
    /// <summary>
    /// Provides a fluent API as an alternative to a switch statement.
    /// </summary>
    /// <typeparam name="T">The type to check.</typeparam>
    /// <remarks>
    /// Based on https://lostechies.com/derickbailey/2010/10/07/a-less-ugly-switch-statement-for-c/
    /// </remarks>
    public class Switch<T>
        where T : IEquatable<T>
    {
        private readonly T _toMatch;
        private bool _hasBeenMatched;

        /// <summary>
        /// Initialises a new instance of <see cref="Switch{T}"/> with a 
        /// specified value to match on.
        /// </summary>
        /// <param name="toMatch">The value to match on.</param>
        /// <exception cref="ArgumentNullException"><paramref name="toMatch"/> parameter cannot be null.</exception>
        public Switch(T toMatch)
        {
            _toMatch = toMatch;
        }

        /// <summary>
        /// Checks if a specified input matches the value for this <see cref="Switch{T}"/>.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="action">The action to execute if the input matches.</param>
        /// <returns>
        /// The resulting switch.
        /// </returns>
        public Switch<T> Case(T input, Action action)
        {
            if (_hasBeenMatched)
            {
                return this;
            }
            if (_toMatch.Equals(input))
            {
                action();
                _hasBeenMatched = true;
            }
            return this;
        }

        /// <summary>
        /// Default for this <see cref="Switch{T}"/>.
        /// </summary>
        /// <param name="action"></param>
        public void Default(Action action)
        {
            if (!_hasBeenMatched)
            {
                action();
            }
        }

        /// <summary>
        /// Converts a specified <typeparamref name="T"/> value into a <see cref="Switch{T}"/>
        /// </summary>
        /// <param name="equatable">The value to match on.</param>
        /// <returns>
        /// A <see cref="Switch{T}"/> that checks values on the supplied <paramref name="equatable"/>.
        /// </returns>
        public static Switch<T> On(T equatable)
        {
            return new Switch<T>(equatable);
        }
    }
}
