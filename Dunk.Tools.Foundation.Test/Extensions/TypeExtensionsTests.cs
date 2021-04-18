using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class TypeExtensionsTests
    {
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
            Assert.Throws<ArgumentNullException>(() => t.GetExtensionMethods(null));
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
