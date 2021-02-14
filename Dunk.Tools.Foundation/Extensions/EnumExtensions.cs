using System;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods for a <see cref="Enum"/>.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets a specified attribute from a specified Enum.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to get.</typeparam>
        /// <param name="e">The Enum class.</param>
        /// <returns>
        /// An instance of <typeparamref name="TAttribute"/> if it was found on the Enum; otherwise null.
        /// </returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum e)
            where TAttribute : Attribute
        {
            e.ThrowIfNull(nameof(e),
                $"Unable to get attribute on Enum. {nameof(e)} parameter cannot be null");

            var members = e.GetType().GetMember(e.ToString());
            var attributes = members[0].GetCustomAttributes(typeof(TAttribute), false);
            return attributes.Length != 0 ? (TAttribute)attributes[0] : null;
        }

        /// <summary>
        /// Gets specified attributes from a specified Enum.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to get.</typeparam>
        /// <param name="e">The Enum class.</param>
        /// <returns>
        /// An array containing <typeparamref name="TAttribute"/>s if any were found on the Enum; otherwise Enum will be empty.
        /// </returns>
        public static TAttribute[] GetAttributes<TAttribute>(this Enum e)
            where TAttribute : Attribute
        {
            e.ThrowIfNull(nameof(e),
                $"Unable to get attribute on Enum. {nameof(e)} parameter cannot be null");

            var members = e.GetType().GetMember(e.ToString());
            var attributes = members[0].GetCustomAttributes(typeof(TAttribute), false);

            return attributes as TAttribute[];
        }
    }
}
