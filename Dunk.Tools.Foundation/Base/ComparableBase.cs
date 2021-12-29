using System;

namespace Dunk.Tools.Foundation.Base
{
    /// <summary>
    /// Provides a generic base class for types that implement <see cref="IComparable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The underlying type to compare.</typeparam>
    public abstract class ComparableBase<T> : IComparable, IComparable<ComparableBase<T>>, IEquatable<ComparableBase<T>>
        where T : IComparable<T>
    {
        /// <summary>
        /// Initialises a new instancec of <see cref="ComparableBase{T}"/> using a specified
        /// value.
        /// </summary>
        /// <param name="value">The underlying value.</param>
        protected ComparableBase(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the underlying value.
        /// </summary>
        public T Value { get; }

        #region Object Overrides
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S4136: Equals to remain in Object Override and IEquatable<T> region")]
        public override bool Equals(object obj)
        {
            return Equals(obj as ComparableBase<T>);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        #endregion Object Overrides

        #region IComparable Members
        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            return CompareTo(obj as ComparableBase<T>);
        }
        #endregion IComparable Members

        #region IComparable<T> Members
        /// <inheritdoc />
        public int CompareTo(ComparableBase<T> other)
        {
            if (other is null)
            {
                return 1;
            }
            return Value.CompareTo(other.Value);
        }
        #endregion IComparable<T> Members

        #region IEquatable<ComparableBase<T>> Members
        /// <inheritdoc />
        public virtual bool Equals(ComparableBase<T> other)
        {
            if (other == null)
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            return Value.Equals(other.Value);
        }
        #endregion IEquatable<ComparableBase<T>> Members

        public static implicit operator T(ComparableBase<T> c) => c.Value;

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
