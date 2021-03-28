using System;
using System.Text;
using System.Linq;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for a <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        private static readonly char[] Chars = Enumerable.Range(char.MinValue, char.MaxValue)
            .Select(x => (char)x)
            .Where(c => !char.IsControl(c))
            .ToArray();
        private static readonly char[] AsciiChars = Chars
            .Where(c => c < 128)
            .ToArray();
        private static readonly Random Random = new Random();

        /// <summary>
        /// Determines whether the arugment string can be represented with the ASCII (<see cref="Encoding.ASCII"/>) encoding.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        /// <c>true</c> if the specified value is ASCII; otherwise <c>false</c>.
        /// </returns>
        public static bool IsASCII(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value),
                    $"{nameof(value)} parameter cannot be null for Is-ASCII");
            }
            /*
             * ASCII encoding replaces any non-ascii character with questions marks, so
             * we use UTF8 to see if multi-byte sequences are there
             * 
             * https://snipplr.com/view/35806/
             * */
            return Encoding.UTF8.GetByteCount(value) == value.Length;
        }

        /// <summary>
        /// Reverses a specified string.
        /// </summary>
        /// <param name="value">The string.</param>
        /// <returns>
        /// A new <see cref="string"/> that contains the reversed contents of the input string.
        /// </returns>
        public static string Reverse(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value),
                    $"{nameof(value)} parameter cannot be null for Reverse");
            }
            char[] array = value.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        /// <summary>
        /// Generates a random <see cref="char"/>.
        /// </summary>
        /// <returns>
        /// A random char between <see cref="char.MaxValue"/> and <see cref="char.MinValue"/>.
        /// </returns>
        public static char GenerateRandomChar()
        {
            return Chars[Random.Next(Chars.Length)];
        }

        /// <summary>
        /// Generates a random ASCII <see cref="char"/>.
        /// </summary>
        /// <returns>
        /// A random char between <see cref="char.MaxValue"/> and <see cref="char.MinValue"/>.
        /// </returns>

        public static char GenerateRandomAsciiChar()
        {
            return AsciiChars[Random.Next(AsciiChars.Length)];
        }

        /// <summary>
        /// Generates a random <see cref="string"/> of a specified length.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>
        /// A random string.
        /// </returns>
        public static string GenerateRandomString(int length)
        {
            if(length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length),
                    $"{nameof(length)} paramter for random string must be greater than or equal to 0");
            }
            var builder = new StringBuilder(length);
            for(int i = 0; i < length; i++)
            {
                builder.Append(GenerateRandomChar());
            }
            return builder.ToString();
        }

        /// <summary>
        /// Generates a random ASCII <see cref="string"/> of a specified length.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>
        /// A random string.
        /// </returns>
        public static string GenerateRandomAsciiString(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length),
                    $"{nameof(length)} paramter for random ascii-string must be greater than or equal to 0");
            }
            var builder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                builder.Append(GenerateRandomAsciiChar());
            }
            return builder.ToString();
        }
    }
}
