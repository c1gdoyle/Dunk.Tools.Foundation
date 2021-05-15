using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides extension methods that support composing query predicates.
    /// </summary>
    public static class PredicateExtensions
    {
        /// <summary>
        /// Creates a predicate that evaluates to true.
        /// </summary>
        /// <typeparam name="T">The type of parameter of the predicate.</typeparam>
        /// <returns>
        /// A predicate that evaluates to true.
        /// </returns>
        public static Expression<Func<T, bool>> True<T>()
        {
            return param => true;
        }

        /// <summary>
        /// Creates a predicate that evaluates to false.
        /// </summary>
        /// <typeparam name="T">The type of parameter of the predicate.</typeparam>
        /// <returns>
        /// A predicate that evaluates to false.
        /// </returns>
        public static Expression<Func<T, bool>> False<T>()
        {
            return param => false;
        }

        /// <summary>
        /// Combines 2 specified expressions using the logical AND
        /// </summary>
        /// <typeparam name="T">The type of parameter of the expressions.</typeparam>
        /// <param name="first">The first expression.</param>
        /// <param name="second">The second expression.</param>
        /// <returns>
        /// The combined expression.
        /// </returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        /// <summary>
        /// Combines a sequence of expressions using the logical AND.
        /// </summary>
        /// <typeparam name="T">The type of parameter of the expressions.</typeparam>
        /// <param name="expressions">The sequence of expressions to combine.</param>
        /// <returns>
        /// The combined expression.
        /// </returns>
        public static Expression<Func<T, bool>> And<T>(this IEnumerable<Expression<Func<T, bool>>> expressions)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException(nameof(expressions),
                    $"Unable to compose And, {nameof(expressions)} parameter cannot be null");
            }
            if (!expressions.Any())
            {
                throw new ArgumentException($"Unable to compose And, {nameof(expressions)} parameter cannot be empty",
                    nameof(expressions));
            }
            var lambda = expressions.First();
            var body = lambda.Body;
            var parameter = lambda.Parameters[0];

            foreach (var expression in expressions.Skip(1))
            {
                var visitor = new ParameterRebinder(expression.Parameters[0], parameter);
                body = Expression.AndAlso(body, visitor.Visit(expression.Body));
            }

            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
            return lambda;
        }

        /// <summary>
        /// Combines 2 specified expressions using the logical OR
        /// </summary>
        /// <typeparam name="T">The type of parameter of the expressions.</typeparam>
        /// <param name="first">The first expression.</param>
        /// <param name="second">The second expression.</param>
        /// <returns>
        /// The combined expression.
        /// </returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.OrElse);
        }

        /// <summary>
        /// Combines a sequence of expressions using the logical OR.
        /// </summary>
        /// <typeparam name="T">The type of parameter of the expressions.</typeparam>
        /// <param name="expressions">The sequence of expressions to combine.</param>
        /// <returns>
        /// The combined expression.
        /// </returns>
        public static Expression<Func<T,bool>> Or<T>(this IEnumerable<Expression<Func<T,bool>>> expressions) 
        {
            if(expressions == null)
            {
                throw new ArgumentNullException(nameof(expressions), 
                    $"Unable to compose Or, {nameof(expressions)} parameter cannot be null");
            }
            if (!expressions.Any())
            {
                throw new ArgumentException($"Unable to compose Or, {nameof(expressions)} parameter cannot be empty",
                    nameof(expressions));
            }
            var lambda = expressions.First();
            var body = lambda.Body;
            var parameter = lambda.Parameters[0];

            foreach (var expression in expressions.Skip(1))
            {
                var visitor = new ParameterRebinder(expression.Parameters[0], parameter);
                body = Expression.OrElse(body, visitor.Visit(expression.Body));
            }

            lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
            return lambda;
        }

        /// <summary>
        /// Negatives a given predicate.
        /// </summary>
        /// <typeparam name="T">Thet type of parameter of the expression.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>
        /// The predicate that is the negated equivalent of the original.
        /// </returns>
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var negated = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
        }

        private static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            //zip parameters (map from parameters of second to parameters of first)
            var map = first.Parameters
                .Select((firstParam, i) => new { firstParam, secondParam = second.Parameters[i] })
                .ToDictionary(p => p.secondParam, p => p.firstParam);

            //replace parameters in the second lambda expression with the parameters in the first
            var secondBody = new ParameterRebinder(map).ReplaceParameters(second.Body);

            //create a merged lambda expression with parameters from the first expression.
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        internal class ParameterRebinder : ExpressionVisitor
        {
            private readonly Dictionary<ParameterExpression, ParameterExpression> _paramMap;

            public ParameterRebinder(ParameterExpression first, ParameterExpression second)
            {
                _paramMap = new Dictionary<ParameterExpression, ParameterExpression>();
                _paramMap.Add(first, second);
            }

            public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> paramMap)
            {
                _paramMap = paramMap;
            }

            public Expression ReplaceParameters(Expression exp)
            {
                return Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                ParameterExpression replacement;

                if (_paramMap.TryGetValue(node, out replacement))
                {
                    node = replacement;
                }
                return base.VisitParameter(node);
            }
        }
    }
}
