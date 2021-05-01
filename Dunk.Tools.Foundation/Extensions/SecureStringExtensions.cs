using System;
using System.Security;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods for converting between secure and in-secure strings.
    /// </summary>
    public static class SecureStringExtensions
    {
        /// <summary>
        /// Converts this <see cref="SecureString"/> into an insecure <see cref="string"/>
        /// </summary>
        /// <param name="secure">The secure string to convert.</param>
        /// <returns>
        /// The insecure string.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="secure"/> was null.</exception>
        public static string ToInSecureString(this SecureString secure)
        {
            if(secure == null)
            {
                throw new ArgumentNullException(nameof(secure),
                    $"Unable to convert to InSecureString. {nameof(secure)} parameter was null");
            }

            string result = string.Empty;
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secure);
            try
            {
                result = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
            return result;
        }

        /// <summary>
        /// Converts this insecure <see cref="string"/> into a <see cref="SecureString"/>.
        /// </summary>
        /// <param name="s">The insecure string to convert.</param>
        /// <returns>
        /// The secure string.
        /// </returns>
        public static SecureString ToSecureString(this string s)
        {
            if(s == null)
            {
                throw new ArgumentNullException(nameof(s),
                    $"Unable to convert to SecureString. {nameof(s)} parameter was null");
            }

            SecureString secure = new SecureString();

            foreach (char c in s)
            {
                secure.AppendChar(c);
            }
            secure.MakeReadOnly();
            return secure;
        }
    }
}
