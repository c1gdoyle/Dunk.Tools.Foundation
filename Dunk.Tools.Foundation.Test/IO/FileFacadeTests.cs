﻿using System;
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
            Func<string, int, Stream> fileDelegate = null;

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
            Func<string, int, FileOptions, Stream> fileDelegate = null;

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

        [Test]
        public void FileFacadeGetAttributesInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetAttributes", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.GetAttributes.Method);
        }

        [Test]
        public void FileFacadeGetAttributesSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetAttributes", new Type[] { typeof(string) });

            FileFacade.GetAttributes = (a) => FileAttributes.Normal;

            Assert.AreNotEqual(method, FileFacade.GetAttributes.Method);
        }

        [Test]
        public void FileFacadeGetAttributesThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, FileAttributes> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.GetAttributes = fileDelegate);
        }

        [Test]
        public void FileFacadeGetCreationTimeInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetCreationTime", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.GetCreationTime.Method);
        }

        [Test]
        public void FileFacadeGetCreationTimeSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetCreationTime", new Type[] { typeof(string) });

            FileFacade.GetCreationTime = (a) => DateTime.Now;

            Assert.AreNotEqual(method, FileFacade.GetCreationTime.Method);
        }

        [Test]
        public void FileFacadeGetCreationTimeThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, DateTime> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.GetCreationTime = fileDelegate);
        }

        [Test]
        public void FileFacadeGetCreationTimeUtcInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetCreationTimeUtc", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.GetCreationTimeUtc.Method);
        }

        [Test]
        public void FileFacadeGetCreationTimeUtcSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetCreationTimeUtc", new Type[] { typeof(string) });

            FileFacade.GetCreationTimeUtc = (a) => DateTime.UtcNow;

            Assert.AreNotEqual(method, FileFacade.GetCreationTimeUtc.Method);
        }

        [Test]
        public void FileFacadeGetCreationTimeUtcThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, DateTime> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.GetCreationTimeUtc = fileDelegate);
        }

        [Test]
        public void FileFacadeGetLastAccessTimeInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetLastAccessTime", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.GetLastAccessTime.Method);
        }

        [Test]
        public void FileFacadeGetLastAccessTimeSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetLastAccessTime", new Type[] { typeof(string) });

            FileFacade.GetLastAccessTime = (a) => DateTime.Now;

            Assert.AreNotEqual(method, FileFacade.GetLastAccessTime.Method);
        }

        [Test]
        public void FileFacadeGetLastAccessTimeThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, DateTime> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.GetLastAccessTime = fileDelegate);
        }

        [Test]
        public void FileFacadeGetLastAccessTimeUtcInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetLastAccessTimeUtc", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.GetLastAccessTimeUtc.Method);
        }

        [Test]
        public void FileFacadeGetLastAccessTimeUtcSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetLastAccessTimeUtc", new Type[] { typeof(string) });

            FileFacade.GetLastAccessTimeUtc = (a) => DateTime.UtcNow;

            Assert.AreNotEqual(method, FileFacade.GetLastAccessTimeUtc.Method);
        }

        [Test]
        public void FileFacadeGetLastAccessTimeUtcThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, DateTime> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.GetLastAccessTimeUtc = fileDelegate);
        }

        [Test]
        public void FileFacadeGetLastWriteTimeInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetLastWriteTime", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.GetLastWriteTime.Method);
        }

        [Test]
        public void FileFacadeGetLastWriteTimeSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetLastWriteTime", new Type[] { typeof(string) });

            FileFacade.GetLastWriteTime = (a) => DateTime.Now;

            Assert.AreNotEqual(method, FileFacade.GetLastWriteTime.Method);
        }

        [Test]
        public void FileFacadeGetLastWriteTimeThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, DateTime> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.GetLastWriteTime = fileDelegate);
        }

        [Test]
        public void FileFacadeGetLastWriteTimeUtcInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetLastWriteTimeUtc", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.GetLastWriteTimeUtc.Method);
        }

        [Test]
        public void FileFacadeGetLastWriteTimeUtcSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("GetLastWriteTimeUtc", new Type[] { typeof(string) });

            FileFacade.GetLastWriteTimeUtc = (a) => DateTime.UtcNow;

            Assert.AreNotEqual(method, FileFacade.GetLastWriteTimeUtc.Method);
        }

        [Test]
        public void FileFacadeThrowsIfSpeciGetLastWriteTimeUtcfiedDelegateIsNull()
        {
            Func<string, DateTime> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.GetLastWriteTimeUtc = fileDelegate);
        }

        [Test]
        public void FileFacadeMoveInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Move", new Type[] { typeof(string), typeof(string) });

            Assert.AreEqual(method, FileFacade.Move.Method);
        }

        [Test]
        public void FileFacadeMoveSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Move", new Type[] { typeof(string), typeof(string) });

            FileFacade.Move = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.Exists.Method);
        }

        [Test]
        public void FileFacadeMoveThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, string> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.Move = fileDelegate);
        }

        [Test]
        public void FileFacadeOpenInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Open", new Type[] { typeof(string), typeof(FileMode) });

            Assert.AreEqual(method, FileFacade.Open.Method);
        }

        [Test]
        public void FileFacadeOpenSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Open", new Type[] { typeof(string), typeof(FileMode) });

            FileFacade.Open = (a, b) => new MemoryStream();

            Assert.AreNotEqual(method, FileFacade.Open.Method);
        }

        [Test]
        public void FileFacadeOpenThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, FileMode, Stream> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.Open = fileDelegate);
        }

        [Test]
        public void FileFacadeOpenWithFileAccessInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Open", new Type[] { typeof(string), typeof(FileMode), typeof(FileAccess) });

            Assert.AreEqual(method, FileFacade.OpenWithFileAccess.Method);
        }

        [Test]
        public void FileFacadeOpenWithFileAccessSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Open", new Type[] { typeof(string), typeof(FileMode), typeof(FileAccess) });

            FileFacade.OpenWithFileAccess = (a, b, c) => new MemoryStream();

            Assert.AreNotEqual(method, FileFacade.OpenWithFileAccess.Method);
        }

        [Test]
        public void FileFacadeOpenWithFileAccessThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, FileMode, FileAccess, Stream> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.OpenWithFileAccess = fileDelegate);
        }

        [Test]
        public void FileFacadeOpenWithFileShareInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Open", new Type[] { typeof(string), typeof(FileMode), typeof(FileAccess), typeof(FileShare) });

            Assert.AreEqual(method, FileFacade.OpenWithFileShare.Method);
        }

        [Test]
        public void FileFacadeOpenWithFileShareSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Open", new Type[] { typeof(string), typeof(FileMode), typeof(FileAccess), typeof(FileShare) });

            FileFacade.OpenWithFileShare = (a, b, c, d) => new MemoryStream();

            Assert.AreNotEqual(method, FileFacade.OpenWithFileShare.Method);
        }

        [Test]
        public void FileFacadeOpenWithFileShareThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, FileMode, FileAccess, FileShare, Stream> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.OpenWithFileShare = fileDelegate);
        }

        [Test]
        public void FileFacadeOpenReadInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("OpenRead", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.OpenRead.Method);
        }

        [Test]
        public void FileFacadeOpenReadSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("OpenRead", new Type[] { typeof(string) });

            FileFacade.OpenRead = (a) => new MemoryStream();

            Assert.AreNotEqual(method, FileFacade.OpenRead.Method);
        }

        [Test]
        public void FileFacadeOpenReadThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, Stream> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.OpenRead = fileDelegate);
        }

        [Test]
        public void FileFacadeOpenTextInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("OpenText", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.OpenText.Method);
        }

        [Test]
        public void FileFacadeOpenTextSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("OpenText", new Type[] { typeof(string) });

            FileFacade.OpenText = (a) => null;

            Assert.AreNotEqual(method, FileFacade.OpenText.Method);
        }

        [Test]
        public void FileFacadeOpenTextThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, StreamReader> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.OpenText = fileDelegate);
        }

        [Test]
        public void FileFacadeOpenWriteInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("OpenWrite", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.OpenWrite.Method);
        }

        [Test]
        public void FileFacadeOpenWriteSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("OpenWrite", new Type[] { typeof(string) });

            FileFacade.OpenWrite = (a) => new MemoryStream();

            Assert.AreNotEqual(method, FileFacade.OpenWrite.Method);
        }

        [Test]
        public void FileFacadeOpenWriteThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, Stream> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.OpenWrite = fileDelegate);
        }

        [Test]
        public void FileFacadeReadAllBytesInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadAllBytes", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.ReadAllBytes.Method);
        }

        [Test]
        public void FileFacadeReadAllBytesSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadAllBytes", new Type[] { typeof(string) });

            FileFacade.ReadAllBytes = (a) => Array.Empty<byte>();

            Assert.AreNotEqual(method, FileFacade.OpenWrite.Method);
        }

        [Test]
        public void FileFacadeReadAllBytesThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, byte[]> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.ReadAllBytes = fileDelegate);
        }

        [Test]
        public void FileFacadeReadAllLinesInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadAllLines", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.ReadAllLines.Method);
        }

        [Test]
        public void FileFacadeReadAllLinesSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadAllLines", new Type[] { typeof(string) });

            FileFacade.ReadAllLines = (a) => Array.Empty<string>();

            Assert.AreNotEqual(method, FileFacade.ReadAllLines.Method);
        }

        [Test]
        public void FileFacadeReadAllLinesThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, string[]> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.ReadAllLines = fileDelegate);
        }

        [Test]
        public void FileFacadeReadAllLinesWithEncodingInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadAllLines", new Type[] { typeof(string), typeof(Encoding) });

            Assert.AreEqual(method, FileFacade.ReadAllLinesWithEncoding.Method);
        }

        [Test]
        public void FileFacadeReadAllLinesWithEncodingSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadAllLines", new Type[] { typeof(string) });

            FileFacade.ReadAllLinesWithEncoding = (a, b) => Array.Empty<string>();

            Assert.AreNotEqual(method, FileFacade.ReadAllLinesWithEncoding.Method);
        }

        [Test]
        public void FileFacadeReadAllLinesWithEncodingThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, Encoding, string[]> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.ReadAllLinesWithEncoding = fileDelegate);
        }

        [Test]
        public void FileFacadeReadAllTextInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadAllText", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.ReadAllText.Method);
        }

        [Test]
        public void FileFacadeReadAllTextSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadAllText", new Type[] { typeof(string) });

            FileFacade.ReadAllText = (a) => string.Empty;

            Assert.AreNotEqual(method, FileFacade.ReadAllText.Method);
        }

        [Test]
        public void FileFacadeReadAllTextThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, string> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.ReadAllText = fileDelegate);
        }

        [Test]
        public void FileFacadeReadAllTextWithEncodingInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadAllText", new Type[] { typeof(string), typeof(Encoding) });

            Assert.AreEqual(method, FileFacade.ReadAllTextWithEncoding.Method);
        }

        [Test]
        public void FileFacadeReadAllTextWithEncodingSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadAllTextWithEncoding", new Type[] { typeof(string), typeof(Encoding) });

            FileFacade.ReadAllTextWithEncoding = (a, b) => string.Empty;

            Assert.AreNotEqual(method, FileFacade.ReadAllTextWithEncoding.Method);
        }

        [Test]
        public void FileFacadeReadAllTextWithEncodingThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, Encoding, string> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.ReadAllTextWithEncoding = fileDelegate);
        }

        [Test]
        public void FileFacadeReadLinesInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadLines", new Type[] { typeof(string) });

            Assert.AreEqual(method, FileFacade.ReadLines.Method);
        }

        [Test]
        public void FileFacadeReadLinesSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadLines", new Type[] { typeof(string) });

            FileFacade.ReadLines = (a) => Array.Empty<string>();

            Assert.AreNotEqual(method, FileFacade.ReadLines.Method);
        }

        [Test]
        public void FileFacadeReadLinesThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, IEnumerable<string>> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.ReadLines = fileDelegate);
        }

        [Test]
        public void FileFacadeReadLinesWithEncodingInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadLines", new Type[] { typeof(string), typeof(Encoding) });

            Assert.AreEqual(method, FileFacade.ReadLinesWithEncoding.Method);
        }

        [Test]
        public void FileFacadeReadLinesWithEncodingSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("ReadLines", new Type[] { typeof(string), typeof(Encoding) });

            FileFacade.ReadLinesWithEncoding = (a, b) => Array.Empty<string>();

            Assert.AreNotEqual(method, FileFacade.ReadLinesWithEncoding.Method);
        }

        [Test]
        public void FileFacadeReadLinesWithEncodingThrowsIfSpecifiedDelegateIsNull()
        {
            Func<string, Encoding, IEnumerable<string>> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.ReadLinesWithEncoding = fileDelegate);
        }

        [Test]
        public void FileFacadeReplaceInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Replace", new Type[] { typeof(string), typeof(string), typeof(string) });

            Assert.AreEqual(method, FileFacade.Replace.Method);
        }

        [Test]
        public void FileFacadeReplaceSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Replace", new Type[] { typeof(string), typeof(string), typeof(string) });

            FileFacade.Replace = (a, b, c) => { };

            Assert.AreNotEqual(method, FileFacade.Replace.Method);
        }

        [Test]
        public void FileFacadeReplaceThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, string, string> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.Replace = fileDelegate);
        }

        [Test]
        public void FileFacadeReplaceWithIgnoreMetadataInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Replace", new Type[] { typeof(string), typeof(string), typeof(string), typeof(bool) });

            Assert.AreEqual(method, FileFacade.ReplaceWithIgnoreMetadata.Method);
        }

        [Test]
        public void FileFacadeReplaceWithIgnoreMetadataSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("Replace", new Type[] { typeof(string), typeof(string), typeof(string), typeof(bool) });

            FileFacade.ReplaceWithIgnoreMetadata = (a, b, c, d) => { };

            Assert.AreNotEqual(method, FileFacade.ReplaceWithIgnoreMetadata.Method);
        }

        [Test]
        public void FileFacadeReplaceWithIgnoreMetadataThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, string, string, bool> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.ReplaceWithIgnoreMetadata = fileDelegate);
        }

        [Test]
        public void FileFacadeSetAttributesInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetAttributes", new Type[] { typeof(string), typeof(FileAttributes) });

            Assert.AreEqual(method, FileFacade.SetAttributes.Method);
        }

        [Test]
        public void FileFacadeSetAttributesSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetAttributes", new Type[] { typeof(string), typeof(FileAttributes) });

            FileFacade.SetAttributes = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.SetAttributes.Method);
        }

        [Test]
        public void FileFacadeSetAttributesThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, FileAttributes> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.SetAttributes = fileDelegate);
        }

        [Test]
        public void FileFacadeSetCreationTimeInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetCreationTime", new Type[] { typeof(string), typeof(DateTime) });

            Assert.AreEqual(method, FileFacade.SetCreationTime.Method);
        }

        [Test]
        public void FileFacadeSetCreationTimeSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetCreationTime", new Type[] { typeof(string), typeof(DateTime) });

            FileFacade.SetCreationTime = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.SetCreationTime.Method);
        }

        [Test]
        public void FileFacadeSetCreationTimeThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, DateTime> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.SetCreationTime = fileDelegate);
        }

        [Test]
        public void FileFacadeSetCreationTimeUtcInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetCreationTimeUtc", new Type[] { typeof(string), typeof(DateTime) });

            Assert.AreEqual(method, FileFacade.SetCreationTimeUtc.Method);
        }

        [Test]
        public void FileFacadeSetCreationTimeUtcSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetCreationTimeUtc", new Type[] { typeof(string), typeof(DateTime) });

            FileFacade.SetCreationTimeUtc = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.SetCreationTimeUtc.Method);
        }

        [Test]
        public void FileFacadeSetCreationTimeUtcThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, DateTime> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.SetCreationTimeUtc = fileDelegate);
        }

        [Test]
        public void FileFacadeSetLastAccessTimeInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetLastAccessTime", new Type[] { typeof(string), typeof(DateTime) });

            Assert.AreEqual(method, FileFacade.SetLastAccessTime.Method);
        }

        [Test]
        public void FileFacadeSetLastAccessTimeSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetLastAccessTime", new Type[] { typeof(string), typeof(DateTime) });

            FileFacade.SetLastAccessTime = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.SetLastAccessTime.Method);
        }

        [Test]
        public void FileFacadeSetLastAccessTimeThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, DateTime> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.SetLastAccessTime = fileDelegate);
        }

        [Test]
        public void FileFacadeSetLastAccessTimeUtcInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetLastAccessTimeUtc", new Type[] { typeof(string), typeof(DateTime) });

            Assert.AreEqual(method, FileFacade.SetLastAccessTimeUtc.Method);
        }

        [Test]
        public void FileFacadeSetLastAccessTimeUtcSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetLastAccessTimeUtc", new Type[] { typeof(string), typeof(DateTime) });

            FileFacade.SetLastAccessTimeUtc = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.SetLastAccessTimeUtc.Method);
        }

        [Test]
        public void FileFacadeSetLastAccessTimeUtcThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, DateTime> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.SetLastAccessTimeUtc = fileDelegate);
        }

        [Test]
        public void FileFacadeSetWriteAccessTimeInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetLastWriteTime", new Type[] { typeof(string), typeof(DateTime) });

            Assert.AreEqual(method, FileFacade.SetLastWriteTime.Method);
        }

        [Test]
        public void FileFacadeSetLastWriteTimeSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetLastWriteTime", new Type[] { typeof(string), typeof(DateTime) });

            FileFacade.SetLastWriteTime = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.SetLastWriteTime.Method);
        }

        [Test]
        public void FileFacadeSetLastWriteTimeThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, DateTime> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.SetLastWriteTime = fileDelegate);
        }

        [Test]
        public void FileFacadeSetLastWriteTimeUtcInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetLastWriteTimeUtc", new Type[] { typeof(string), typeof(DateTime) });

            Assert.AreEqual(method, FileFacade.SetLastWriteTimeUtc.Method);
        }

        [Test]
        public void FileFacadeSetLastWriteTimeUtcSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("SetLastWriteTimeUtc", new Type[] { typeof(string), typeof(DateTime) });

            FileFacade.SetLastWriteTimeUtc = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.SetLastWriteTimeUtc.Method);
        }

        [Test]
        public void FileFacadeSetLastWriteTimeUtcThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, DateTime> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.SetLastWriteTimeUtc = fileDelegate);
        }

        [Test]
        public void FileFacadeWriteAllBytesInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllBytes", new Type[] { typeof(string), typeof(byte[]) });

            Assert.AreEqual(method, FileFacade.WriteAllBytes.Method);
        }

        [Test]
        public void FileFacadeWriteAllBytesSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllBytes", new Type[] { typeof(string), typeof(byte[]) });

            FileFacade.WriteAllBytes = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.WriteAllBytes.Method);
        }

        [Test]
        public void FileFacadeWriteAllBytesThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, byte[]> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.WriteAllBytes = fileDelegate);
        }

        [Test]
        public void FileFacadeWriteAllLinesInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllLines", new Type[] { typeof(string), typeof(IEnumerable<string>) });

            Assert.AreEqual(method, FileFacade.WriteAllLines.Method);
        }

        [Test]
        public void FileFacadeWriteAllLinesSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllLines", new Type[] { typeof(string), typeof(IEnumerable<string>) });

            FileFacade.WriteAllLines = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.WriteAllLines.Method);
        }

        [Test]
        public void FileFacadeWriteAllLinesThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, IEnumerable<string>> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.WriteAllLines = fileDelegate);
        }

        [Test]
        public void FileFacadeWriteAllLinesWithEncodingInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllLines", new Type[] { typeof(string), typeof(IEnumerable<string>), typeof(Encoding) });

            Assert.AreEqual(method, FileFacade.WriteAllLinesWithEncoding.Method);
        }

        [Test]
        public void FileFacadeWriteAllLinesWithEncodingSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllLines", new Type[] { typeof(string), typeof(IEnumerable<string>), typeof(Encoding) });

            FileFacade.WriteAllLinesWithEncoding = (a, b, c) => { };

            Assert.AreNotEqual(method, FileFacade.WriteAllLinesWithEncoding.Method);
        }

        [Test]
        public void FileFacadeWriteAllLinesWithEncodingThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, IEnumerable<string>, Encoding> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.WriteAllLinesWithEncoding = fileDelegate);
        }

        [Test]
        public void FileFacadeWriteAllLinesArrayInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllLines", new Type[] { typeof(string), typeof(string[]) });

            Assert.AreEqual(method, FileFacade.WriteAllLinesArray.Method);
        }

        [Test]
        public void FileFacadeWriteAllLinesArraySupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllLines", new Type[] { typeof(string), typeof(string[]) });

            FileFacade.WriteAllLinesArray = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.WriteAllLinesArray.Method);
        }

        [Test]
        public void FileFacadeWriteAllLinesArrayThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, string[]> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.WriteAllLinesArray = fileDelegate);
        }

        [Test]
        public void FileFacadeWriteAllLinesArrayWithEncodingInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllLines", new Type[] { typeof(string), typeof(string[]), typeof(Encoding) });

            Assert.AreEqual(method, FileFacade.WriteAllLinesArrayWithEncoding.Method);
        }

        [Test]
        public void FileFacadeWriteAllLinesArrayWithEncodingSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllLines", new Type[] { typeof(string), typeof(string[]), typeof(Encoding) });

            FileFacade.WriteAllLinesArrayWithEncoding = (a, b, c) => { };

            Assert.AreNotEqual(method, FileFacade.WriteAllLinesArrayWithEncoding.Method);
        }

        [Test]
        public void FileFacadeWriteAllLinesArrayWithEncodingThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, string[], Encoding> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.WriteAllLinesArrayWithEncoding = fileDelegate);
        }

        [Test]
        public void FileFacadeWriteAllTextInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllText", new Type[] { typeof(string), typeof(string) });

            Assert.AreEqual(method, FileFacade.WriteAllText.Method);
        }

        [Test]
        public void FileFacadeWriteAllTextSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllText", new Type[] { typeof(string), typeof(string) });

            FileFacade.WriteAllText = (a, b) => { };

            Assert.AreNotEqual(method, FileFacade.WriteAllText.Method);
        }

        [Test]
        public void FileFacadeWriteAllTextThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, string> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.WriteAllText = fileDelegate);
        }

        [Test]
        public void FileFacadeWriteAllTextWithEncodingInitialisesWithExpectedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllText", new Type[] { typeof(string), typeof(string), typeof(Encoding) });

            Assert.AreEqual(method, FileFacade.WriteAllTextWithEncoding.Method);
        }

        [Test]
        public void FileFacadeWriteAllTextWithEncodingSupportsSettingSpecifiedDelegate()
        {
            var method = typeof(File)
                .GetMethod("WriteAllText", new Type[] { typeof(string), typeof(string), typeof(Encoding) });

            FileFacade.WriteAllTextWithEncoding = (a, b, c) => { };

            Assert.AreNotEqual(method, FileFacade.WriteAllTextWithEncoding.Method);
        }

        [Test]
        public void FileFacadeWriteTextWithEncodingThrowsIfSpecifiedDelegateIsNull()
        {
            Action<string, string, Encoding> fileDelegate = null;

            Assert.Throws<ArgumentNullException>(() =>
                FileFacade.WriteAllTextWithEncoding = fileDelegate);
        }

        [SetUp]
        public void Setup()
        {
            FileFacade.ResetDefaults();
        }
    }
}
