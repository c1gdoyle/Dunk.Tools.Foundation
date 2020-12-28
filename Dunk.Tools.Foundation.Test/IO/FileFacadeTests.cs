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

        [SetUp]
        public void Setup()
        {
            FileFacade.ResetDefaults();
        }
    }
}
