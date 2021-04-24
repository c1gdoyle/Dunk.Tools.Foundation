using System;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for numeric value types.
    /// </summary>
    public static class NumericExtensions
    {
        private static readonly string[] AbbreviatedNumberSuffices = { string.Empty, "k", "M", "G", "T", "P", "E", "Z", "Y" };

        /// <summary>
        /// Converts a given <see cref="System.Double"/> to engineering notation.
        /// </summary>
        /// <param name="number">The double to converted.</param>
        /// <returns>
        /// A string representing the engineering notation equivalent.
        /// </returns>
        /// <remarks>
        /// Note be engineering notation we mean that the resulting string will only
        /// be accurate for 3 signficant figures.
        /// For example
        /// 1111 would result in 1.11k
        /// 
        /// See https://en.wikipedia.org/wiki/Engineering_notation for further details. 
        /// </remarks>
        public static string ConvertToEngineeringNotation(this double number)
        {
            int mult = 0;
            while (number >= 1000 && mult < AbbreviatedNumberSuffices.Length - 1)
            {
                number /= 1000.0;
                mult++;
            }
            return string.Format("{0}{1}", number.ToString("0.##"), AbbreviatedNumberSuffices[mult]);
        }

        /// <summary>
        /// Returns a value indicating whether this instance and a specified <see cref="double"/>
        /// object represent the same value, to a specified precision.
        /// </summary>
        /// <param name="left">The double that will be compared.</param>
        /// <param name="right">The double to compare to this instance.</param>
        /// <param name="precision">A <see cref="int"/> indicating the precision of the 
        /// comparison in decimal places.</param>
        /// <returns>
        /// True if the value compared is equal to this instance; otherwise false.
        /// </returns>
        public static bool NearlyEquals(this double left, double right, int precision)
        {
            double multiplier = Math.Pow(10, precision);
            double l = Math.Truncate(left * multiplier) / multiplier;
            double r = Math.Truncate(right * multiplier) / multiplier;
            return l == r;
        }

        /// <summary>
        /// Determines if the number is odd.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>
        /// <c>true</c> if the number is odd; otherwise returns <c>false</c>.
        /// </returns>
        public static bool IsOdd(this int number)
        {
            return !IsEven(number);
        }

        /// <summary>
        /// Determines if the number is event.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>
        /// <c>true</c> if the number is odd; otherwise returns <c>false</c>.
        /// </returns>
        public static bool IsEven(this int number)
        {
            return IsDivisibleBy(number, 2);
        }

        /// <summary>
        /// Determines if the number is divisible by a specified divisor.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns>
        /// <c>true</c> if the number is divisible; otherwise returns <c>false</c>.
        /// </returns>
        public static bool IsDivisibleBy(this int number, int divisor)
        {
            return number % divisor == 0;
        }
    }
}
