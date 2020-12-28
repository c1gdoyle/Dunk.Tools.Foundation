using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Dunk.Tools.Foundation.IO;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.IO
{
    [TestFixture]
    public class FileFacadeTests
    {
        [Test]
        public void FileFacadeAppendAllLinesInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("AppendAllLines", new Type[] { typeof(string), typeof(string[]) });

            Assert.AreEqual(method, FileFacade.AppendAllLines.Method);
        }

        [Test]
        public void FileFacadeAppendAllLinesSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("AppendAllLines", new Type[] { typeof(string), typeof(string[]) });

            FileFacade.AppendAllLines = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.AppendAllLines.Method);
        }

        [Test]
        public void FileFacadeAppendAllLinesThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, IEnumerable<string>> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.AppendAllLines = fileDelegate);
        }

        [Test]
        public void FileFacadeAppendAllLinesWithEncodingInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("AppendAllLines", new Type[] { typeof(string), typeof(string[]), typeof(Encoding) });

            Assert.AreEqual(method, FileFacade.AppendAllLinesWithEncoding.Method);
        }

        [Test]
        public void FileFacadeAppendAllLinesWithEncodingSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("AppendAllLines", new Type[] { typeof(string), typeof(string[]), typeof(Encoding) });

            FileFacade.AppendAllLinesWithEncoding = (a, b, c) => { };

            Assert.AreNotEqual(method, FileFacade.AppendAllLinesWithEncoding.Method);
        }

        [Test]
        public void FileFacadeAppendAllLinesWithEncodingThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, IEnumerable<string>, Encoding> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.AppendAllLinesWithEncoding = fileDelegate);
        }

        [Test]
        public void FileFacadeAppendAllTextInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("AppendAllText", new Type[] { typeof(string), typeof(string) });

            Assert.AreEqual(method, FileFacade.AppendAllText.Method);
        }

        [Test]
        public void FileFacadeAppendAllTextSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("AppendAllText", new Type[] { typeof(string), typeof(string) });

            FileFacade.AppendAllText = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.AppendAllText.Method);
        }

        [Test]
        public void FileFacadeAppendAllTextThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, string> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.AppendAllText = fileDelegate);
        }

        [Test]
        public void FileFacadeAppendAllTextWithEncodingInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("AppendAllText", new Type[] { typeof(string), typeof(string), typeof(Encoding) });

            Assert.AreEqual(method, FileFacade.AppendAllTextWithEncoding.Method);
        }

        [Test]
        public void FileFacadeAppendAllTextWithEncodingSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("AppendAllText", new Type[] { typeof(string), typeof(string), typeof(Encoding) });

            FileFacade.AppendAllTextWithEncoding = (a, b, c) => { };

            Assert.AreNotEqual(method, FileFacade.AppendAllTextWithEncoding.Method);
        }

        [Test]
        public void FileFacadeAppendAllTextWithEncodingThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, string, Encoding> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.AppendAllTextWithEncoding = fileDelegate);
        }

        [Test]
        public void FileFacadeAppendTextInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("AppendText", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.AppendText.Method);
        }

        [Test]
        public void FileFacadeAppendTextSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("AppendText", new Type[] { typeof(string) });

            FileFacade.AppendText = a => null;

            Assert.AreNotEqual(method, FileFacade.AppendText.Method);
        }

        [Test]
        public void FileFacadeAppendTextThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, StreamWriter> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.AppendText = fileDelegate);
        }

        [Test]
        public void FileFacadeCopyInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Copy", new Type[] { typeof(string), typeof(string) });

            Assert.AreEqual(method, FileFacade.Copy.Method);
        }

        [Test]
        public void FileFacadeCopySupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Copy", new Type[] { typeof(string), typeof(string) });

            FileFacade.Copy = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.Copy.Method);
        }

        [Test]
        public void FileFacadeCopyThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, string> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.Copy = fileDelegate);
        }

        [Test]
        public void FileFacadeCopyAndOverwriteInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Copy", new Type[] { typeof(string), typeof(string), typeof(bool) });

            Assert.AreEqual(method, FileFacade.CopyAndOverwrite.Method);
        }

        [Test]
        public void FileFacadeCopyAndOverwriteSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Copy", new Type[] { typeof(string), typeof(string), typeof(bool) });

            FileFacade.CopyAndOverwrite = (a, b, c) => { };

            Assert.AreNotEqual(method, FileFacade.CopyAndOverwrite.Method);
        }

        [Test]
        public void FileFacadeCopyAndOverwriteThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, string, bool> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.CopyAndOverwrite = fileDelegate);
        }

        [Test]
        public void FileFacadeCreateInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Create", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.Create.Method);
        }

        [Test]
        public void FileFacadeCreateSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Create", new Type[] { typeof(string) });

            FileFacade.Create = (a) => new MemoryStream();

            Assert.AreNotEqual(method, FileFacade.CopyAndOverwrite.Method);
        }

        [Test]
        public void FileFacadeCreateThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, Stream> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.Create = fileDelegate);
        }

        [Test]
        public void FileFacadeCreateWithBufferInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Create", new Type[] { typeof(string), typeof(int) });

            Assert.AreEqual(method, FileFacade.CreateWithBuffer.Method);
        }

        [Test]
        public void FileFacadeCreateWithBufferSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Create", new Type[] { typeof(string), typeof(int) });

            FileFacade.CreateWithBuffer = (a, b) => new MemoryStream();

            Assert.AreNotEqual(method, FileFacade.CreateWithBuffer.Method);
        }

        [Test]
        public void FileFacadeCreateWithBufferThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string,int, Stream> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.CreateWithBuffer = fileDelegate);
        }

        [Test]
        public void FileFacadeCreateWithFileOptionsInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Create", new Type[] { typeof(string), typeof(int), typeof(FileOptions) });

            Assert.AreEqual(method, FileFacade.CreateWithFileOptions.Method);
        }

        [Test]
        public void FileFacadeCreateWithFileOptionsSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Create", new Type[] { typeof(string), typeof(int), typeof(FileOptions) });

            FileFacade.CreateWithFileOptions = (a, b, c) => new MemoryStream();

            Assert.AreNotEqual(method, FileFacade.CreateWithFileOptions.Method);
        }

        [Test]
        public void FileFacadeCreateWithFileOptionsThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string,int,FileOptions,Stream> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.CreateWithFileOptions = fileDelegate);
        }

        [Test]
        public void FileFacadeCreateTextInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("CreateText", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.CreateText.Method);
        }

        [Test]
        public void FileFacadeCreateTextSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("CreateText", new Type[] { typeof(string) });

            FileFacade.CreateText = (a) => null;

            Assert.AreNotEqual(method, FileFacade.CreateText.Method);
        }

        [Test]
        public void FileFacadeCreateTextThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, StreamWriter> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.CreateText = fileDelegate);
        }

        [Test]
        public void FileFacadeDecryptInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Decrypt", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.Decrypt.Method);
        }

        [Test]
        public void FileFacadeDecryptSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Decrypt", new Type[] { typeof(string) });

            FileFacade.Decrypt = (a) => { };

            Assert.AreNotEqual(method, FileFacade.Decrypt.Method);
        }

        [Test]
        public void FileFacadeDecryptThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.Decrypt = fileDelegate);
        }

        [Test]
        public void FileFacadeDeleteInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Delete", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.Delete.Method);
        }

        [Test]
        public void FileFacadeDeleteSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Delete", new Type[] { typeof(string) });

            FileFacade.Delete = (a) => { };

            Assert.AreNotEqual(method, FileFacade.Delete.Method);
        }

        [Test]
        public void FileFacadeDeleteTextThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.Delete = fileDelegate);
        }

        [Test]
        public void FileFacadeEncryptInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Encrypt", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.Encrypt.Method);
        }

        [Test]
        public void FileFacadeEncryptSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Encrypt", new Type[] { typeof(string) });

            FileFacade.Encrypt = (a) => { };

            Assert.AreNotEqual(method, FileFacade.Encrypt.Method);
        }

        [Test]
        public void FileFacadeEncryptThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.Encrypt = fileDelegate);
        }

        [Test]
        public void FileFacadeExistsInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Exists", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.Exists.Method);
        }

        [Test]
        public void FileFacadeExistsSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Exists", new Type[] { typeof(string) });

            FileFacade.Exists = (a) => true;

            Assert.AreNotEqual(method, FileFacade.Exists.Method);
        }

        [Test]
        public void FileFacadeExistsThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, bool> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.Exists = fileDelegate);
        }

        [SetUp]
        public void Setup()
        {
            FileFacade.ResetDefaults();
        }
    }
}
