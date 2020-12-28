using System;
using System.Collections.Generic;
using System.IO;
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

        [SetUp]
        public void Setup()
        {
            FileFacade.ResetDefaults();
        }
    }
}
