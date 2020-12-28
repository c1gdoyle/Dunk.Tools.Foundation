using System;
using System.Collections.Generic;
using System.IO;

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

        /// <summary>
        /// Gets or sets delegate over the <see cref="File.AppendAllLines(string, IEnumerable{string})"/> method.<br/>
        /// 
        /// Appends lines to a file, and then closes the file. If the specified file does 
        /// not exist, this method creates a file, writes the specified lines to the file, 
        /// and then closes the file.<br/>
        /// 
        /// Parameters:<br/>
        ///  path:
        ///    The file to append the lines to. The file is created if it doesn't already exist.<br/>
        ///
        ///   contents:
        ///     The lines to append to the file.<br/>
        ///</summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, IEnumerable<string>> AppendAllLines
        {
            get { return _appendAllLines; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set AppendAllLines delegate. {nameof(value)} cannot be null");
                }
                _appendAllLines = value;
            }
        }

        /// <summary>
        /// Resets the delegates stored in this class to their default <see cref="File"/> 
        /// implementation.
        /// </summary>
        public static void ResetDefaults()
        {
            AppendAllLines = File.AppendAllLines;
        }
    }
}
