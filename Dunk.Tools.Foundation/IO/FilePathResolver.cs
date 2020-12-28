using System;

namespace Dunk.Tools.Foundation.IO
{
    /// <summary>
    /// Responsible for resolving the path to a file in an application or windows service
    /// base directory.
    /// </summary>
    public static class FilePathResolver
    {
        /// <summary>
        /// Resolves the file path for a specified file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>
        /// The full file path for the file in relation to the application's 
        /// base directory.
        /// </returns>
        public static string ResolveFilePath(string fileName)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return currentDirectory + fileName;
        }
    }
}
