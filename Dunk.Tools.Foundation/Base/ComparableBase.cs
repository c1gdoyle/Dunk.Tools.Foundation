using System;

namespace Dunk.Tools.Foundation.Base
{
    /// <summary>
    /// Provides a generic base class for types that implement <see cref="IComparable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The underlying type to compare.</typeparam>
    /// <remarks>
    /// Derived class is required to provide implementation for <see cref="object.GetHashCode"/> 
    /// and <see cref="IComparable{T}.CompareTo(T)"/>.
    /// 
    /// See https://codereview.stackexchange.com/questions/209976/base-class-for-implementing-icomparablet
    /// </remarks>
    public abstract class ComparableBase<T> : IComparable, IComparable<T>, IEquatable<T>
        where T : ComparableBase<T>
    {
        #region Object Overrides
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S4136: Equals to remain in Object Override and IEquatable<T> region")]
        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        public override abstract int GetHashCode();
        #endregion Object Overrides

        #region IComparable Members
        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            return CompareTo(obj as T);
        }
        #endregion IComparable Members

        #region IComparable<T> Members
        /// <inheritdoc />
        public abstract int CompareTo(T other);
        #endregion IComparable<T> Members

        #region IEquatable<ComparableBase<T>> Members
        /// <inheritdoc />
        public virtual bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            return CompareTo(other) == 0;
        }
        #endregion IEquatable<ComparableBase<T>> Members

        /// <summary>
        /// Determines whether two specified instances of <see cref="ComparableBase{T}"/> are equal.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>
        /// <c>true</c> if instances are equal; otherwise <c>false</c>.
        /// </returns>
        public static bool operator ==(ComparableBase<T> left, ComparableBase<T> right)
        {
            if (left is null)
            {
                return right is null;
            }
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="ComparableBase{T}"/> are not equal.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>
        /// <c>true</c> if instances are not equal; otherwise <c>false</c>.
        /// </returns>
        public static bool operator !=(ComparableBase<T> left, ComparableBase<T> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether one specified <see cref="ComparableBase{T}"/> is less than another specified 
        /// <see cref="ComparableBase{T}"/>.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>
        /// <c>true</c> if left instance is less than right instance; otherwise <c>false</c>.
        /// </returns>
        public static bool operator <(ComparableBase<T> left, ComparableBase<T> right)
        {
            if (left is null)
            {
                return !(right is null);
            }
            return left.CompareTo(right) == -1;
        }

        /// <summary>
        /// Determines whether one specified <see cref="ComparableBase{T}"/> is greater than another specified 
        /// <see cref="ComparableBase{T}"/>.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>
        /// <c>true</c> if left instance is greater than right instance; otherwise <c>false</c>.
        /// </returns>
        public static bool operator >(ComparableBase<T> left, ComparableBase<T> right)
        {
            if (left is null)
            {
                return false;
            }
            return left.CompareTo(right) == 1;
        }

        /// <summary>
        /// Determines whether one specified <see cref="ComparableBase{T}"/> is less than or equal to 
        /// another specified 
        /// <see cref="ComparableBase{T}"/>.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>
        /// <c>true</c> if left instance is less than or equal to right instance; otherwise <c>false</c>.
        /// </returns>
        public static bool operator <=(ComparableBase<T> left, ComparableBase<T> right)
        {
            if (left is null)
            {
                return true;
            }
            return left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Determines whether one specified <see cref="ComparableBase{T}"/> is greater than or equal to 
        /// another specified 
        /// <see cref="ComparableBase{T}"/>.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>
        /// <c>true</c> if left instance is greater than or equal to right instance; otherwise <c>false</c>.
        /// </returns>
        public static bool operator >=(ComparableBase<T> left, ComparableBase<T> right)
        {
            if (left is null)
            {
                return right is null;
            }
            return left.CompareTo(right) >= 0;
        }
    }
}
