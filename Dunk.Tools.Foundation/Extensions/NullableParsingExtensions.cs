using System;
using System.Globalization;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods for parsing a string to a <see cref="Nullable{T}"/> struct.
    /// </summary>
    public static class NullableParsingExtensions
    {
        /// <summary>
        /// A delegate that denotes the signature of the try parse handler.
        /// </summary>
        /// <typeparam name="T">The struct we are attempting to parse to.</typeparam>
        /// <param name="s">A string containing the data to convert.</param>
        /// <param name="result">
        /// When this method returns, contains a value equivalent to the data contained in s, 
        /// if the conversion succeeded.
        /// </param>
        /// <returns>
        /// <c>true</c> if s was converted successfully; otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        /// It is intended that the delegate matches the TryParse method of the struct 
        /// we are attempting to parse.
        /// 
        /// For example if tryinig to parse a Nullable Int32 the TryParseDelegate should 
        /// be the TryParse method defined in <see cref="int"/>.
        /// </remarks>
        public delegate bool TryParseDelegate<T>(string s, out T result);

        /// <summary>
        /// Converts the string representation to a Nullable char.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="char"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static char? ParseNullableChar(this string s)
        {
            return ParseNullable<char>(s, char.TryParse);
        }

        /// <summary>
        /// Converts the string representation to a Nullable boolean.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="bool"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static bool? ParseNullableBoolean(this string s)
        {
            return ParseNullable<bool>(s, bool.TryParse);
        }

        /// <summary>
        /// Converts the string representation to a Nullable byte.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="byte"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static byte? ParseNullableByte(this string s)
        {
            return ParseNullable<byte>(s, byte.TryParse);
        }

        /// <summary>
        /// Converts the string representation to a Nullable short.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="short"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static short? ParseNullableInt16(this string s)
        {
            return ParseNullable<short>(s, short.TryParse);
        }

        /// <summary>
        /// Converts the string representation to a Nullable int.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="int"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static int? ParseNullableInt32(this string s)
        {
            return ParseNullable<int>(s, int.TryParse);
        }

        /// <summary>
        /// Converts the string representation to a Nullable long.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="long"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static long? ParseNullableInt64(this string s)
        {
            return ParseNullable<long>(s, long.TryParse);
        }

        /// <summary>
        /// Converts the string representation to a Nullable decimal.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="decimal"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static decimal? ParseNullableDecimal(this string s)
        {
            return ParseNullable<decimal>(s, decimal.TryParse);
        }

        /// <summary>
        /// Converts the string representation to a Nullable float.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="float"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static float? ParseNullableFloat(this string s)
        {
            return ParseNullable<float>(s, float.TryParse);
        }

        /// <summary>
        /// Converts the string representation to a Nullable double.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="double"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static double? ParseNullableDouble(this string s)
        {
            return ParseNullable<double>(s, double.TryParse);
        }

        /// <summary>
        /// Converts the string representation to a Nullable DateTime.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="DateTime"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static DateTime? ParseNullableDateTime(this string s)
        {
            return ParseNullable<DateTime>(s, DateTime.TryParse);
        }

        /// <summary>
        /// Converts the string representation to a Nullable DateTime using a specified 
        /// format, culture-specified format information and
        /// <see cref="DateTimeStyles.None"/> style.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <param name="format">The required format of s.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="DateTime"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static DateTime? ParseNullableDateTimeExact(this string s, string format)
        {
            return ParseNullableDateTimeExact(s, format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the string representation to a Nullable DateTime using a specified 
        /// format, culture-specified format information and
        /// <see cref="DateTimeStyles.None"/> style.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <param name="format">The required format of s.</param>
        /// <param name="provider">An object that supplies the culture-specific formatting information about s.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="DateTime"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static DateTime? ParseNullableDateTimeExact(this string s, string format, IFormatProvider provider)
        {
            return ParseNullableDateTimeExact(s, format, provider, DateTimeStyles.None);
        }

        /// <summary>
        /// Converts the string representation to a Nullable DateTime using specified 
        /// format, date style and <see cref="CultureInfo.InvariantCulture"/> format 
        /// information.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <param name="format">The required format of s.</param>
        /// <param name="style">A bitwise combination of one or more enumeration values that indicate the permitted format of s.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="DateTime"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static DateTime? ParseNullableDateTimeExact(this string s, string format, DateTimeStyles style)
        {
            return ParseNullableDateTimeExact(s, format, CultureInfo.InvariantCulture, style);
        }

        /// <summary>
        /// Converts the string representation to a Nullable DateTime using a specified
        /// format, specified style and specified culture-specific format information.
        /// </summary>
        /// <param name="s">A string containing the data to convert.</param>
        /// <param name="format">The required format of s.</param>
        /// <param name="provider">An object that supplies the culture-specific formatting information about s.</param>
        /// <param name="style">A bitwise combination of one or more enumeration values that indicate the permitted format of s.</param>
        /// <returns>
        /// A Nullable char containing the value equvialent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <see cref="DateTime"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static DateTime? ParseNullableDateTimeExact(this string s, string format, IFormatProvider provider, DateTimeStyles style)
        {
            return ParseNullable<DateTime>(s,
                (string x, out DateTime y) => DateTime.TryParseExact(x, format, provider, style, out y));
        }

        /// <summary>
        /// Converts the string representation to a <see cref="Nullable{T}"/> using a specified 
        /// parsing delegate.
        /// </summary>
        /// <typeparam name="T">The value type we attempting to parse to.</typeparam>
        /// <param name="s">A string containing the data to convert.</param>
        /// <param name="parser">The parser to use to attempt the parsing.</param>
        /// <returns>
        /// A <see cref="Nullable{T}"/> instance containing the value equivalent of s.
        /// If s was successfully parsed the <see cref="Nullable{T}.Value"/> holds a <typeparamref name="T"/> value;
        /// otherwise contains no value.
        /// </returns>
        public static T? ParseNullable<T>(this string s, TryParseDelegate<T> parser)
            where T : struct
        {
            T result;
            if (parser(s, out result))
            {
                return (T?)result;
            }
            return null;
        }
    }
}