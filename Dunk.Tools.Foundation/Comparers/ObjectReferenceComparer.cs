using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Dunk.Tools.Foundation.Comparers
{
    /// <summary>
    /// A generic object comparer that only uses an object's reference ignoring
    /// any <see cref="IEquatable{T}"/> or <see cref="object.Equals(object)"/> overrides.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam>
    public sealed class ObjectReferenceComparer<T> : EqualityComparer<T>
    {
        private static IEqualityComparer<T> _defaultComparer;

        /// <summary>
        /// Initialises a new default instance of <see cref="ObjectReferenceComparer{T}"/>
        /// </summary>
        public ObjectReferenceComparer()
            : base()
        {
        }

        /// <summary>
        /// Returns a default equality comparer for the type specified by the generic argument.
        /// </summary>
        public new static IEqualityComparer<T> Default
        {
            get { return _defaultComparer ?? (_defaultComparer = new ObjectReferenceComparer<T>()); }
        }

        #region IEqualityComparer<T> Members
        /// <summary>
        /// Determines whether two objects of type T are equa.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// <c>true</c> if the specified objects are the same instance; otherwise <c>false</c>
        /// </returns>
        public override bool Equals(T x, T y)
        {
            return ReferenceEquals(x, y);
        }

        /// <summary>
        /// Serves as a hash function for the specified object.
        /// </summary>
        /// <param name="obj">The object for which to get a hash code.</param>
        /// <returns>
        /// A hash code for the specified object.
        /// </returns>
        public override int GetHashCode(T obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
        #endregion IEqualityComparer<T> Members
    }
}
