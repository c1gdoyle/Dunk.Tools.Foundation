using System;
using System.Text;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for a <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the arugment string can be represented with the ASCII (<see cref="Encoding.ASCII"/>) encoding.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>
        /// <c>true</c> if the specified value is ASCII; otherwise <c>false</c>.
        /// </returns>
        public static bool IsASCII(this string value)
        {
            if(value == null)
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
    }
}
