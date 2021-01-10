using Dunk.Tools.Foundation.Expressions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Expressions
{
    [TestFixture]
    public class InstanceCreationFactoryTests
    {
        [Test]
        public void InstanceCreationFactoryCreatesTypeWithNoParameters()
        {
            object o = InstanceCreationFactory.GetInstance(typeof(TestClass));

            TestClass result = o as TestClass;

            Assert.IsNotNull(result);
        }

        [Test]
        public void InstanceCreationFactoryCreatesTypeWithOneParameter()
        {
            object o = InstanceCreationFactory.GetInstance(typeof(TestClass), 1);

            TestClass result = o as TestClass;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.A);
        }

        [Test]
        public void InstanceCreationFactoryCreatesTypeWithTwoParameter()
        {
            object o = InstanceCreationFactory.GetInstance(typeof(TestClass), 1, 2);

            TestClass result = o as TestClass;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.A);
            Assert.AreEqual(2, result.B);
        }

        [Test]
        public void InstanceCreationFactoryCreatesTypeWithThreeParameter()
        {
            object o = InstanceCreationFactory.GetInstance(typeof(TestClass), 1, 2, 3);

            TestClass result = o as TestClass;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.A);
            Assert.AreEqual(2, result.B);
            Assert.AreEqual(3, result.C);
        }

        [Test]
        public void InstanceCreationFactoryCreatesTypeWithMultipleConstructorMethods()
        {
            InstanceCreationFactory.GetInstance(typeof(TestClass));
            InstanceCreationFactory.GetInstance(typeof(TestClass), 1);
            InstanceCreationFactory.GetInstance(typeof(TestClass), 1, 2);
            InstanceCreationFactory.GetInstance(typeof(TestClass), 1, 2, 3);


            var result1 = InstanceCreationFactory.GetInstance(typeof(TestClass)) as TestClass;
            var result2 = InstanceCreationFactory.GetInstance(typeof(TestClass), 1) as TestClass;
            var result3 = InstanceCreationFactory.GetInstance(typeof(TestClass), 1, 2) as TestClass;
            var result4 = InstanceCreationFactory.GetInstance(typeof(TestClass), 1, 2, 3) as TestClass;

            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.IsNotNull(result3);
            Assert.IsNotNull(result4);
        }

        private class TestClass
        {
            public TestClass()
            {
            }

            public TestClass(int a)
            {
                A = a;
            }

            public TestClass(int a, int b)
            {
                A = a;
                B = b;
            }

            public TestClass(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
            }

            public int A { get; private set; }
            public int B { get; private set; }
            public int C { get; private set; }
        }
    }
}
