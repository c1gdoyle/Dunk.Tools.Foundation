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
        private static Func<string, Stream> _create = File.Create;
        private static Func<string, int, Stream> _createWithBuffer = File.Create;
        private static Func<string, int, FileOptions, Stream> _createWithFileOptions = File.Create;
        private static Func<string, StreamWriter> _createText = File.CreateText;
        private static Action<string> _decrypt = File.Decrypt;
        private static Action<string> _delete = File.Delete;
        private static Action<string> _encrypt = File.Encrypt;
        private static Func<string, bool> _exists = File.Exists;

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.AppendAllLines(string, IEnumerable{string})"/> method.<br/>
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
        /// Gets or sets a delegate over the <see cref="File.Create(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, Stream> Create
        {
            get { return _create; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(Create)} delegate. value cannot be null");
                }
                _create = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Create(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, int, Stream> CreateWithBuffer
        {
            get { return _createWithBuffer; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(CreateWithBuffer)} delegate. value cannot be null");
                }
                _createWithBuffer = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Create(string, int, FileOptions)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, int, FileOptions, Stream> CreateWithFileOptions
        {
            get { return _createWithFileOptions; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(CreateWithFileOptions)} delegate. value cannot be null");
                }
                _createWithFileOptions = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.CreateText(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string,StreamWriter> CreateText
        {
            get { return _createText; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(CreateText)} delegate. value cannot be null");
                }
                _createText = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Decrypt(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string> Decrypt
        {
            get { return _decrypt; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(Decrypt)} delegate. value cannot be null");
                }
                _decrypt = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Delete(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string> Delete
        {
            get { return _delete; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(Delete)} delegate. value cannot be null");
                }
                _delete = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Encrypt(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string> Encrypt
        {
            get { return _encrypt; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(Encrypt)} delegate. value cannot be null");
                }
                _encrypt = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Exists(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, bool> Exists
        {
            get { return _exists; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(Exists)} delegate. value cannot be null");
                }
                _exists = value;
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
            Create = File.Create;
            CreateWithBuffer = File.Create;
            CreateWithFileOptions = File.Create;
            CreateText = File.CreateText;
            Decrypt = File.Decrypt;
            Delete = File.Delete;
            Encrypt = File.Encrypt;
            Exists = File.Exists;
        }
    }
}
