using System;
using System.Linq;
using System.Linq.Expressions;
using Dunk.Tools.Foundation.Extensions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Extensions
{
    [TestFixture]
    public class PredicateExtensionsTests
    {
        private readonly int[] _testArray = { 1, 2, 3, 4, 5 };
        private readonly Customer[] _customers = { new Customer { Name = "Tom", Age = 25 }, new Customer { Name = "Lucy", Age = 31 }, new Customer { Name = "Luke", Age = 32 } };

        [Test]
        public void PredicateExtensionBuildsAndExpression()
        {
            const string expected = "i => ((i > 0) AndAlso (i < 5))";

            Expression<Func<int, bool>> exp1 = i => i > 0;
            Expression<Func<int, bool>> exp2 = i => i < 5;

            Expression<Func<int, bool>> andExp = exp1.And(exp2);
            var results = _testArray.Where(andExp.Compile());

            Assert.AreEqual(4, results.Count());
            Assert.AreEqual(expected, andExp.ToString());
        }

        [Test]
        public void PredicateExtensionBuildsOrExpression()
        {
            const string expected = "i => ((i > 0) OrElse (i < 5))";

            Expression<Func<int, bool>> exp1 = i => i > 0;
            Expression<Func<int, bool>> exp2 = i => i < 5;

            Expression<Func<int, bool>> orExp = exp1.Or(exp2);
            var results = _testArray.Where(orExp.Compile());

            Assert.AreEqual(5, results.Count());
            Assert.AreEqual(expected, orExp.ToString());
        }

        [Test]
        public void PredicateExtensionBuildsOrExpressionWithTrue()
        {
            const string expected = "i => ((i > 5) OrElse True)";

            Expression<Func<int, bool>> exp1 = i => i > 5;
            Expression<Func<int, bool>> trueExp = PredicateExtensions.True<int>();

            Expression<Func<int, bool>> orExp = exp1.Or(trueExp);
            var results = _testArray.Where(orExp.Compile());

            Assert.AreEqual(5, results.Count());
            Assert.AreEqual(expected, orExp.ToString());
        }

        [Test]
        public void PredicateExtensionBuildsOrExpressionWithFalse()
        {
            const string expected = "i => ((i > 0) OrElse False)";

            Expression<Func<int, bool>> exp1 = i => i > 0;
            Expression<Func<int, bool>> falseExp = PredicateExtensions.False<int>();

            Expression<Func<int, bool>> orExp = exp1.Or(falseExp);
            var results = _testArray.Where(orExp.Compile());

            Assert.AreEqual(5, results.Count());
            Assert.AreEqual(expected, orExp.ToString());
        }

        [Test]
        public void PredicateExtensionBuildsNotExpression()
        {
            const string expected = "i => Not((i == 2))";
            Expression<Func<int, bool>> exp1 = i => i == 2;

            Expression<Func<int, bool>> notExp = exp1.Not();
            var results = _testArray.Where(notExp.Compile());

            Assert.AreEqual(4, results.Count());
            Assert.AreEqual(expected, notExp.ToString());
        }

        [Test]
        public void PredicateExtensionBuildsAndOrExpression()
        {
            const string expected = "c => (((c.Name == \"Tom\") AndAlso (c.Age > 30)) OrElse ((c.Name == \"Lucy\") AndAlso (c.Age > 30)))";

            Expression<Func<Customer, bool>> exp1 = c => c.Name == "Tom";
            Expression<Func<Customer, bool>> exp2 = c => c.Name == "Lucy";
            Expression<Func<Customer, bool>> exp3 = c => c.Age > 30;

            Expression<Func<Customer, bool>> composedExp = exp1.And(exp3).Or(exp2.And(exp3));
            var results = _customers.Where(composedExp.Compile());

            Assert.AreEqual(1, results.Count());
            Assert.AreEqual(expected, composedExp.ToString());
        }

        private class Customer
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}
