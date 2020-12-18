using System;
using System.Collections.Generic;
using System.Linq;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods for simplifying argument checks.
    /// </summary>
    public static class ArgumentExtensions
    {
        /// <summary>
        /// Checks if a given parameter is null. If the parameter is null this method
        /// will throw a <see cref="ArgumentNullException"/>; otherwise will do nothing.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="obj">The object that we are checking if is <c>null</c></param>
        /// <param name="parameterName">The name of the parameter represented by <paramref name="obj"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/> was null.</exception>
        public static void ThrowIfNull<T>(this T obj, string parameterName)
        {
            obj.ThrowIfNull(parameterName, $"{parameterName} parameter cannot be null.");
        }

        /// <summary>
        /// Checks if a given parameter is null. If the parameter is null this method
        /// will throw a <see cref="ArgumentNullException"/>; otherwise will do nothing.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="obj">The object that we are checking if is <c>null</c></param>
        /// <param name="parameterName">The name of the parameter represented by <paramref name="obj"/>.</param>
        /// <param name="errorMessage">The message describing the error which will be passed to the exception if <paramref name="obj"/> is <c>null</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/> was null.</exception>
        public static void ThrowIfNull<T>(this T obj, string parameterName, string errorMessage)
        {
            if (ReferenceEquals(obj, null))
            {
                throw new ArgumentNullException(parameterName, errorMessage);
            }
        }

        /// <summary>
        /// Checks if a given string parameter is null or empty. If string is null
        /// or empty this method will throw a <see cref="ArgumentNullException"/>; otherwise will do nothing.
        /// </summary>
        /// <param name="s">The string we are checking.</param>
        /// <param name="parameterName">The name of the parameter represented by the string.</param>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> was null or empty.</exception>
        public static void ThrowIfNullOrEmpty(this string s, string parameterName)
        {
            s.ThrowIfNullOrEmpty(parameterName, $"{parameterName} cannot be null or empty");
        }

        /// <summary>
        /// Checks if a given string parameter is null or empty. If string is null
        /// or empty this method will throw a <see cref="ArgumentNullException"/>; otherwise will do nothing.
        /// </summary>
        /// <param name="s">The string we are checking.</param>
        /// <param name="parameterName">The name of the parameter represented by the string.</param>
        /// <param name="errorMessage">The message describing the error which will be passed to the exception if <paramref name="s"/> is null or empty.</param>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> was null or empty.</exception>
        public static void ThrowIfNullOrEmpty(this string s, string parameterName, string errorMessage)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(parameterName, errorMessage);
            }
        }

        /// <summary>
        /// Checks if a given <see cref="IEnumerable{T}"/> parameter is null or empty. If collection is null
        /// or empty this method will thrown an exception.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="collection">The collection that we are checking if is null or empty.</param>
        /// <param name="parameterName">The name of the parameter represented by the <paramref name="collection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> was null.</exception>
        /// <exception cref="ArgumentException"><paramref name="collection"/> was empty.</exception>
        public static void ThrowIfNullOrEmpty<T>(this IEnumerable<T> collection, string parameterName)
        {
            collection.ThrowIfNullOrEmpty(parameterName, $"{parameterName} parameter cannot be empty");
        }

        /// <summary>
        /// Checks if a given <see cref="IEnumerable{T}"/> parameter is null or empty. If collection is null
        /// or empty this method will thrown an exception.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="collection">The collection that we are checking if is null or empty.</param>
        /// <param name="parameterName">The name of the parameter represented by the <paramref name="collection"/>.</param>
        /// <param name="errorMessage">The message describing the error which will be passed to the exception if <paramref name="collection"/> is null or empty.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> was null.</exception>
        /// <exception cref="ArgumentException"><paramref name="collection"/> was empty.</exception>
        public static void ThrowIfNullOrEmpty<T>(this IEnumerable<T> collection, string parameterName, string errorMessage)
        {
            collection.ThrowIfNull(parameterName);
            if (!collection.Any())
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Checks if a given <see cref="IEnumerable{T}"/> parameter is null or contains null values.
        /// If the collection is null or contains null values this method will throw an exception.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="collection">The collection that we are checking if is null or empty.</param>
        /// <param name="parameterName">The name of the parameter represented by the <paramref name="collection"/>.</param>
        public static void ThrowIfNullOrContainsNull<T>(this IEnumerable<T> collection, string parameterName)
        {
            ThrowIfNullOrContainsNull(collection, parameterName, $"{parameterName} was null or contained nulls");
        }

        /// <summary>
        /// Checks if a given <see cref="IEnumerable{T}"/> parameter is null or contains null values.
        /// If the collection is null or contains null values this method will throw an exception.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="collection">The collection that we are checking if is null or empty.</param>
        /// <param name="parameterName">The name of the parameter represented by the <paramref name="collection"/>.</param>
        /// <param name="errorMessage">The message describing the error which will be passed to the exception if <paramref name="collection"/> is null or empty.</param>
        public static void ThrowIfNullOrContainsNull<T>(this IEnumerable<T> collection, string parameterName, string errorMessage)
        {
            collection.ThrowIfNull(parameterName);
            if (collection.Any(x => ReferenceEquals(x, null)))
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }
    }
}
