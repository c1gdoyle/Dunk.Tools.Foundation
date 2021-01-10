using System;
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
    }
}
