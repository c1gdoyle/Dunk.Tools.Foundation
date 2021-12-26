using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for a <see cref="Expression{TDelegate}"/>
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Gets a <see cref="MethodInfo"/> instance using a specified lambda expression.
        /// </summary>
        /// <param name="methodSelector">The lambda expression for identifying the method.</param>
        /// <returns>
        /// A <see cref="MethodInfo"/> instance for the identified method.
        /// </returns>
        public static MethodInfo GetMethodInfo(this Expression<Action> methodSelector)
        {
            return GetMethodInfo((LambdaExpression)methodSelector);
        }

        /// <summary>
        /// Gets a <see cref="MethodInfo"/> instance using a specified lambda expression.
        /// </summary>
        /// <typeparam name="T">The type of object declaring the method we are interested in.</typeparam>
        /// <param name="methodSelector">The lambda expression for identifying the method.</param>
        /// <returns>
        /// A <see cref="MethodInfo"/> instance for the identified method.
        /// </returns>
        public static MethodInfo GetMethodInfo<T>(this Expression<Action<T>> methodSelector)
        {
            return GetMethodInfo((LambdaExpression)methodSelector);
        }

        /// <summary>
        /// Gets a <see cref="MethodInfo"/> instance using a specified lambda expression.
        /// </summary>
        /// <typeparam name="T">The type of object declaring the method we are interested in.</typeparam>
        /// <typeparam name="TResult">The return type of the method we are interested in.</typeparam>
        /// <param name="methodSelector">The lambda expression for identifying the method.</param>
        /// <returns>
        /// A <see cref="MethodInfo"/> instance for the identified method.
        /// </returns>
        public static MethodInfo GetMethodInfo<T, TResult>(this Expression<Func<T, TResult>> methodSelector)
        {
            return GetMethodInfo((LambdaExpression)methodSelector);
        }

        /// <summary>
        /// Gets a <see cref="MemberInfo"/> instance using a specified lambda expression.
        /// </summary>
        /// <typeparam name="T">The type of object declaring the member we are interested in.</typeparam>
        /// <typeparam name="TResult">The return type of the member we are interested in.</typeparam>
        /// <param name="memberSelector">The lambda expression for identifying the member.</param>
        /// <returns>
        /// A <see cref="MethodInfo"/> instance for the identified member.
        /// </returns>
        public static MemberInfo GetMemberInfo<T, TResult>(this Expression<Func<T, TResult>> memberSelector)
        {
            return GetMemberInfo((LambdaExpression)memberSelector);
        }

        /// <summary>
        /// Gets a <see cref="FieldInfo"/> instance using a specified lambda expression.
        /// </summary>
        /// <typeparam name="T">The type of object declaring the field we are interested in.</typeparam>
        /// <typeparam name="TResult">The return type of the field we are interested in.</typeparam>
        /// <param name="fieldSelector">The lambda expression for identifying the field.</param>
        /// <returns>
        /// A <see cref="FieldInfo"/> instance for the identified field.
        /// </returns>
        public static FieldInfo GetFieldInfo<T, TResult>(this Expression<Func<T, TResult>> fieldSelector)
        {
            return GetFieldInfo((LambdaExpression)fieldSelector);
        }

        /// <summary>
        /// Gets a <see cref="PropertyInfo"/> instance using a specified lambda expression.
        /// </summary>
        /// <typeparam name="T">The type of object declaring the property we are interested in.</typeparam>
        /// <typeparam name="TResult">The return type of the property we are interested in.</typeparam>
        /// <param name="propertySelector">The lambda expression for identifying the property.</param>
        /// <returns>
        /// A <see cref="PropertyInfo"/> instance for the identified property.
        /// </returns>
        public static PropertyInfo GetPropertyInfo<T, TResult>(this Expression<Func<T, TResult>> propertySelector)
        {
            return GetPropertyInfo((LambdaExpression)propertySelector);
        }

        /// <summary>
        /// Gets the name of a specified type member using a specified lambda expression.
        /// </summary>
        /// <typeparam name="T">The type of object declaring the member we are interested in.</typeparam>
        /// <typeparam name="TResult">The return type of the member we are interested in.</typeparam>
        /// <param name="memberSelector">The lambda expression for identifying the member.</param>
        /// <returns>
        /// The name of the identified member.
        /// </returns>
        public static string GetMemberName<T, TResult>(this Expression<Func<T, TResult>> memberSelector)
        {
            return GetMemberName((LambdaExpression)memberSelector);
        }

        /// <summary>
        /// Gets the name of a specified type member using a specified lambda expression.
        /// </summary>
        /// <typeparam name="T">The type of object declaring the member we are interested in.</typeparam>
        /// <param name="memberSelector">The lambda expression for identifying the member.</param>
        /// <returns>
        /// The name of the identified member.
        /// </returns>
        public static string GetMemberName<T>(this Expression<Action<T>> memberSelector)
        {
            return GetMemberName((LambdaExpression)memberSelector);
        }

        /// <summary>
        /// Produces an expression identical to <paramref name="expression"/> except
        /// with 'source' parameter replaced with 'target' parameter.
        /// </summary>
        /// <typeparam name="TInput">The Param type of the input expression.</typeparam>
        /// <typeparam name="TOutput">The Param type of the output expression.</typeparam>
        /// <param name="expression">The original expression.</param>
        /// <param name="source">The Param type to be replaced.</param>
        /// <param name="target">The Param type to use to replace.</param>
        /// <returns>
        /// An expression identical to <paramref name="expression"/> except
        /// with 'source' parameter replaced with 'target' parameter.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="expression"/>, <paramref name="source"/> or <paramref name="target"/> was null.</exception>
        public static Expression<TOutput> Replace<TInput, TOutput>(this Expression<TInput> expression, ParameterExpression source, ParameterExpression target)
        {
            expression.ThrowIfNull(nameof(expression),
                $"Unable to Replace expression, {nameof(expression)} parameter cannot be null");
            source.ThrowIfNull(nameof(source),
                $"Unable to Replace expression, {nameof(source)} parameter cannot be null");
            target.ThrowIfNull(nameof(target),
                $"Unable to Replace expression, {nameof(target)} parameter cannot be null");

            return new ParameterReplaceVisitor<TOutput>(source, target)
                .VisitAndConvert(expression);
        }

        private static MethodInfo GetMethodInfo(LambdaExpression methodSelector)
        {
            methodSelector.ThrowIfNull(nameof(methodSelector));

            MethodCallExpression methodExpression = methodSelector.Body as MethodCallExpression;
            if (methodExpression == null)
            {
                throw new ArgumentException(
                    "Unable to get MethodInfo. Invalid Expression, expression should consist of a Method call only",
                    nameof(methodSelector));
            }
            return methodExpression.Method;
        }

        private static MemberInfo GetMemberInfo(LambdaExpression memberSelector)
        {
            memberSelector.ThrowIfNull(nameof(memberSelector));

            MemberExpression memberExpression = null;

            var body = memberSelector.Body;

            if (body is MemberExpression)
            {
                memberExpression = body as MemberExpression;
            }
            else if (body is UnaryExpression)
            {
                var unaryExpression = body as UnaryExpression;
                if (unaryExpression.NodeType != ExpressionType.Convert &&
                    unaryExpression.NodeType != ExpressionType.ConvertChecked)
                {
                    throw new ArgumentException("A non-convert Unary Expression was found.", nameof(memberSelector));
                }
                memberExpression = unaryExpression.Operand as MemberExpression;
            }

            if (memberExpression == null)
            {
                throw new ArgumentException(
                    "Unable identify Expression as a single member.",
                    nameof(memberSelector));
            }
            return memberExpression.Member;
        }

        private static FieldInfo GetFieldInfo(LambdaExpression fieldSelector)
        {
            var member = GetMemberInfo(fieldSelector);
            if (member is FieldInfo)
            {
                return member as FieldInfo;
            }

            throw new ArgumentException(
                $"The specified member is not a field. Actual member type is {member.GetType()}",
                nameof(fieldSelector));
        }

        private static PropertyInfo GetPropertyInfo(LambdaExpression fieldSelector)
        {
            var member = GetMemberInfo(fieldSelector);
            if (member is PropertyInfo)
            {
                return member as PropertyInfo;
            }

            throw new ArgumentException(
                $"The specified member is not a property. Actual member type is {member.GetType()}",
                nameof(fieldSelector));
        }

        private static string GetMemberName(LambdaExpression memberSelector)
        {
            memberSelector.ThrowIfNull(nameof(memberSelector));

            Expression expression = memberSelector.Body;

            MemberExpression memberExpression = expression as MemberExpression;
            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }

            MethodCallExpression methodExpression = expression as MethodCallExpression;
            if (methodExpression != null)
            {
                return methodExpression.Method.Name;
            }
            if (expression is UnaryExpression)
            {
                var unaryExpression = expression as UnaryExpression;
                return GetMemberName(unaryExpression);
            }
            throw new ArgumentException(
                $"Invalid expression cannot determine member name for expression body {expression.NodeType}",
                nameof(memberSelector));
        }

        private static string GetMemberName(UnaryExpression unaryExpression)
        {
            MethodCallExpression methodCallExpression = unaryExpression.Operand as MethodCallExpression;
            if (methodCallExpression != null)
            {
                return methodCallExpression.Method.Name;
            }
            return ((MemberExpression)unaryExpression.Operand)
                .Member.Name;
        }

        /// <summary>
        /// An <see cref="ExpressionVisitor"/> implementation that replaces
        /// a Parameter expression.
        /// i.e.
        /// Expression{Func{FromType}} to Expression{Func{ToType}} 
        /// </summary>
        /// <typeparam name="TOutput">The type of output expression.</typeparam>
        /// <remarks>
        /// See Ani's post at http://stackoverflow.com/questions/7051003/convert-expressionfuncfromtype-to-expressionfunctotype/7051104#7051104
        /// </remarks>
        private sealed class ParameterReplaceVisitor<TOutput> : ExpressionVisitor
        {
            private readonly ParameterExpression _source;
            private readonly ParameterExpression _target;

            public ParameterReplaceVisitor(ParameterExpression source, ParameterExpression target)
            {
                _source = source;
                _target = target;
            }

            internal Expression<TOutput> VisitAndConvert<T>(Expression<T> root)
            {
                return (Expression<TOutput>)VisitLambda(root);
            }

            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                //leave all parameters alone except the one we want to replace.
                var parameters = node.Parameters.Select(p => p == _source ? _target : p);

                return Expression.Lambda<TOutput>(Visit(node.Body), parameters);
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                //Replace the source with the target, visit other params as usual
                if (node == _source)
                {
                    return _target;
                }
                return base.VisitParameter(node);
            }
        }
    }
}
