using System;
using System.Collections.Generic;
using System.Dynamic;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class DynamicObjectExtensionsTests
    {
        [Test]
        public void ConvertToDynamicObjectThrowsIfObjectIsNull()
        {
            TestLanguageChangedEventArgs obj = null;

            Assert.Throws<ArgumentNullException>(() => obj.ConvertToExpando());
        }

        [Test]
        public void ConvertToDynamicObjectReturnsDynamicObject()
        {
            var obj = new TestLanguageChangedEventArgs { Language = "English" };

            ExpandoObject expando = obj.ConvertToExpando();

            Assert.IsNotNull(expando);
        }

        [Test]
        public void ConvertToDynamicObjectReturnsDynamicObjectWithProperties()
        {
            var obj = new TestLanguageChangedEventArgs { Language = "English" };

            ExpandoObject expando = obj.ConvertToExpando();

            Assert.IsTrue(((IDictionary<string, object>)expando).ContainsKey("Language"));
        }

        [Test]
        public void ConvertToDynamicObjectReturnsDynamicObjectWithPropertyValue()
        {

            var obj = new TestLanguageChangedEventArgs { Language = "English" };

            ExpandoObject expando = obj.ConvertToExpando();

            var result = ((IDictionary<string, object>)expando)["Language"];

            Assert.AreEqual("English", result);
        }

        [Test]
        public void AddOrSetPropertyThrowsIfExpandoObjectIsNull()
        {
            ExpandoObject o = null;

            Assert.Throws<ArgumentNullException>(() => o.AddOrSetProperty("Property1", 2));
        }

        [Test]
        public void AddOrSetPropertyThrowsIfPropertyNameIsNull()
        {
            ExpandoObject o = new ExpandoObject();

            Assert.Throws<ArgumentNullException>(() => o.AddOrSetProperty(null, 2));
        }

        [Test]
        public void AddOrSetPropertyThrowsIfPropertyNameIsEmpty()
        {
            ExpandoObject o = new ExpandoObject();

            Assert.Throws<ArgumentNullException>(() => o.AddOrSetProperty(string.Empty, 2));
        }

        [Test]
        public void DynamicObjectAddsPropertyWithSpecifiedValue()
        {
            dynamic o = new ExpandoObject();
            ((ExpandoObject)o).AddOrSetProperty("Property1", 2);

            object result = o.Property1;

            Assert.AreEqual(2, result);
        }

        [Test]
        public void DynamicObjectSetsExistingPropertyWithSpecifiedValue()
        {
            dynamic o = new ExpandoObject();
            o.Property1 = 2;
            ((ExpandoObject)o).AddOrSetProperty("Property1", 3);

            object result = o.Property1;

            Assert.AreEqual(3, result);
        }

        [Test]
        public void DynamicObjectAddsEventThrowsIfExpandoObjectIsNull()
        {
            ExpandoObject o = null;

            Assert.Throws<ArgumentNullException>(() => o.AddOrSetEvent("Event_1", (x, y) => { }));
        }

        [Test]
        public void DynamicObjectAddsEventThrowsIfEventNameIsNull()
        {
            ExpandoObject o = new ExpandoObject();

            Assert.Throws<ArgumentNullException>(() => o.AddOrSetEvent(null, (x, y) => { }));
        }

        [Test]
        public void DynamicObjectAddsEventThrowsIfEventNameIsEmpty()
        {
            ExpandoObject o = new ExpandoObject();

            Assert.Throws<ArgumentNullException>(() => o.AddOrSetEvent(string.Empty, (x, y) => { }));
        }

        [Test]
        public void DynamicObjectAddsEventThrowsIfEventHandlerIsNull()
        {
            ExpandoObject o = new ExpandoObject();

            Assert.Throws<ArgumentNullException>(() => o.AddOrSetEvent("Event_1", null));
        }

        [Test]
        public void DynamicObjectAddsEventWithSpecifiedHandler()
        {
            string language = null;

            dynamic o = new ExpandoObject();
            Action<object, EventArgs> eventHandler = (sender, args) =>
            {
                var lArgs = args as TestLanguageChangedEventArgs;
                language = lArgs?.Language;
            };
            ((ExpandoObject)o).AddOrSetEvent("LanguageChanged", eventHandler);

            o.LanguageChanged(o, new TestLanguageChangedEventArgs { Language = "English" });

            Assert.AreEqual("English", language);
        }

        private sealed class TestLanguageChangedEventArgs : EventArgs
        {
            public string Language { get; set; }
        }
    }
}
