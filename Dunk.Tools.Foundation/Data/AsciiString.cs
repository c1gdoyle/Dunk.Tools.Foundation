using System;
using System.Text;

namespace Dunk.Tools.Foundation.Data
{
    /// <summary>
    /// Represents text a series of ASCII encoded characters.
    /// </summary>
    public struct AsciiString : IEquatable<AsciiString>
    {
        private readonly byte[] _data;

        /// <summary>
        /// Initialises a new instance of <see cref="AsciiString"/> to a value
        /// equivalent to the ASCII encoding of the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        public AsciiString(string text)
        {
            if (!Extensions.StringExtensions.IsASCII(text))
            {
                throw new ArgumentException($"Unable to create AsciiString. {nameof(text)} parameter must only contain ASCII characters", nameof(text));
            }
            _data = Encoding.ASCII.GetBytes(text);
        }

        private AsciiString(byte[] data)
        {
            _data = data;
        }

        /// <summary>
        /// Gets the length of the current <see cref="AsciiString"/>.
        /// </summary>
        public int Length
        {
            get { return _data.Length; }
        }

        /// <summary>
        /// Gets whether or not this <see cref="AsciiString"/> is null.
        /// </summary>
        public bool IsNull
        {
            get { return _data == null; }
        }

        /// <summary>
        /// Gets the <see cref="char"/> object specified position in the current
        /// <see cref="AsciiString"/> instance.
        /// </summary>
        /// <param name="position">The position in the current <see cref="AsciiString"/>.</param>
        /// <returns>
        /// The object at position index.
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">index is greater than or equal to the length of this object, or less than zero.</exception>
        public char this[int position]
        {
            get { return (char)_data[position]; }
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified
        /// character position and has a specified length.
        /// </summary>
        /// <param name="startIndex">The zero-based starting position of a substring in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>
        /// A <see cref="AsciiString"/> that is equivalent to the substring of length <paramref name="length"/> that begins
        /// at <paramref name="startIndex"/> in this instance.
        /// </returns>
        public AsciiString SubString(int startIndex, int length)
        {
            if (startIndex < 0 || startIndex > _data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (startIndex + length > _data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            byte[] newData = new byte[length];
            Buffer.BlockCopy(_data, startIndex, newData, 0, length);
            return new AsciiString(newData);
        }

        #region Object Overrides
        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S4136: Equals in Object and IEquatable regions")]
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((AsciiString)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var comparer = new Comparers.ArrayEqualityComparer<byte>();
            return comparer.GetHashCode(_data);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Encoding.ASCII.GetString(_data);
        }
        #endregion Object Overrides

        #region IEquatable<AsciiString> Members
        /// <inheritdoc />
        public bool Equals(AsciiString other)
        {
            var comparer = new Comparers.ArrayEqualityComparer<byte>();
            return comparer.Equals(_data, other._data);
        }
        #endregion IEquatable<AsciiString> Members

        /// <summary>
        /// Determines whether two specified instances of <see cref="AsciiString"/> are equal
        /// </summary>
        /// <param name="x">The first instance to compare.</param>
        /// <param name="y">The second instance to compare.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="x"/> and <paramref name="y"/> are equal; otherwise <c>false</c>.
        /// </returns>
        public static bool operator ==(AsciiString x, AsciiString y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="AsciiString"/> are not equal
        /// </summary>
        /// <param name="x">The first instance to compare.</param>
        /// <param name="y">The second instance to compare.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="x"/> and <paramref name="y"/> are not equal; otherwise <c>false</c>.
        /// </returns>
        public static bool operator !=(AsciiString x, AsciiString y)
        {
            return !x.Equals(y);
        }
    }
}
