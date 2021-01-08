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
        private static Func<string, FileAttributes> _getAttributes = File.GetAttributes;
        private static Func<string, DateTime> _getCreationTime = File.GetCreationTime;
        private static Func<string, DateTime> _getCreationTimeUtc = File.GetCreationTimeUtc;
        private static Func<string, DateTime> _getLastAccessTime = File.GetLastAccessTime;
        private static Func<string, DateTime> _getLastAccessTimeUtc = File.GetLastAccessTimeUtc;
        private static Func<string, DateTime> _getLastWriteTime = File.GetLastWriteTime;
        private static Func<string, DateTime> _getLastWriteTimeUtc = File.GetLastWriteTimeUtc;
        private static Action<string, string> _move = File.Move;
        private static Func<string, FileMode, Stream> _open = File.Open;
        private static Func<string, FileMode, FileAccess, Stream> _openWithFileAccess = File.Open;
        private static Func<string, FileMode, FileAccess, FileShare, Stream> _openWithFileShare = File.Open;
        private static Func<string, Stream> _openRead = File.OpenRead;
        private static Func<string, StreamReader> _openText = File.OpenText;
        private static Func<string, Stream> _openWrite = File.OpenWrite;
        private static Func<string, byte[]> _readAllBytes = File.ReadAllBytes;
        private static Func<string, string[]> _readAllLines = File.ReadAllLines;
        private static Func<string, Encoding, string[]> _readAllLinesWithEncoding = File.ReadAllLines;
        private static Func<string, string> _readAllText = File.ReadAllText;
        private static Func<string, Encoding, string> _readAllTextWithEncoding = File.ReadAllText;
        private static Func<string, IEnumerable<string>> _readLines = File.ReadLines;
        private static Func<string, Encoding, IEnumerable<string>> _readLinesWithEncoding = File.ReadLines;
        private static Action<string, string, string> _replace = File.Replace;
        private static Action<string, string, string, bool> _replaceWithIgnoreMetadata = File.Replace;
        private static Action<string, FileAttributes> _setAttributes = File.SetAttributes;
        private static Action<string, DateTime> _setCreationTime = File.SetCreationTime;
        private static Action<string, DateTime> _setCreationTimeUtc = File.SetCreationTimeUtc;
        private static Action<string, DateTime> _setLastAccessTime = File.SetLastAccessTime;
        private static Action<string, DateTime> _setLastAccessTimeUtc = File.SetLastAccessTimeUtc;
        private static Action<string, DateTime> _setLastWriteTime = File.SetLastWriteTime;
        private static Action<string, DateTime> _setLastWriteTimeUtc = File.SetLastWriteTimeUtc;
        private static Action<string, byte[]> _writeAllBytes = File.WriteAllBytes;
        private static Action<string, IEnumerable<string>> _writeAllLines = File.WriteAllLines;
        private static Action<string, IEnumerable<string>, Encoding> _writeAllLinesWithEncoding = File.WriteAllLines;
        private static Action<string, string[]> _writeAllLinesArray = File.WriteAllLines;
        private static Action<string, string[], Encoding> _writeAllLinesArrayWithEncoding = File.WriteAllLines;
        private static Action<string, string> _writeAllText = File.WriteAllText;
        private static Action<string, string, Encoding> _writeAllTextWithEncoding = File.WriteAllText;

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
        public static Func<string, StreamWriter> CreateText
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
        /// Gets or sets a delegate over the <see cref="File.GetAttributes(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, FileAttributes> GetAttributes
        {
            get { return _getAttributes; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(GetAttributes)} delegate. value cannot be null");
                }
                _getAttributes = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.GetCreationTime(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, DateTime> GetCreationTime
        {
            get { return _getCreationTime; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(GetCreationTime)} delegate. value cannot be null");
                }
                _getCreationTime = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.GetCreationTimeUtc(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, DateTime> GetCreationTimeUtc
        {
            get { return _getCreationTimeUtc; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(GetCreationTimeUtc)} delegate. value cannot be null");
                }
                _getCreationTimeUtc = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.GetLastAccessTime(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, DateTime> GetLastAccessTime
        {
            get { return _getLastAccessTime; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(GetLastAccessTime)} delegate. value cannot be null");
                }
                _getLastAccessTime = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.GetLastAccessTimeUtc(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, DateTime> GetLastAccessTimeUtc
        {
            get { return _getLastAccessTimeUtc; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(GetLastAccessTimeUtc)} delegate. value cannot be null");
                }
                _getLastAccessTimeUtc = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.GetLastWriteTime(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, DateTime> GetLastWriteTime
        {
            get { return _getLastWriteTime; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(GetLastWriteTime)} delegate. value cannot be null");
                }
                _getLastWriteTime = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.GetLastWriteTimeUtc(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, DateTime> GetLastWriteTimeUtc
        {
            get { return _getLastWriteTimeUtc; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(GetLastWriteTimeUtc)} delegate. value cannot be null");
                }
                _getLastWriteTimeUtc = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Move(string, string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, string> Move
        {
            get { return _move; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(Move)} delegate. value cannot be null");
                }
                _move = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Open(string, FileMode)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, FileMode, Stream> Open
        {
            get { return _open; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(Open)} delegate. value cannot be null");
                }
                _open = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Open(string, FileMode, FileAccess)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, FileMode, FileAccess, Stream> OpenWithFileAccess
        {
            get { return _openWithFileAccess; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(OpenWithFileAccess)} delegate. value cannot be null");
                }
                _openWithFileAccess = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Open(string, FileMode, FileAccess, FileShare)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, FileMode, FileAccess, FileShare, Stream> OpenWithFileShare
        {
            get { return _openWithFileShare; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(OpenWithFileShare)} delegate. value cannot be null");
                }
                _openWithFileShare = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.OpenRead(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, Stream> OpenRead
        {
            get { return _openRead; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(OpenRead)} delegate. value cannot be null");
                }
                _openRead = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.OpenText(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, StreamReader> OpenText
        {
            get { return _openText; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(OpenText)} delegate. value cannot be null");
                }
                _openText = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.OpenWrite(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, Stream> OpenWrite
        {
            get { return _openWrite; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(OpenWrite)} delegate. value cannot be null");
                }
                _openWrite = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.ReadAllBytes(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, byte[]> ReadAllBytes
        {
            get { return _readAllBytes; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(ReadAllBytes)} delegate. value cannot be null");
                }
                _readAllBytes = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.ReadAllLines(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, string[]> ReadAllLines
        {
            get { return _readAllLines; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(ReadAllLines)} delegate. value cannot be null");
                }
                _readAllLines = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.ReadAllLines(string, Encoding)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, Encoding, string[]> ReadAllLinesWithEncoding
        {
            get { return _readAllLinesWithEncoding; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(ReadAllLinesWithEncoding)} delegate. value cannot be null");
                }
                _readAllLinesWithEncoding = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.ReadAllText(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, string> ReadAllText
        {
            get { return _readAllText; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(ReadAllText)} delegate. value cannot be null");
                }
                _readAllText = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.ReadAllText(string, Encoding)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, Encoding, string> ReadAllTextWithEncoding
        {
            get { return _readAllTextWithEncoding; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(ReadAllTextWithEncoding)} delegate. value cannot be null");
                }
                _readAllTextWithEncoding = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.ReadLines(string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, IEnumerable<string>> ReadLines
        {
            get { return _readLines; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(ReadLines)} delegate. value cannot be null");
                }
                _readLines = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.ReadLines(string, Encoding)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Func<string, Encoding, IEnumerable<string>> ReadLinesWithEncoding
        {
            get { return _readLinesWithEncoding; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(ReadLinesWithEncoding)} delegate. value cannot be null");
                }
                _readLinesWithEncoding = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Replace(string, string, string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, string, string> Replace
        {
            get { return _replace; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(Replace)} delegate. value cannot be null");
                }
                _replace = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.Replace(string, string, string, bool)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, string, string, bool> ReplaceWithIgnoreMetadata
        {
            get { return _replaceWithIgnoreMetadata; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(ReplaceWithIgnoreMetadata)} delegate. value cannot be null");
                }
                _replaceWithIgnoreMetadata = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.SetAttributes(string, FileAttributes)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, FileAttributes> SetAttributes
        {
            get { return _setAttributes; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(SetAttributes)} delegate. value cannot be null");
                }
                _setAttributes = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.SetCreationTime(string, DateTime)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, DateTime> SetCreationTime
        {
            get { return _setCreationTime; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(SetCreationTime)} delegate. value cannot be null");
                }
                _setCreationTime = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.SetCreationTimeUtc(string, DateTime)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, DateTime> SetCreationTimeUtc
        {
            get { return _setCreationTimeUtc; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(SetCreationTimeUtc)} delegate. value cannot be null");
                }
                _setCreationTimeUtc = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.SetLastAccessTime(string, DateTime)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, DateTime> SetLastAccessTime
        {
            get { return _setLastAccessTime; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(SetLastAccessTime)} delegate. value cannot be null");
                }
                _setLastAccessTime = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.SetLastAccessTimeUtc(string, DateTime)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, DateTime> SetLastAccessTimeUtc
        {
            get { return _setLastAccessTimeUtc; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(SetLastAccessTimeUtc)} delegate. value cannot be null");
                }
                _setLastAccessTimeUtc = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.SetLastWriteTime(string, DateTime)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, DateTime> SetLastWriteTime
        {
            get { return _setLastWriteTime; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(SetLastWriteTime)} delegate. value cannot be null");
                }
                _setLastWriteTime = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.SetLastWriteTimeUtc(string, DateTime)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, DateTime> SetLastWriteTimeUtc
        {
            get { return _setLastWriteTimeUtc; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(SetLastWriteTimeUtc)} delegate. value cannot be null");
                }
                _setLastWriteTimeUtc = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.WriteAllBytes(string, byte[])"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, byte[]> WriteAllBytes
        {
            get { return _writeAllBytes; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(WriteAllBytes)} delegate. value cannot be null");
                }
                _writeAllBytes = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.WriteAllLines(string, IEnumerable{string})"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, IEnumerable<string>> WriteAllLines
        {
            get { return _writeAllLines; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(WriteAllLines)} delegate. value cannot be null");
                }
                _writeAllLines = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.WriteAllLines(string, IEnumerable{string}, Encoding)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, IEnumerable<string>, Encoding> WriteAllLinesWithEncoding
        {
            get { return _writeAllLinesWithEncoding; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(WriteAllLinesWithEncoding)} delegate. value cannot be null");
                }
                _writeAllLinesWithEncoding = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.WriteAllLines(string, string[])"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, string[]> WriteAllLinesArray
        {
            get { return _writeAllLinesArray; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(WriteAllLinesArray)} delegate. value cannot be null");
                }
                _writeAllLinesArray = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.WriteAllLines(string, string[], Encoding)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, string[], Encoding> WriteAllLinesArrayWithEncoding
        {
            get { return _writeAllLinesArrayWithEncoding; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(WriteAllLinesArrayWithEncoding)} delegate. value cannot be null");
                }
                _writeAllLinesArrayWithEncoding = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.WriteAllText(string, string)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, string> WriteAllText
        {
            get { return _writeAllText; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(WriteAllText)} delegate. value cannot be null");
                }
                _writeAllText = value;
            }
        }

        /// <summary>
        /// Gets or sets a delegate over the <see cref="File.WriteAllText(string, string, Encoding)"/> method.<br/>
        /// </summary>
        /// <exception cref="ArgumentNullException">value delegate was null.</exception>
        public static Action<string, string, Encoding> WriteAllTextWithEncoding
        {
            get { return _writeAllTextWithEncoding; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value),
                        $"Unable to set {nameof(WriteAllTextWithEncoding)} delegate. value cannot be null");
                }
                _writeAllTextWithEncoding = value;
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
            GetAttributes = File.GetAttributes;
            GetCreationTime = File.GetCreationTime;
            GetCreationTimeUtc = File.GetCreationTimeUtc;
            GetLastAccessTime = File.GetLastAccessTime;
            GetLastAccessTimeUtc = File.GetLastAccessTimeUtc;
            GetLastWriteTime = File.GetLastWriteTime;
            GetLastWriteTimeUtc = File.GetLastWriteTimeUtc;
            Move = File.Move;
            Open = File.Open;
            OpenWithFileAccess = File.Open;
            OpenWithFileShare = File.Open;
            OpenRead = File.OpenRead;
            OpenText = File.OpenText;
            OpenWrite = File.OpenWrite;
            ReadAllBytes = File.ReadAllBytes;
            ReadAllLines = File.ReadAllLines;
            ReadAllLinesWithEncoding = File.ReadAllLines;
            ReadAllText = File.ReadAllText;
            ReadAllTextWithEncoding = File.ReadAllText;
            ReadLines = File.ReadLines;
            ReadLinesWithEncoding = File.ReadLines;
            Replace = File.Replace;
            ReplaceWithIgnoreMetadata = File.Replace;
            SetAttributes = File.SetAttributes;
            SetCreationTime = File.SetCreationTime;
            SetCreationTimeUtc = File.SetCreationTimeUtc;
            SetLastAccessTime = File.SetLastAccessTime;
            SetLastAccessTimeUtc = File.SetLastAccessTimeUtc;
            SetLastWriteTime = File.SetLastWriteTime;
            SetLastWriteTimeUtc = File.SetLastWriteTimeUtc;
            WriteAllBytes = File.WriteAllBytes;
            WriteAllLines = File.WriteAllLines;
            WriteAllLinesWithEncoding = File.WriteAllLines;
            WriteAllLinesArray = File.WriteAllLines;
            WriteAllLinesArrayWithEncoding = File.WriteAllLines;
            WriteAllText = File.WriteAllText;
            WriteAllTextWithEncoding = File.WriteAllText;
        }
    }
}
