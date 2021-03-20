using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Dunk.Tools.Foundation.Expressions
{
    /// <summary>
    /// Provides static helper methods for creating an instance of a specified type.
    /// </summary>
    public static class InstanceCreationFactory
    {
        /// <summary>
        /// Creates an instance of the specified <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The type to create.</param>
        /// <returns>
        /// An instance of the <paramref name="type"/>
        /// </returns>
        public static object GetInstance(Type type)
        {
            return GetInstance<TypeToIgnore>(type, null);
        }

        /// <summary>
        /// Creates an instance of the specified <see cref="Type"/> using the supplied arguments
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument.</typeparam>
        /// <param name="type">The type to create.</param>
        /// <param name="argument1">The first argument.</param>
        /// <returns>
        /// An instance of the <paramref name="type"/>
        /// </returns>
        public static object GetInstance<TArg1>(Type type, TArg1 argument1)
        {
            return GetInstance<TArg1, TypeToIgnore>(type, argument1, null);
        }

        /// <summary>
        /// Creates an instance of the specified <see cref="Type"/> using the supplied arguments
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument.</typeparam>
        /// <param name="type">The type to create.</param>
        /// <param name="argument1">The first argument.</param>
        /// <param name="argument2">The second argument.</param>
        /// <returns>
        /// An instance of the <paramref name="type"/>
        /// </returns>
        public static object GetInstance<TArg1, TArg2>(Type type, TArg1 argument1, TArg2 argument2)
        {
            return GetInstance<TArg1, TArg2, TypeToIgnore>(type, argument1, argument2, null);
        }

        /// <summary>
        /// Creates an instance of the specified <see cref="Type"/> using the supplied arguments
        /// </summary>
        /// <typeparam name="TArg1">The type of the first argument.</typeparam>
        /// <typeparam name="TArg2">The type of the second argument.</typeparam>
        /// <typeparam name="TArg3">The type of the third argument.</typeparam>
        /// <param name="type">The type to create.</param>
        /// <param name="argument1">The first argument.</param>
        /// <param name="argument2">The second argument.</param>
        /// <param name="argument3">The third argument.</param>
        /// <returns>
        /// An instance of the <paramref name="type"/>
        /// </returns>
        public static object GetInstance<TArg1, TArg2, TArg3>(Type type, TArg1 argument1, TArg2 argument2, TArg3 argument3)
        {
            return InstanceCreationFactoryCache<TArg1, TArg2, TArg3>
                .CreateInstanceOf(type, argument1, argument2, argument3);
        }

        private class TypeToIgnore { }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S2436: Support multiple generic parameters for functional programming.")]
        private static class InstanceCreationFactoryCache<TArg1, TArg2, TArg3>
        {
            private static readonly Dictionary<Type, Dictionary<int, Func<TArg1, TArg2, TArg3, object>>> InstanceCreationMethodsByType =
                new Dictionary<Type, Dictionary<int, Func<TArg1, TArg2, TArg3, object>>>();

            public static object CreateInstanceOf(Type type, TArg1 arg1, TArg2 arg2, TArg3 arg3)
            {
                //Get constructor argument Types; ignore any of TypeToIgnore type
                Type[] constructorArgTypes = new Type[] { typeof(TArg1), typeof(TArg2), typeof(TArg3) }
                .Where(t => t != typeof(TypeToIgnore))
                .ToArray();

                CacheInstanceCreationMethod(type, constructorArgTypes);
                return InstanceCreationMethodsByType[type][constructorArgTypes.Length]
                    .Invoke(arg1, arg2, arg3);
            }

            private static void CacheInstanceCreationMethod(Type type, Type[] constructorArgTypes)
            {
                //check if we have already cached the instance creation method
                Dictionary<int, Func<TArg1, TArg2, TArg3, object>> methods;
                if (InstanceCreationMethodsByType.TryGetValue(type, out methods) &&  // do we have creation method for this type
                    methods.ContainsKey(constructorArgTypes.Length))                // do we have creation method for the number of parameters
                {
                    return;
                }

                //Get constructor which matches the argument Types
                var constructor = type.GetConstructor(
                    BindingFlags.Instance | BindingFlags.Public,
                    null,
                    CallingConventions.HasThis,
                    constructorArgTypes,
                    new ParameterModifier[0]);

                //Get a set of Expressions representing the parameters to be passed to the Func
                var parameterExpressions = new[]
                {
                    Expression.Parameter(typeof(TArg1), "arg1"),
                    Expression.Parameter(typeof(TArg2), "arg2"),
                    Expression.Parameter(typeof(TArg3), "arg3")
                };

                //Get a set of Expressions representing the parameters to be passed to the constructor
                var constructorParameterExpressions = parameterExpressions.
                    Take(constructorArgTypes.Length)
                    .ToArray();

                //Get an Expressino representing the constructor call
                var constructorCall = Expression.New(constructor, constructorParameterExpressions);

                //Complie the Expression into a Func which takes 3 arguments and returns the created object
                var creator = Expression
                    .Lambda<Func<TArg1, TArg2, TArg3, object>>(constructorCall, parameterExpressions)
                    .Compile();

                if (!InstanceCreationMethodsByType.ContainsKey(type))
                {
                    InstanceCreationMethodsByType[type] = new Dictionary<int, Func<TArg1, TArg2, TArg3, object>>();
                }
                InstanceCreationMethodsByType[type][constructorArgTypes.Length] = creator;
            }
        }
    }
}
