using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class ExpressionExtensionsTests
    {
        [Test]
        public void GetMemberInfoReturnsMember()
        {
            Expression<Func<Person, string>> lambda = p => p.Name;

            MemberInfo member = lambda.GetMemberInfo<Person, string>();

            Assert.IsNotNull(member);
            Assert.AreEqual("Name", member.Name);
        }

        [Test]
        public void GetFieldInfoReturnsField()
        {
            Expression<Func<Person, string>> lambda = p => p._name;

            MemberInfo member = lambda.GetFieldInfo<Person, string>();

            Assert.IsNotNull(member);
            Assert.AreEqual("_name", member.Name);
        }

        [Test]
        public void GetPropertyInfoReturnsProperty()
        {
            Expression<Func<Person, string>> lambda = p => p.Name;

            MemberInfo member = lambda.GetPropertyInfo<Person, string>();

            Assert.IsNotNull(member);
            Assert.AreEqual("Name", member.Name);
        }

        [Test]
        public void GetFieldInfoReturnsFieldForConversionExpression()
        {
            Expression<Func<Person, double>> lambda = p => (double)p._age;

            MemberInfo member = lambda.GetFieldInfo<Person, double>();

            Assert.IsNotNull(member);
            Assert.AreEqual("_age", member.Name);
        }

        [Test]
        public void GetPropertyInfoReturnsFieldForConversionExpression()
        {
            Expression<Func<Person, double>> lambda = p => (double)p.Age;

            MemberInfo member = lambda.GetPropertyInfo<Person, double>();

            Assert.IsNotNull(member);
            Assert.AreEqual("Age", member.Name);
        }

        [Test]
        public void GetMemberInfoThrowsIfExpressionIsNotMemberOrUnary()
        {
            Expression<Func<Person, int>> lambda = p => 2;

            Assert.Throws<ArgumentException>(() => lambda.GetMethodInfo());
        }

        [Test]
        public void GetMemberInfoThrowsIfUnaryExpressionIsNotTypeOfConversion()
        {
            ParameterExpression param = Expression.Parameter(typeof(Person));
            Expression<Func<Person, int>> lambda = Expression.Lambda<Func<Person, int>>(
                Expression.Decrement(
                    Expression.MakeMemberAccess(param, typeof(Person).GetMember("Age").First())),
                param);
            Assert.Throws<ArgumentException>(() => lambda.GetMemberInfo());
        }

        [Test]
        public void GetFieldInfoThrowsIfMemberIsNotField()
        {
            Expression<Func<Person, string>> lambda = p => p.Name;

            Assert.Throws<ArgumentException>(() => lambda.GetFieldInfo());
        }

        [Test]
        public void GetPropertyInfoThrowsIfMemberIsNotProperty()
        {
            Expression<Func<Person, string>> lambda = p => p._name;

            Assert.Throws<ArgumentException>(() => lambda.GetPropertyInfo());
        }

        [Test]
        public void GetMethodReturnsMethodInfo()
        {
            Expression<Func<Person, string>> lambda = p => p.GetMethod();

            MethodInfo method = lambda.GetMethodInfo<Person, string>();

            Assert.IsNotNull(method);
            Assert.AreEqual("GetMethod", method.Name);
        }

        [Test]
        public void GetMethodReturnsMethodInfoForGenericMethod()
        {
            Expression<Action<Person>> lambda = p => p.GenericMethod<float>(default(float));

            MethodInfo method = lambda.GetMethodInfo<Person>();

            Assert.IsNotNull(method);
            Assert.AreEqual("GenericMethod", method.Name);
            Assert.AreEqual(typeof(float), method.GetParameters().First().ParameterType);
        }

        [Test]
        public void GetMethodReturnsMethodInfoForStaticMethod()
        {
            Expression<Action> lambda = () => Person.StaticMethod();

            MethodInfo method = lambda.GetMethodInfo();

            Assert.IsNotNull(method);
            Assert.IsTrue(method.IsStatic);
        }

        [Test]
        public void GetMethodThrowsIfBodyIsNotMethod()
        {
            Expression<Func<Person, string>> lambda = p => p.Name;

            Assert.Throws<ArgumentException>(() => lambda.GetMethodInfo());
        }


        [Test]
        public void GetMemberNameReturnsNameForValueTypeProperty()
        {
            string propertyName = ExpressionExtensions.GetMemberName<DateTime, int>(x => x.Hour);
            Assert.AreEqual("Hour", propertyName);
        }

        [Test]
        public void GetMemberNameReturnsNameForReferenceTypeProperty()
        {
            string propertyName = ExpressionExtensions.GetMemberName<Exception, IDictionary>(x => x.Data);
            Assert.AreEqual("Data", propertyName);
        }

        [Test]
        public void GetMemberNameReturnsNameOfValueTypeMethod()
        {
            string methodName = ExpressionExtensions.GetMemberName<DateTime, int>(x => x.GetHashCode());

            Assert.AreEqual("GetHashCode", methodName);
        }

        [Test]
        public void GetMemberNameReturnsNameOfReferenceTypeMethod()
        {
            string methodName = ExpressionExtensions.GetMemberName<string, object>(x => x.Clone());

            Assert.AreEqual("Clone", methodName);
        }

        [Test]
        public void GetMemberNameReturnsNameOfVoidMethod()
        {
            string methodName = ExpressionExtensions.GetMemberName<List<string>>(x => x.Reverse());

            Assert.AreEqual("Reverse", methodName);
        }

        [Test]
        public void GetMemberNameReturnsNameOfMethodWithParameters()
        {
            string methodName = ExpressionExtensions.GetMemberName<string, int>(x => x.LastIndexOf(','));

            Assert.AreEqual("LastIndexOf", methodName);
        }

        [Test]
        public void GetMemberNameReturnPropertyNameForConversion()
        {
            string memberName = ExpressionExtensions.GetMemberName<Person, double>(x => (double)x.Age);

            Assert.AreEqual("Age", memberName);
        }

        [Test]
        public void GetMemberNameReturnsMethodNameForConversion()
        {
            string memberName = ExpressionExtensions.GetMemberName<DateTime, double>(x => (double)x.GetHashCode());

            Assert.AreEqual("GetHashCode", memberName);
        }

        [Test]
        public void GetMemberNameThrowsIfExpressionIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => ExpressionExtensions.GetMemberName<string>(null as Expression<Action<string>>));
        }

        [Test]
        public void GetMemberNameThrowsIfExpressionBodyIsNotRecognised()
        {
            Assert.Throws<ArgumentException>(() => ExpressionExtensions.GetMemberName<Person, int>(p => 2));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2292: Allow backing fields for unit-testing")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S1144: Allow setter for unit-testing")]
        private class Person
        {
            public string _name = null;
            public int _age = 0;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public int Age
            {
                get { return _age; }
                set { _age = value; }
            }

            public string GetMethod()
            {
                return _name;
            }

            public void GenericMethod<T>(T param)
            {
                //do nothing
            }

            public static void StaticMethod()
            {
                //do nothing
            }
        }
    }
}
