using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dunk.Tools.Foundation.IO
{
    /// <summary>
    /// Serves as a facade pattern over the methods contained in the .NET <see cref="File"/>.
    /// </summary>
    /// <remarks>
    /// By implementing the facade as a series of delegates over the .NET <see cref="File"/> 
    /// class we can swap out implementation in unit-tests while still having the familiar static 
    /// method calls for file operations.
    /// 
    /// see http://chrisoldwood.blogspot.co.uk/2011/10/unit-testing-file-system-dependent-code.html
    /// </remarks>
    public static class FileFacade
    {
        private static Action<string, IEnumerable<string>> _appendAllLines = File.AppendAllLines;
        private static Action<string, IEnumerable<string>, Encoding> _appendAllLinesWithEncoding = File.AppendAllLines;
        private static Action<string, string> _appendAllText = File.AppendAllText;
        private static Action<string, string, Encoding> _appendAllTextWithEncoding = File.AppendAllText;
        private static Func<string, StreamWriter> _appendText = File.AppendText;
        private static Action<string, string> _copy = File.Copy;
        private static Action<string, string, bool> _copyAndOverwrite = File.Copy;

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.AppendAllLines(string, IEnumerable{string})"/> method.<br/>
        /// 
        /// Appends lines to a file, and then closes the file. If the specified file does 
        /// not exist, this method creates a file, writes the specified lines to the file, 
        /// and then closes the file.<br/>
        /// 
        /// Parameters:<br/>
        ///  path:
        ///    The file to append the lines to. The file is created if it doesn't already exist.<br/>        ///
        ///  contents:
        ///     The lines to append to the file.<br/>
        ///</summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, IEnumerable<string>> AppendAllLines
        {
            get { return _appendAllLines; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(AppendAllLines)} delegate. value cannot be null");
                }
                _appendAllLines = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.AppendAllLines(string, IEnumerable{string}, Encoding)"/> method.<br/>
        /// 
        /// Appends lines to a file by using a specified encoding, and then closes the file. 
        /// If the specified file does not exist, this method creates a file, writes the 
        /// specified lines to the file, and then closes the file.<br/>
        /// 
        /// Parameters:<br/>
        ///  path:
        ///    The file to append the lines to. The file is created if it doesn't already exist.<br/>
        ///  contents:
        ///     The lines to append to the file.<br/>
        ///  encoding:
        ///      The character encoding to use.<br/>
        ///</summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, IEnumerable<string>, Encoding> AppendAllLinesWithEncoding
        {
            get { return _appendAllLinesWithEncoding; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(AppendAllLinesWithEncoding)} delegate. value cannot be null");
                }
                _appendAllLinesWithEncoding = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.AppendAllText(string, string)"/> method.<br/>
        /// 
        /// Opens a file, appends the specified string to the file, and then closes the file.
        /// If the file does not exist, this method creates a file, writes the specified 
        /// string to the file, then closes the file.<br/>#=
        /// 
        /// Parameters:<br/>
        ///  path:
        ///     The file to append the specified string to.<br/>
        ///  contents:
        ///     The string to append to the file.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, string> AppendAllText
        {
            get { return _appendAllText; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(AppendAllText)} delegate. value cannot be null");
                }
                _appendAllText = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.AppendAllText(string, string, Encoding)"/> method.<br/>
        /// 
        ///  Appends the specified string to the file, creating the file if it does not already 
        ///  exist.<br/>
        ///  
        /// Parameters:<br/>
        ///  path:
        ///     The file to append the specified string to.<br/>
        ///  contents:
        ///     The string to append to the file.<br/>
        ///  encoding:
        ///     The character encoding to use.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, string, Encoding> AppendAllTextWithEncoding
        {
            get { return _appendAllTextWithEncoding; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(AppendAllTextWithEncoding)} delegate. value cannot be null");
                }
                _appendAllTextWithEncoding = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.AppendText(string)"/> method.<br/>
        /// 
        /// Creates a System.IO.StreamWriter that appends UTF-8 encoded text to an existing 
        /// file, or to a new file if the specified file does not exist.<br/>
        /// 
        /// Parameters:<br/>
        ///   path:
        ///     The path to the file to append to.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, StreamWriter> AppendText
        {
            get { return _appendText; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(AppendText)} delegate. value cannot be null");
                }
                _appendText = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Copy(string, string)"/> method.<br/>
        ///
        /// Copies an existing file to a new file. Overwriting a file of the same name is
        /// not allowed.<br/>
        /// 
        /// Parameters:<br/>
        ///  sourceFileName:
        ///     The file to copy.<br/>
        ///  destFileName:
        ///     The name of the destination file. This cannot be a directory or an existing file.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, string> Copy
        {
            get { return _copy; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(Copy)} delegate. value cannot be null");
                }
                _copy = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Copy(string, string)"/> method.<br/>
        ///
        /// Copies an existing file to a new file. Overwriting a file of the same name is
        /// not allowed.<br/>
        /// 
        /// Parameters:<br/>
        ///  sourceFileName:
        ///     The file to copy.<br/>
        ///  destFileName:
        ///     The name of the destination file. This cannot be a directory or an existing file.<br/>
        ///  overwrite:
        ///     true if the destination file can be overwritten; otherwise, false.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, string, bool> CopyAndOverwrite
        {
            get { return _copyAndOverwrite; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(CopyAndOverwrite)} delegate. value cannot be null");
                }
                _copyAndOverwrite = value;
            }
        }

        /// <summary>
        /// Resets the delegates stored in this class to their default <see cref="File"/> 
        /// implementation.
        /// </summary>
        public static void ResetDefaults()
        {
            AppendAllLines = File.AppendAllLines;
            AppendAllLinesWithEncoding = File.AppendAllLines;
            AppendAllText = File.AppendAllText;
            AppendAllTextWithEncoding = File.AppendAllText;
            AppendText = File.AppendText;
            Copy = File.Copy;
            CopyAndOverwrite = File.Copy;
        }
    }
}
