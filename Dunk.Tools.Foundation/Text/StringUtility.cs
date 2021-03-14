using System.Collections.Generic;
using System.Text;
using Dunk.Tools.Foundation.Extensions;

namespace Dunk.Tools.Foundation.Text
{
    /// <summary>
    /// Provides a series of static helper methods for <see cref="string"/> manipulation.
    /// </summary>
    public static class StringUtility
    {
        /// <summary>
        /// Concatenates all the elements of a string collection, using the specified separator
        /// between elements, a sepecified last-separator between the second-last and last element.
        /// </summary>
        /// <param name="strings">The collection that contains the elements to concatenate.</param>
        /// <param name="separator">The string to use as a separator between.
        /// Is included in the returned string only if the <paramref name="strings"/> contains more than one element.
        /// </param>
        /// <param name="lastSeparator">The string to use as a separator between the second-last and last elements.
        /// Is included in the returned string only if the <paramref name="strings"/> contains more than two element.
        /// </param>
        /// <returns>
        /// A <see cref="string"/> that consists of the elements in the <paramref name="strings"/> collection delimited by the separators.
        /// </returns>
        /// <remarks>
        /// This method differs from the .NET string Join method in that it allows a separator and a last-separtor.
        /// 
        /// The supplied <paramref name="separator"/> will be used to de-limit all elements before the second-last element
        /// only if the strings colelction contains two or more elements.
        /// 
        /// The supplied <paramref name="lastSeparator"/> will be used to de-limit the second-last and last elements only
        /// if the strings collection contains one or more elements.
        /// 
        /// If the <paramref name="strings"/> collection contains only one or zero elements neither separator will be used
        /// and the concatenated string will just contain the first element.
        /// 
        /// For example if the separator is ", " and the lastSeparator is " and " then the expected concatenation of
        /// 
        /// { "Tom", "Dick", "Harry" } is "Tom, Dick and Harry"
        /// { "Tom", "Dick" } is "Tom and Dick"
        /// { "Tom" } is "Tom"
        /// </remarks>
        public static string Join(IEnumerable<string> strings, string separator, string lastSeparator)
        {
            return Join(strings, separator, lastSeparator, null);
        }

        /// <summary>
        /// Concatenates all the elements of a string collection, using the specified separator
        /// between elements, a sepecified last-separator between the second-last and last element
        /// and specified quotation string between each element.
        /// </summary>
        /// <param name="strings">The collection that contains the elements to concatenate.</param>
        /// <param name="separator">The string to use as a separator between.
        /// Is included in the returned string only if the <paramref name="strings"/> contains more than one element.
        /// </param>
        /// <param name="lastSeparator">The string to use as a separator between the second-last and last elements.
        /// Is included in the returned string only if the <paramref name="strings"/> contains more than two element.
        /// </param>
        /// <param name="quotationMark">The string to use as quotation marks between each element.</param>
        /// <returns>
        /// A <see cref="string"/> that consists of the elements in the <paramref name="strings"/> collection delimited by the separators.
        /// </returns>
        /// <remarks>
        /// This method differs from the .NET string Join method in that it allows a separator and a last-separtor.
        /// 
        /// The supplied <paramref name="separator"/> will be used to de-limit all elements before the second-last element
        /// only if the strings colelction contains two or more elements.
        /// 
        /// The supplied <paramref name="lastSeparator"/> will be used to de-limit the second-last and last elements only
        /// if the strings collection contains one or more elements.
        /// 
        /// If the <paramref name="strings"/> collection contains only one or zero elements neither separator will be used
        /// and the concatenated string will just contain the first element.
        /// 
        /// For example if the separator is ", " and the lastSeparator is " and " then the expected concatenation of
        /// 
        /// { "Tom", "Dick", "Harry" } is "Tom, Dick and Harry"
        /// { "Tom", "Dick" } is "Tom and Dick"
        /// { "Tom" } is "Tom"
        /// </remarks>
        public static string Join(IEnumerable<string> strings, string separator, string lastSeparator, string quotationMark)
        {
            strings.ThrowIfNull(nameof(strings));
            separator.ThrowIfNull(nameof(separator));
            lastSeparator.ThrowIfNull(nameof(lastSeparator));

            if (quotationMark == null)
            {
                quotationMark = string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            foreach (var entry in strings.ToSmartEnumerable())
            {
                if (!entry.IsFirst)
                {
                    if (entry.IsLast)
                    {
                        sb.Append(lastSeparator);
                    }
                    else
                    {
                        sb.Append(separator);
                    }
                }

                sb.Append(quotationMark);
                sb.Append(entry.Value);
                sb.Append(quotationMark);
            }
            return sb.ToString();
        }
    }
}
