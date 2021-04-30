using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

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


        /// <summary>
        /// Strips any quotation marks from this string.
        /// </summary>
        /// <param name="str">The original string.</param>
        /// <returns>
        /// A string that is equivalent to the current string except with all instances
        /// of ' and " removed.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> was null.</exception>
        public static string Unquote(this string str)
        {
            return str.Replace(
                new List<Tuple<string, string>>
                {
                    new Tuple<string, string>("\'",""),
                    new Tuple<string, string>("\"","")
                });
        }

        /// <summary>
        /// Performs multiple <see cref="string"/>.Replace operations on this string.
        /// </summary>
        /// <param name="str">The original string.</param>
        /// <param name="replacements">
        /// A collection of <see cref="Tuple{T1, T2}"/> representing the old strings to be replaced
        /// and the new strings to replace them with.
        /// 
        /// The 1st item of the Tuple represents the oldValue, the string to be replaced, and
        /// The 2nd item of the Tuple represents the newValue, the string to replace all occurrences of the 
        /// oldValue. 
        /// </param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of the
        /// oldValues are replaced with the newValues.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> or <paramref name="replacements"/> was null.</exception>
        public static string Replace(this string str, IEnumerable<Tuple<string, string>> replacements)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str),
                    $"Unable to Replace string, {nameof(str)} parameter cannot be null");
            }
            if(replacements == null)
            {
                throw new ArgumentNullException(nameof(replacements),
                    $"Unable to Replace string, {nameof(replacements)} parameter cannot be null");
            }
            foreach (Tuple<string, string> replacement in replacements)
            {
                str = str.Replace(replacement.Item1, replacement.Item2);
            }
            return str;
        }

        /// <summary>
        /// Performs multiple <see cref="string"/>.Replace operations on this string.
        /// </summary>
        /// <param name="str">The original string.</param>
        /// <param name="replacements">
        /// A collection of <see cref="Tuple{T1, T2}"/> representing the old chars to be replaced
        /// and the new chars to replace them with.
        /// 
        /// The 1st item of the Tuple represents the oldValue, the chars to be replaced, and
        /// The 2nd item of the Tuple represents the newValue, the chars to replace all occurrences of the 
        /// oldValue. 
        /// </param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of the
        /// oldValues are replaced with the newValues.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> or <paramref name="replacements"/> was null.</exception>
        public static string Replace(this string str, IEnumerable<Tuple<char,char>> replacements)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str),
                    $"Unable to Replace string, {nameof(str)} parameter cannot be null");
            }
            if (replacements == null)
            {
                throw new ArgumentNullException(nameof(replacements),
                    $"Unable to Replace string, {nameof(replacements)} parameter cannot be null");
            }
            foreach (Tuple<char, char> replacement in replacements)
            {
                str = str.Replace(replacement.Item1, replacement.Item2);
            }
            return str;
        }
        /// <summary>
        /// Underlines a string with a series of hypen characters ("-").
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        /// The string, a newline, and a series of underline characters.
        /// </returns>
        public static string Underline(this string str)
        {
            return str.Underline('-');
        }

        /// <summary>
        /// Underlines a string with a specified character.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="underlineChar">The character to use in the underline.</param>
        /// <returns>
        /// The string, a newline, and a series of underline characters.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> was null.</exception>
        public static string Underline(this string str, char underlineChar)
        {
            if(str == null)
            {
                throw new ArgumentNullException(nameof(str),
                    $"Unable to perform Underline, {nameof(str)} parameter cannot be null.");
            }
            int length = str.Length;
            var underline = string.Empty.PadLeft(length, underlineChar);
            return str + System.Environment.NewLine + underline;
        }
    }
}
