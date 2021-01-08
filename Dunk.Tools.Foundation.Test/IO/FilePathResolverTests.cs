using System;
using Dunk.Tools.Foundation.IO;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.IO
{
    [TestFixture]
    public class FilePathResolverTests
    {
        [Test]
        public void FilePathResolverReturnsFilePath()
        {
            const string fileName = "Test_File.csv";

            string filePath = FilePathResolver.ResolveFilePath(fileName);

            Assert.IsFalse(string.IsNullOrEmpty(filePath));
        }

        [Test]
        public void FilePathResolverReturnsFilePathWithFileName()
        {
            const string fileName = "Test_File.csv";

            string filePath = FilePathResolver.ResolveFilePath(fileName);

            Assert.IsTrue(filePath.EndsWith(fileName));
        }

        [Test]
        public void FilePathResolverReturnsExpectedFilePath()
        {
            const string fileName = "Test_File.csv";
            string expected = AppDomain.CurrentDomain.BaseDirectory + fileName;

            string filePath = FilePathResolver.ResolveFilePath(fileName);

            Assert.AreEqual(expected, filePath);
        }
    }
}
