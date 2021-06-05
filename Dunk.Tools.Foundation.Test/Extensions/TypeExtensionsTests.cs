using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Dunk.Tools.Foundation.Collections;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class TypeExtensionsTests
    {
        [Test]
        public void GetAttributeFromTypeThrowsIfNull()
        {
            Assert.Throws<ArgumentNullException>(() => (null as Type).GetAttribute<TestClassAttribute>());
        }

        [Test]
        public void GetAttributesFromMemberInfoThrowsIfNull()
        {
            Assert.Throws<ArgumentNullException>(() => (null as MemberInfo).GetAttributes<TestClassAttribute>());
        }
        [Test]
        public void GetAttributesFromTypeThrowsIfNull()
        {
            Assert.Throws<ArgumentNullException>(() => (null as Type).GetAttributes<TestClassAttribute>());
        }

        [Test]
        public void GetAttributeFromMemberInfoThrowsIfNull()
        {
            Assert.Throws<ArgumentNullException>(() => (null as MemberInfo).GetAttribute<TestClassAttribute>());
        }

        [Test]
        public void GetAttributeFromTypeReturnsAttribute()
        {
            Type type = typeof(Person);

            TestClassAttribute attribute = type.GetAttribute<TestClassAttribute>();

            Assert.IsNotNull(attribute);
            Assert.AreEqual(1, attribute.Id);
        }

        [Test]
        public void GetAttributeFromTypeReturnsNullIfAttributeIsNotPresentOnType()
        {
            Type type = typeof(Person);

            TestMember1Attribute attribute = type.GetAttribute<TestMember1Attribute>();

            Assert.IsNull(attribute);
        }

        [Test]
        public void GetAttributesFromTypeReturnsAttributes()
        {
            Type type = typeof(Person);

            TestClassAttribute[] attributes = type.GetAttributes<TestClassAttribute>();

            Assert.IsNotNull(attributes);
            Assert.AreEqual(1, attributes.Length);
        }

        [Test]
        public void GetAttributesFromTypeReturnsEmptyArrayIfAttributeIsNotPresentOnType()
        {
            Type type = typeof(Person);

            TestMember1Attribute[] attributes = type.GetAttributes<TestMember1Attribute>();

            Assert.IsNotNull(attributes);
            Assert.AreEqual(0, attributes.Length);
        }

        [Test]
        public void GetAttributeFromMemberReturnsAttribute()
        {
            Expression<Func<Person, int>> selector = p => p.Age;
            PropertyInfo property = selector.GetPropertyInfo();

            TestMember1Attribute attribute = property.GetAttribute<TestMember1Attribute>();

            Assert.IsNotNull(attribute);
            Assert.AreEqual(4, attribute.Id);
        }

        [Test]
        public void GetAttributeFromMemberReutrnsNullIfAttributeIsNotPresentOnMember()
        {
            Expression<Func<Person, int>> selector = p => p.Age;
            PropertyInfo property = selector.GetPropertyInfo();

            TestClassAttribute attribute = property.GetAttribute<TestClassAttribute>();

            Assert.IsNull(attribute);
        }

        [Test]
        public void GetAttributesFromMemberReturnsAttributes()
        {
            Expression<Func<Person, int>> selector = p => p.Age;
            PropertyInfo property = selector.GetPropertyInfo();

            TestMemberBaseAttribute[] attributes = property.GetAttributes<TestMemberBaseAttribute>();

            Assert.IsNotNull(attributes);
            Assert.AreEqual(2, attributes.Length);
        }


        [Test]
        public void GetAttributesFromMemberReturnsEmotyArrayIfAttributeIsNotPresentOnMember()
        {
            Expression<Func<Person, int>> selector = p => p.Age;
            PropertyInfo property = selector.GetPropertyInfo();

            TestClassAttribute[] attributes = property.GetAttributes<TestClassAttribute>();

            Assert.IsNotNull(attributes);
            Assert.AreEqual(0, attributes.Length);
        }

        [Test]
        public void GetExtensionMethodsThrowsIfTypeIsNull()
        {
            Type t = null;
            Assert.Throws<ArgumentNullException>(() => t.GetExtensionMethods());
        }

        [Test]
        public void GetExtensionMethodsInAssemblyThrowsIfTypeIsNull()
        {
            Type t = null;
            Assembly a = typeof(Person).Assembly;

            Assert.Throws<ArgumentNullException>(() => t.GetExtensionMethods(a));
        }

        [Test]
        public void GetExtensionMethodsThrowsIfAssemblyIsNull()
        {
            Type t = typeof(Person);
            Assert.Throws<ArgumentNullException>(() => t.GetExtensionMethods(null as Assembly));
        }

        [Test]
        public void GetExtensionMethodsReturnsExtensionMethodForSpecifiedType()
        {
            Type t = typeof(Person);

            var methods = t.GetExtensionMethods();

            Assert.IsNotNull(methods);
            Assert.AreEqual(1, methods.Count());
        }

        [Test]
        public void GetExtensionMethodsInAssemblyReturnsExtensionMethodForSpecifiedType()
        {
            Type t = typeof(Person);
            Assembly a = typeof(Person).Assembly;

            var methods = t.GetExtensionMethods(a);

            Assert.IsNotNull(methods);
            Assert.AreEqual(1, methods.Count());
        }

        [Test]
        public void GetBaseTypesThrowsIfTypeIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => (null as Type).GetBaseTypes().ToList());
        }

        [Test]
        public void GetBaseTypesExcludingObjectThrowsIfTypeIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => (null as Type).GetBaseTypesExcludingObject().ToList());
        }

        [Test]
        public void GetBaseTypesReturnsBaseTypesIncludingSelf()
        {
            var types = typeof(TestDerivedDerivedDerived)
                .GetBaseTypes()
                .ToList();

            Assert.AreEqual(5, types.Count);
        }

        [Test]
        public void GetBaseTypesReturnsBaseTypesExcludingSelf()
        {
            var types = typeof(TestDerivedDerivedDerived)
                .GetBaseTypes(false)
                .ToList();

            Assert.AreEqual(4, types.Count);
        }


        [Test]
        public void GetBaseTypesExcludingObjectReturnsBaseTypesIncludingSelf()
        {
            var types = typeof(TestDerivedDerivedDerived)
                .GetBaseTypesExcludingObject()
                .ToList();

            Assert.AreEqual(4, types.Count);
        }

        [Test]
        public void GetBaseTypesExcludingObjectReturnsBaseTypesExcludingSelf()
        {
            var types = typeof(TestDerivedDerivedDerived)
                .GetBaseTypesExcludingObject(false)
                .ToList();

            Assert.AreEqual(3, types.Count);
        }

        [Test]
        public void GetBaseTypesExcludingObjectReturnsEmptyIfTypeIsObject()
        {
            var types = typeof(object)
                .GetBaseTypesExcludingObject()
                .ToList();

            Assert.AreEqual(0, types.Count);
        }

        [Test]
        public void GetAllPropertiesReturnsExpectedNumberOfPropertiesFromInterface()
        {
            var properties = typeof(ITestDerivedDervied)
                .GetAllProperties();

            Assert.AreEqual(3, properties.Length);
        }

        [Test]
        public void GetAllPropertiesReturnsExpectedOrderOfPropertiesFromInterface()
        {
            var properties = typeof(ITestDerivedDervied)
                .GetAllProperties();

            Assert.AreEqual("PropertyA", properties[0].Name);
            Assert.AreEqual("PropertyB", properties[1].Name);
            Assert.AreEqual("PropertyC", properties[2].Name);
        }

        [Test]
        public void GetAllPropertiesReturnsExpectedNumberOfPropertiesFromClass()
        {
            var properties = typeof(TestDerivedDerived)
                .GetAllProperties();

            Assert.AreEqual(3, properties.Length);
        }

        [Test]
        public void GetAllPropertiesReturnsExpectedOrderOfPropertiesFromClass()
        {
            var properties = typeof(TestDerivedDerived)
                .GetAllProperties();

            Assert.AreEqual("PropertyC", properties[0].Name);
            Assert.AreEqual("PropertyB", properties[1].Name);
            Assert.AreEqual("PropertyA", properties[2].Name);
        }

        [Test]
        public void GetAllPublicPropertiesReturnsExpectedNumberOfPropertiesFromInterface()
        {
            var properties = typeof(ITestDerivedDervied)
                .GetAllPublicProperties();

            Assert.AreEqual(3, properties.Length);
        }

        [Test]
        public void GetAllPublicPropertiesReturnsExpectedOrderOfPropertiesFromInterface()
        {
            var properties = typeof(ITestDerivedDervied)
                .GetAllPublicProperties();

            Assert.AreEqual("PropertyA", properties[0].Name);
            Assert.AreEqual("PropertyB", properties[1].Name);
            Assert.AreEqual("PropertyC", properties[2].Name);
        }

        [Test]
        public void GetAllPublicPropertiesReturnsExpectedNumberOfPropertiesFromClass()
        {
            var properties = typeof(TestDerivedDerived)
                .GetAllPublicProperties();

            Assert.AreEqual(3, properties.Length);
        }

        [Test]
        public void GetAllPublicPropertiesReturnsExpectedOrderOfPropertiesFromClass()
        {
            var properties = typeof(TestDerivedDerived)
                .GetAllPublicProperties();

            Assert.AreEqual("PropertyC", properties[0].Name);
            Assert.AreEqual("PropertyB", properties[1].Name);
            Assert.AreEqual("PropertyA", properties[2].Name);
        }

        [Test]
        public void GetAllMethodsReturnsExpectedNumberOfMethodsFromInterface()
        {
            var methods = typeof(ITestDerivedDervied)
                .GetAllMethods();

            Assert.AreEqual(3, methods.Length);
        }

        [Test]
        public void GetAllMethodsReturnsExpectedOrderOfMethodsFromInterface()
        {
            var methods = typeof(ITestDerivedDervied)
                .GetAllMethods();

            Assert.AreEqual("get_PropertyA", methods[0].Name);
            Assert.AreEqual("get_PropertyB", methods[1].Name);
            Assert.AreEqual("get_PropertyC", methods[2].Name);
        }

        [Test]
        public void GetAllMethodsReturnsExpectedNumberOfMethodsFromClass()
        {
            var methods = typeof(TestDerivedDerived)
                .GetAllMethods();

            Assert.AreEqual(12, methods.Length);
        }

        [Test]
        public void GetAllMethodsReturnsExpectedOrderOfMethodsFromClass()
        {
            var methods = typeof(TestDerivedDerived)
                .GetAllMethods();

            Assert.AreEqual("get_PropertyC", methods[0].Name);
            Assert.AreEqual("set_PropertyC", methods[1].Name);
            Assert.AreEqual("get_PropertyB", methods[2].Name);
            Assert.AreEqual("set_PropertyB", methods[3].Name);
            Assert.AreEqual("get_PropertyA", methods[4].Name);
            Assert.AreEqual("set_PropertyA", methods[5].Name);
        }

        [Test]
        public void GetAllMethodsExcludingObjectBaseReturnsExpectedNumberOfMethodsFromClass()
        {
            var methods = typeof(TestDerivedDerived)
                .GetAllMethodsExcludingObjectBase();

            Assert.AreEqual(6, methods.Length);
        }

        [Test]
        public void GetAllMethodsExcludingObjectBaseReturnsExpectedOrderOfMethodsFromClass()
        {
            var methods = typeof(TestDerivedDerived)
                .GetAllMethodsExcludingObjectBase();

            Assert.AreEqual("get_PropertyC", methods[0].Name);
            Assert.AreEqual("set_PropertyC", methods[1].Name);
            Assert.AreEqual("get_PropertyB", methods[2].Name);
            Assert.AreEqual("set_PropertyB", methods[3].Name);
            Assert.AreEqual("get_PropertyA", methods[4].Name);
            Assert.AreEqual("set_PropertyA", methods[5].Name);
        }

        [Test]
        public void GetAllPublicMethodsReturnsExpectedNumberOfMethodsFromInterface()
        {
            var methods = typeof(ITestDerivedDervied)
                .GetAllPublicMethods();

            Assert.AreEqual(3, methods.Length);
        }

        [Test]
        public void GetAllPublicMethodsReturnsExpectedOrderOfMethodsFromInterface()
        {
            var methods = typeof(ITestDerivedDervied)
                .GetAllPublicMethods();

            Assert.AreEqual("get_PropertyA", methods[0].Name);
            Assert.AreEqual("get_PropertyB", methods[1].Name);
            Assert.AreEqual("get_PropertyC", methods[2].Name);
        }

        [Test]
        public void GetAllPublicMethodsReturnsExpectedNumberOfMethodsFromClass()
        {
            var methods = typeof(TestDerivedDerived)
                .GetAllPublicMethods();

            Assert.AreEqual(10, methods.Length);
        }

        [Test]
        public void GetAllPublicMethodsReturnsExpectedOrderOfMethodsFromClass()
        {
            var methods = typeof(TestDerivedDerived)
                .GetAllPublicMethods();

            Assert.AreEqual("get_PropertyC", methods[0].Name);
            Assert.AreEqual("set_PropertyC", methods[1].Name);
            Assert.AreEqual("get_PropertyB", methods[2].Name);
            Assert.AreEqual("set_PropertyB", methods[3].Name);
            Assert.AreEqual("get_PropertyA", methods[4].Name);
            Assert.AreEqual("set_PropertyA", methods[5].Name);
        }

        [Test]
        public void GetAllPublicMethodsExcludingObjectBaseReturnsExpectedNumberOfMethodsFromClass()
        {
            var methods = typeof(TestDerivedDerived)
                .GetAllPublicMethodsExcludingObjectBase();

            Assert.AreEqual(6, methods.Length);
        }

        [Test]
        public void GetAllPublicMethodsExcludingObjectBaseReturnsExpectedOrderOfMethodsFromClass()
        {
            var methods = typeof(TestDerivedDerived)
                .GetAllPublicMethodsExcludingObjectBase();

            Assert.AreEqual("get_PropertyC", methods[0].Name);
            Assert.AreEqual("set_PropertyC", methods[1].Name);
            Assert.AreEqual("get_PropertyB", methods[2].Name);
            Assert.AreEqual("set_PropertyB", methods[3].Name);
            Assert.AreEqual("get_PropertyA", methods[4].Name);
            Assert.AreEqual("set_PropertyA", methods[5].Name);
        }

        [Test]
        public void GetAllPropertiesThrowsIfTypeIsNull()
        {
            Type t = null;
            Assert.Throws<ArgumentNullException>(() => t.GetAllProperties());
        }

        [Test]
        public void GetAllPublicPropertiesThrowsIfTypeIsNull()
        {
            Type t = null;
            Assert.Throws<ArgumentNullException>(() => t.GetAllPublicProperties());
        }

        [Test]
        public void GetAllMethodsThrowsIfTypeIsNull()
        {
            Type t = null;
            Assert.Throws<ArgumentNullException>(() => t.GetAllMethods());
        }

        [Test]
        public void GetAllMethodsExcludingObjectBaseThrowsIfTypeIsNull()
        {
            Type t = null;
            Assert.Throws<ArgumentNullException>(() => t.GetAllMethodsExcludingObjectBase());
        }

        [Test]
        public void GetAllPublicMethodsThrowsIfTypeIsNull()
        {
            Type t = null;
            Assert.Throws<ArgumentNullException>(() => t.GetAllPublicMethods());
        }

        [Test]
        public void GetAllPublicMethodsExcludingObjectBaseThrowsIfTypeIsNull()
        {
            Type t = null;
            Assert.Throws<ArgumentNullException>(() => t.GetAllPublicMethodsExcludingObjectBase());
        }

        [Test]
        public void FindEnumerableReturnsNullIfTypeIsNull()
        {
            Type sequenceType = null;

            Type result = sequenceType.FindEnumerable();

            Assert.IsNull(result);
        }

        [Test]
        public void FindEnumerableReturnsNullIfTypeIsString()
        {
            Type sequenceType = typeof(string);

            Type result = sequenceType.FindEnumerable();

            Assert.IsNull(result);
        }

        [Test]
        public void FindEnumerableReturnsNullForNonEnumerableType()
        {
            Type sequenceType = typeof(DateTime);

            Type result = sequenceType.FindEnumerable();

            Assert.IsNull(result);
        }

        [Test]
        public void FindEnumerableReturnsExpectedTypeIfSequenceTypeIsEnumerable()
        {
            Type expected = typeof(IEnumerable<int>);

            Type sequenceType = typeof(int[]);

            Type result = sequenceType.FindEnumerable();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindEnumerableReturnsExpectedTypeIfSequenceIsList()
        {
            Type expected = typeof(IEnumerable<int>);

            Type sequenceType = typeof(List<int>);

            Type result = sequenceType.FindEnumerable();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindEnumerableReturnsExpectedTypeIfSequenceIsDictionary()
        {
            Type expected = typeof(IEnumerable<KeyValuePair<string,int>>);

            Type sequenceType = typeof(Dictionary<string, int>);

            Type result = sequenceType.FindEnumerable();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindEnumerableReturnsExpectedTypeIfSequenceIsIList()
        {
            Type expected = typeof(IEnumerable<string>);

            Type sequenceType = typeof(IList<string>);

            Type result = sequenceType.FindEnumerable();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindEnumerableReturnsExpectedTypeIfSequenceIsIDictionary()
        {
            Type expected = typeof(IEnumerable<KeyValuePair<string, int>>);

            Type sequenceType = typeof(IDictionary<string, int>);

            Type result = sequenceType.FindEnumerable();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindEnumerableReturnsExpectedTypeIfSequenceIsCustomEnumerable()
        {
            Type expected = typeof(IEnumerable<string>);

            Type sequenceType = typeof(MaxDHeap<string>);

            Type result = sequenceType.FindEnumerable();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetEnumerableElementTypeReturnsNullIfTypeIsNull()
        {
            Type sequenceType = null;

            Type result = sequenceType.GetEnumerableElementType();

            Assert.IsNull(result);
        }

        [Test]
        public void GetEnumerableElementTypeReturnsNullIfTypeIsString()
        {
            Type sequenceType = typeof(string);

            Type result = sequenceType.GetEnumerableElementType();

            Assert.IsNull(result);
        }

        [Test]
        public void GetEnumerableElementTypeReturnsNullForNonEnumerableType()
        {
            Type sequenceType = typeof(DateTime);

            Type result = sequenceType.GetEnumerableElementType();

            Assert.IsNull(result);
        }

        [Test]
        public void GetEnumerableElementTypeReturnsExpectedTypeIfSequenceTypeIsEnumerable()
        {
            Type expected = typeof(int);

            Type sequenceType = typeof(int[]);

            Type result = sequenceType.GetEnumerableElementType();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetEnumerableElementTypeReturnsExpectedTypeIfSequenceIsList()
        {
            Type expected = typeof(int);

            Type sequenceType = typeof(List<int>);

            Type result = sequenceType.GetEnumerableElementType();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetEnumerableElementTypeReturnsExpectedTypeIfSequenceIsDictionary()
        {
            Type expected = typeof(KeyValuePair<string, int>);

            Type sequenceType = typeof(Dictionary<string, int>);

            Type result = sequenceType.GetEnumerableElementType();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetEnumerableElementTypeReturnsExpectedTypeIfSequenceIsIList()
        {
            Type expected = typeof(string);

            Type sequenceType = typeof(IList<string>);

            Type result = sequenceType.GetEnumerableElementType();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetEnumerableElementTypeReturnsExpectedTypeIfSequenceIsIDictionary()
        {
            Type expected = typeof(KeyValuePair<string, int>);

            Type sequenceType = typeof(IDictionary<string, int>);

            Type result = sequenceType.GetEnumerableElementType();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetEnumerableElementTypeReturnsExpectedTypeIfSequenceIsCustomEnumerable()
        {
            Type expected = typeof(string);

            Type sequenceType = typeof(MaxDHeap<string>);

            Type result = sequenceType.GetEnumerableElementType();

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestClass(Id = 1)]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2292: Allow backing fields for unit-testing")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S1144: Allow setter for unit-testing")]
        public class Person
        {
            public string _name = null;
            public int _age = 0;

            [TestMember1(Id = 2)]
            [TestMember2(Id = 3)]
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            [TestMember1(Id = 4)]
            [TestMember2(Id = 5)]
            public int Age
            {
                get { return _age; }
                set { _age = value; }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S3459: Allow auto-property for unit-testing")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S1144: Allow auto-property for unit-testing")]
        private class TestClassAttribute : Attribute
        {
            public int Id { get; set; }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S3459: Allow auto-property for unit-testing")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S1144: Allow auto-property for unit-testing")]
        private abstract class TestMemberBaseAttribute : Attribute
        {
            public int Id { get; set; }
        }

        private class TestMember1Attribute : TestMemberBaseAttribute { }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S1144: Allow attribute type for unit-testing")]
        private class TestMember2Attribute : TestMemberBaseAttribute { }

        public class TestDerivedDerivedDerived : TestDerivedDerived { }

        public class TestDerivedDerived : TestDerived
        {
            public int PropertyC { get; set; }
        }

        public class TestDerived : TestBase
        {
            public int PropertyB { get; set; }
        }

        public abstract class TestBase
        {
            public int PropertyA { get; set; }
        }

        public interface ITestDerivedDervied : ITestDerived
        {
            int PropertyC { get; }
        }

        public interface ITestDerived : ITestBase
        {
            int PropertyB { get; }
        }

        public interface ITestBase
        {
            int PropertyA { get; }
        }
    }
}
