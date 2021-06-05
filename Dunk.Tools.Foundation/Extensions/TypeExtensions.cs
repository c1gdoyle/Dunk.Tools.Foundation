using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Dunk.Tools.Foundation.Extensions
{
    /// <summary>
    /// Provides a series of extension methods for a <see cref="Type"/> instance.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Gets a specified attribute from the type.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to get.</typeparam>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An instance of <typeparamref name="TAttribute"/> if it was found on the type; otherwise null.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> was null.</exception>
        public static TAttribute GetAttribute<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
            return GetAttributes<TAttribute>(type)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets a specified attribute from the member.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to get.</typeparam>
        /// <param name="member">The member.</param>
        /// <returns>
        /// An instance of <typeparamref name="TAttribute"/> if it was found on the member; otherwise null.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="member"/> was null.</exception>
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo member)
            where TAttribute : Attribute
        {
            return GetAttributes<TAttribute>(member)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets a collection of specified attributes from the type.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to get.</typeparam>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An array of <typeparamref name="TAttribute"/> if any were found on the type; otherwise an empty array.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> was null.</exception>
        public static TAttribute[] GetAttributes<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
            type.ThrowIfNull(nameof(type),
                $"Unable to get Attributes from type, {nameof(type)} parameter cannot be null");

            Attribute[] attributes = Attribute.GetCustomAttributes(type, typeof(TAttribute), false);

            return attributes as TAttribute[];
        }

        /// <summary>
        /// Gets a collection of specified attributes from the member.
        /// </summary>
        /// <typeparam name="TAttribute">The member of attribute to get.</typeparam>
        /// <param name="member">The member.</param>
        /// <returns>
        /// An array of <typeparamref name="TAttribute"/> if any were found on the member; otherwise an empty array.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="member"/> was null.</exception>
        public static TAttribute[] GetAttributes<TAttribute>(this MemberInfo member)
            where TAttribute : Attribute
        {
            member.ThrowIfNull(nameof(member), 
                $"Unable to get Attributes from member, {nameof(member)} parameter cannot be null");

            Attribute[] attributes = Attribute.GetCustomAttributes(member, typeof(TAttribute), false);

            return attributes as TAttribute[];
        }

        /// <summary>
        /// Gets public extension methods for this type.
        /// </summary>
        /// <param name="extendedType">The type whose extension methods we are looking for.</param>
        /// <returns>
        /// A collection of <see cref="MethodInfo"/>'s representing the extension methods of this type.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="extendedType"/> was null.</exception>
        public static IEnumerable<MethodInfo> GetExtensionMethods(this Type extendedType)
        {
            extendedType.ThrowIfNull(nameof(extendedType),
                $"Unable to get Extension methods, {nameof(extendedType)} parameter cannot be null.");

            List<Type> types = new List<Type>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                types.AddRange(assembly.GetTypes());
            }
            return types
                .Where(t => t.IsSealed && !t.IsGenericType && !t.IsNested)
                .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public))
                .Where(m => m.IsDefined(typeof(ExtensionAttribute), false) &&
                m.GetParameters()[0].ParameterType == extendedType);
        }

        /// <summary>
        /// Gets public extension methods for this type in a specified assembly.
        /// </summary>
        /// <param name="extendedType">The type whose extension methods we are looking for.</param>
        /// <param name="assembly"> The assembly which we are looking for the extension methods in.</param>
        /// <returns>
        /// A collection of <see cref="MethodInfo"/>'s representing the extension methods of this type.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="extendedType"/> or <paramref name="assembly"/> was null.</exception>
        public static IEnumerable<MethodInfo> GetExtensionMethods(this Type extendedType, Assembly assembly)
        {
            extendedType.ThrowIfNull(nameof(extendedType),
                $"Unable to get Extension methods, {nameof(extendedType)} parameter cannot be null.");
            assembly.ThrowIfNull(nameof(assembly),
                $"Unable to get Extension methods, {nameof(assembly)} parameter cannot be null.");

            return assembly.GetTypes()
                .Where(t => t.IsSealed && !t.IsGenericType && !t.IsNested)
                .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public))
                .Where(m => m.IsDefined(typeof(ExtensionAttribute), false) &&
                m.GetParameters()[0].ParameterType == extendedType);
        }

        /// <summary>
        /// Gets a sequence of base types implemented by a specified type including 
        /// the type itself.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// A sequence containing the base types.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> was null.</exception>
        public static IEnumerable<Type> GetBaseTypes(this Type type)
        {
            return GetBaseTypes(type, true);
        }

        /// <summary>
        /// Gets a sequence of base types implemented by a specified type with a flag
        /// indicating whether the type itself should be included.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="includeSelf">A flag indicating whether the type itself should be included.</param>
        /// <returns>
        /// A sequence containing the base types.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> was null.</exception>
        public static IEnumerable<Type> GetBaseTypes(this Type type, bool includeSelf)
        {
            type.ThrowIfNull(nameof(type),
                $"Unable to get Base-Types, {nameof(type)} cannot be null");

            if (includeSelf)
            {
                yield return type;
            }
            Type localType = type.BaseType;
            while (localType != null)
            {
                yield return localType;
                localType = localType.BaseType;
            }
        }


        /// <summary>
        /// Gets a sequence of base types implemented by a specified type (excluding object) including 
        /// the type itself.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// A sequence containing the base types.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> was null.</exception>
        public static IEnumerable<Type> GetBaseTypesExcludingObject(this Type type)
        {
            return GetBaseTypesExcludingObject(type, true);
        }

        /// <summary>
        /// Gets a sequence of base types implemented by a specified type (excluding object) with a flag
        /// indicating whether the type itself should be included.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="includeSelf">A flag indicating whether the type itself should be included.</param>
        /// <returns>
        /// A sequence containing the base types.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> was null.</exception>
        public static IEnumerable<Type> GetBaseTypesExcludingObject(this Type type, bool includeSelf)
        {
            type.ThrowIfNull(nameof(type),
                $"Unable to get Base-Types, {nameof(type)} cannot be null");

            if (includeSelf &&
                type != typeof(object))
            {
                yield return type;
            }
            Type localType = type.BaseType;
            while (localType != null &&
                localType != typeof(object))
            {
                yield return localType;
                localType = localType.BaseType;
            }
        }

        /// <summary>
        /// Gets all instance properties of a type in a flat hierarchy.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An array of properties from the given type.
        /// </returns>
        /// <remarks>
        /// Note if the type is a non-interface the flat hierarchy will be ordered from derived class properties to base class properties,
        /// whilst if the type is an interface that flat hierarchy will be ordered from base class properties to derived class properties.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> was null.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S3011:Method is intended to expose all properties.")]
        public static PropertyInfo[] GetAllProperties(this Type type)
        {
            type.ThrowIfNull(nameof(type),
                   $"Unable to get Properties, {nameof(type)} cannot be null");

            return GetProperties(type, BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.NonPublic
                        | BindingFlags.Instance);
        }

        /// <summary>
        /// Gets all public instance properties of a type in a flat hierarchy.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An array of properties from the given type.
        /// </returns>
        /// <remarks>
        /// Note if the type is a non-interface the flat hierarchy will be ordered from derived class propertoes to base class properties,
        /// whilst if the type is an interface that flat hierarchy will be ordered from base class properties to derived class properties.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> was null.</exception>
        public static PropertyInfo[] GetAllPublicProperties(this Type type)
        {
            type.ThrowIfNull(nameof(type),
                   $"Unable to get Properties, {nameof(type)} cannot be null");

            return GetProperties(type, BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.Instance);
        }

        /// <summary>
        /// Gets all instance methods of a type in a flat hierarchy.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An array of methods from the given type.
        /// </returns>
        /// <remarks>
        /// Note if the type is a non-interface the flat hierarchy will be ordered from derived class methods to base class methods,
        /// whilst if the type is an interface that flat hierarchy will be ordered from base class methods to derived class methods.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> was null.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("csharpsquid", "S3011:Method is intended to expose all methods.")]
        public static MethodInfo[] GetAllMethods(this Type type)
        {
            type.ThrowIfNull(nameof(type),
                   $"Unable to get Methods, {nameof(type)} cannot be null");

            return GetMethods(type, BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.NonPublic
                        | BindingFlags.Instance);
        }

        /// <summary>
        /// Gets all instance methods of a type in a flat hierarchy excluding the <see cref="object"/> methods.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An array of methods from the given type.
        /// </returns>
        /// <remarks>
        /// Note if the type is a non-interface the flat hierarchy will be ordered from derived class methods to base class methods,
        /// whilst if the type is an interface that flat hierarchy will be ordered from base class methods to derived class methods.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> was null.</exception>
        public static MethodInfo[] GetAllMethodsExcludingObjectBase(this Type type)
        {
            type.ThrowIfNull(nameof(type),
                   $"Unable to get Methods, {nameof(type)} cannot be null");

            return GetAllMethods(type)
                .Where(m => m.DeclaringType != typeof(object))
                .ToArray();
        }

        /// <summary>
        /// Gets all public instance methods of a type in a flat hierarchy.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An array of methods from the given type.
        /// </returns>
        /// <remarks>
        /// Note if the type is a non-interface the flat hierarchy will be ordered from derived class methods to base class methods,
        /// whilst if the type is an interface that flat hierarchy will be ordered from base class methods to derived class methods.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> was null.</exception>
        public static MethodInfo[] GetAllPublicMethods(this Type type)
        {
            type.ThrowIfNull(nameof(type),
                   $"Unable to get Methods, {nameof(type)} cannot be null");

            return GetMethods(type, BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.Instance);
        }

        /// <summary>
        /// Gets all public instance methods of a type in a flat hierarchy excluding the <see cref="object"/> methods.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An array of methods from the given type.
        /// </returns>
        /// <remarks>
        /// Note if the type is a non-interface the flat hierarchy will be ordered from derived class methods to base class methods,
        /// whilst if the type is an interface that flat hierarchy will be ordered from base class methods to derived class methods.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> was null.</exception>
        public static MethodInfo[] GetAllPublicMethodsExcludingObjectBase(this Type type)
        {
            type.ThrowIfNull(nameof(type),
                   $"Unable to get Methods, {nameof(type)} cannot be null");

            return GetAllPublicMethods(type)
                .Where(m => m.DeclaringType != typeof(object))
                .ToArray();
        }

        /// <summary>
        /// Returns the underlying type for a specified sequence type.
        /// </summary>
        /// <param name="sequenceType">The sequence type.</param>
        /// <returns>
        /// The underlying type of the original sequence.
        /// </returns>
        public static Type FindEnumerable(this Type sequenceType)
        {
            if (sequenceType == null || 
                sequenceType == typeof(string))
            {
                return null;
            }

            // array type
            if (sequenceType.IsArray)
            {
                return typeof(IEnumerable<>)
                    .MakeGenericType(sequenceType.GetElementType());
            }

            // generic enumerable type
            Type genericType = FindEnumerableForGeneric(sequenceType);
            if(genericType != null)
            {
                return genericType;
            }

            // interface type
            Type interfaceType = FindEnumerableForInterface(sequenceType);
            if(interfaceType != null)
            {
                return interfaceType;
            }

            // base type
            if (sequenceType.BaseType != null && 
                sequenceType.BaseType != typeof(object))
            {
                return FindEnumerable(sequenceType.BaseType);
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo[] GetProperties(Type type, BindingFlags bindingFlags)
        {
            if (type.IsInterface)
            {
                var properties = new List<PropertyInfo>();

                var considered = new List<Type>(new Type[] { type });
                var queue = new Queue<Type>(new Type[] { type });

                while (queue.Count != 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in subType.GetInterfaces())
                    {
                        if (considered.Contains(subInterface))
                        {
                            continue;
                        }
                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }

                    var newProperties = subType.GetProperties(bindingFlags)
                        .Where(x => !properties.Contains(x));

                    properties.InsertRange(0, newProperties);
                }
                return properties.ToArray();
            }
            return type.GetProperties(bindingFlags);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo[] GetMethods(Type type, BindingFlags bindingFlags)
        {
            if (type.IsInterface)
            {
                var methods = new List<MethodInfo>();

                var considered = new List<Type>(new Type[] { type });
                var queue = new Queue<Type>(new Type[] { type });

                while (queue.Count != 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in subType.GetInterfaces())
                    {
                        if (considered.Contains(subInterface))
                        {
                            continue;
                        }
                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }

                    var newMethods = subType.GetMethods(bindingFlags)
                        .Where(x => !methods.Contains(x));

                    methods.InsertRange(0, newMethods);
                }
                return methods.ToArray();
            }
            return type.GetMethods(bindingFlags);
        }

        private static Type FindEnumerableForGeneric(Type sequenceType)
        {
            if (sequenceType.IsGenericType)
            {
                foreach (Type arg in sequenceType.GetGenericArguments())
                {
                    Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if (ienum.IsAssignableFrom(sequenceType))
                    {
                        return ienum;
                    }
                }
            }
            return null;
        }

        private static Type FindEnumerableForInterface(Type sequenceType)
        {
            Type[] interfaceTypes = sequenceType.GetInterfaces();
            if (interfaceTypes != null &&
                interfaceTypes.Length != 0)
            {
                foreach (Type interfaceType in interfaceTypes)
                {
                    Type ienum = FindEnumerable(interfaceType);
                    if (ienum != null)
                    {
                        return ienum;
                    }
                }
            }
            return null;
        }
    }
}
