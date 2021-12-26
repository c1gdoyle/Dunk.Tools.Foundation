using System;
using System.Linq.Expressions;
using Dunk.Tools.Foundation.Expressions;
using NUnit.Framework;

namespace Dunk.Tools.Foundation.Test.Expressions
{
    [TestFixture]
    public class EvaluatorTests
    {
        [Test]
        public void EvaluatorReturnsNewExpressionTree()
        {
            int localId = 2;

            Expression<Func<EvaluatorTestItem, bool>> testExpression = i => i.Id == localId;

            Expression newExpression = Evaluator.PartialEval(testExpression);

            Assert.IsNotNull(newExpression);
        }

        [Test]
        public void EvaluatorReturnsNewExpressionTreeWithEvaluatedAndReplacedSubTrees()
        {
            const string expectedExpression = "i => (i.Id == 2)";

            int localId = 2;

            Expression<Func<EvaluatorTestItem, bool>> testExpression = i => i.Id == localId;

            Expression newExpression = Evaluator.PartialEval(testExpression);

            Assert.AreEqual(expectedExpression, newExpression.ToString());
        }

        [Test]
        public void EvaluatorReturnsNewExpressionTreeWithLocalAndExpressionVariables()
        {
            int localId = 2;

            Expression<Func<EvaluatorTestItem, bool>> testExpression = i => i.Id == localId * 2;

            Expression newExpression = Evaluator.PartialEval(testExpression);

            Assert.IsNotNull(newExpression);
        }

        [Test]
        public void EvaluatorReturnsNewExpressionWithLocalAndExpressionVariablesEvaluatedAndReplaced()
        {
            const string expectedExpression = "i => (i.Id == 4)";

            int localId = 2;

            Expression<Func<EvaluatorTestItem, bool>> testExpression = i => i.Id == localId * 2;

            Expression newExpression = Evaluator.PartialEval(testExpression);

            Assert.AreEqual(expectedExpression, newExpression.ToString());
        }

        [Test]
        public void EvaluatorReturnsNewExpressionThatCompilesToWorkingFunction()
        {
            int localId = 2;

            Expression<Func<EvaluatorTestItem, bool>> testExpression = i => i.Id == localId * 2;

            var newFunction = (Evaluator.PartialEval(testExpression) as Expression<Func<EvaluatorTestItem, bool>>)
                .Compile();

            Assert.IsFalse(newFunction(new EvaluatorTestItem { Id = localId }));
            Assert.IsTrue(newFunction(new EvaluatorTestItem { Id = localId * 2 }));
        }

        private sealed class EvaluatorTestItem
        {
            public int Id { get; set; }
        }
    }
}
